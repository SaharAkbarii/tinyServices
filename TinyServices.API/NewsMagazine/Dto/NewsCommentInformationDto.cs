namespace TinyServices.API.NewsMagazine.Dto;
    public class NewsCommentInformationDto
    {
        public Guid Id { get; set; }
        public NewsUserInformationDto NewsUser { get; set; }
        public string Body { get; set; }

    }
