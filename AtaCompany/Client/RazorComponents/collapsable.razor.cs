namespace AtaCompany.Client.RazorComponents;

public partial class Collapsable
{
    [Parameter] public required RenderFragment ChildContent { get; set; }
    [Parameter] public bool Collapsed { get; set; }
    [Parameter] public required string Value { get; set; }

    void Toggle()
    {
        Collapsed = !Collapsed;
    }
}

