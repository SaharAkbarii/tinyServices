namespace TinyServices.API.LinkService.Model;
public class LinkInsight
{
    public int TotalClickCount { get; set; }
    public List<DailyLinkInsight> DailyLinkInsights {get; set;}

}

public class DailyLinkInsight
{
    public int ClickCount { get; set; }
    public DateTimeOffset Date { get; set; }
}
