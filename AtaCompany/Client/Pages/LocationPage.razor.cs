namespace AtaCompany.Client.Pages;

public partial class LocationPage
{
    [Parameter]
    public Guid Id { get; set; }

    private List<dynamic> items = new()
        {
            new { Name = "accounts", ArabicName = "الحسابات" },
            new { Name = "contractors", ArabicName = "المقاولين" },
            new { Name = "wares", ArabicName = "البضاعة" },
            new { Name = "reports", ArabicName = "التقارير" },
            new { Name = "suppliers", ArabicName = "الموردين" },
        };
}
