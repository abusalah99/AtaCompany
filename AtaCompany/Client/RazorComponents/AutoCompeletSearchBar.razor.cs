using Microsoft.AspNetCore.Components.Web;
using System.Globalization;

namespace AtaCompany.Client.RazorComponents;

public partial class AutoCompeletSearchBar<TEntity> : IDisposable where TEntity : BaseEntitySetting
{
    [Parameter]
    public List<TEntity> Entities { get; set; } = null!;
    [Inject]
    public SearchParameters<TEntity> _searchParameters { get; set; } = null!;

    private int selectedSuggestionIndex = -1;
    private bool isInputFocused = false;
    private bool IsHovered = false;

    private CancellationTokenSource debounceTokenSource = new CancellationTokenSource();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _searchParameters.OnFilteredLocationsChanged += HandleFilteredLocationsChanged!;
        _searchParameters.OnSuggestionsChanged += HandleSuggestionsChanged!;
        _searchParameters.OnSearchTextChanged += HandleSearchTextChanged!;
    }

    private async Task HandleSearch(ChangeEventArgs e)
    {
        isInputFocused = true;

        var value = e.Value ?? new();

        _searchParameters.SearchText = value.ToString() ?? string.Empty;

        debounceTokenSource.Cancel();
        debounceTokenSource = new CancellationTokenSource();

        await Task.Delay(100, debounceTokenSource.Token);

        if (!string.IsNullOrWhiteSpace(_searchParameters.SearchText))
            _searchParameters.Suggestions = Entities
                            .Where(e => e.Name.Contains(_searchParameters.SearchText))
                            .DistinctBy(e => e.Name)
                            .OrderBy(e => e.Name, StringComparer.Create(new CultureInfo("ar-SA"), true))
                            .ToList();

        else
        {
            _searchParameters.FilteredItems.Clear();

            GetAllSuggestionIfInputBoxFocused();
        }
    }

    private void HandleFoucus()
    {
        isInputFocused = true;
        if (string.IsNullOrWhiteSpace(_searchParameters.SearchText))
            _searchParameters.Suggestions = Entities
                    .DistinctBy(e => e.Name)
                    .OrderBy(e => e.Name, StringComparer.Create(new CultureInfo("ar-SA"), true))
                    .ToList();
    }

    private void HandleBlur()
    {
        if (!string.IsNullOrWhiteSpace(_searchParameters.SearchText))
            _searchParameters.Suggestions.Clear();
        if(!IsHovered)
            isInputFocused = false;
    }

    private void HandleMouseEnter() => IsHovered = true;

    private void HandleMouseLeave() => IsHovered = false;
    
    private void HandleSuggetionClick(string suggestion)
    {
        _searchParameters.FilteredItems = Entities.Where(e => e.Name == suggestion).ToList();


        _searchParameters.SearchText = suggestion;

        _searchParameters.Suggestions.Clear();

        selectedSuggestionIndex = -1;

        isInputFocused = false;
        IsHovered = false;
    }

    private void HandleArrowKeyNavigation(KeyboardEventArgs e)
    {
        switch (e.Key)
        {
            case "ArrowDown":
                selectedSuggestionIndex = Math.Min(selectedSuggestionIndex + 1, _searchParameters.Suggestions.Count - 1);
                break;
            case "ArrowUp":
                selectedSuggestionIndex = Math.Max(selectedSuggestionIndex - 1, -1);
                break;
            case "Enter":
                if (selectedSuggestionIndex >= 0 && selectedSuggestionIndex < _searchParameters.Suggestions.Count)
                    HandleSuggetionClick(_searchParameters.Suggestions[selectedSuggestionIndex].Name);
                break;
            default:
                return;
        }

        if (selectedSuggestionIndex >= 0 && selectedSuggestionIndex < _searchParameters.Suggestions.Count)
            _searchParameters.SearchText = _searchParameters.Suggestions[selectedSuggestionIndex].Name;
    }

    private void GetAllSuggestionIfInputBoxFocused()
    {
        if (isInputFocused)
            _searchParameters.Suggestions = Entities
                .DistinctBy(e => e.Name)
                .OrderBy(e => e.Name, StringComparer.Create(new CultureInfo("ar-SA"), true))
                .ToList();
    }
    private string GetSuggestionItemClass(int index) => index == selectedSuggestionIndex ? "option selected" : "option";

    public void Dispose()
    {
        _searchParameters.OnFilteredLocationsChanged -= HandleFilteredLocationsChanged!;
        _searchParameters.OnSuggestionsChanged -= HandleSuggestionsChanged!;
        _searchParameters.OnSearchTextChanged -= HandleSearchTextChanged!;
    }

    protected void HandleFilteredLocationsChanged(object sender, EventArgs e) => StateHasChanged();
    protected void HandleSuggestionsChanged(object sender, EventArgs e) => StateHasChanged();
    protected void HandleSearchTextChanged(object sender, EventArgs e) => StateHasChanged();

}


public class SearchParameters<TEntity>
{
    private List<TEntity> _filteredItems = new ();
    public List<TEntity> FilteredItems
    {
        get => _filteredItems;
        set
        {
            if (!ReferenceEquals(_filteredItems, value))
            {
                _filteredItems = value;
                OnFilteredLocationsChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private List<TEntity> _suggestions = new ();
    public List<TEntity> Suggestions
    {
        get => _suggestions;
        set
        {
            if (!ReferenceEquals(_suggestions, value))
            {
                _suggestions = value;
                OnSuggestionsChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                OnSearchTextChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler OnFilteredLocationsChanged = null!;
    public event EventHandler OnSuggestionsChanged = null!;
    public event EventHandler OnSearchTextChanged= null!;
}