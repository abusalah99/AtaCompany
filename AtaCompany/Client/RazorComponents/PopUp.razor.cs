namespace AtaCompany.Client.RazorComponents;
public partial class PopUp
{
    [Inject]
    private PopUpState _popUp { get; set; } = null!;
    [Parameter]
    public required string Title { get; set; }
    [Parameter]
    public required RenderFragment FromContent { get; set; }

    private string GetPopUpStyle() => _popUp.IsPopUpVisible ? "flex" : "none";
    
}
public class PopUpState
{
    public bool IsPopUpVisible { get; set; } = false;

    public void TogglePopUpVisibility() => IsPopUpVisible = !IsPopUpVisible;
    
}