namespace TinyServices.API.Divar.Dto
{
    public class SearchResultDto<TResult>
    {
        public List<TResult> Results {get; set;}
        public int TotalCount {get; set;}
    }
}