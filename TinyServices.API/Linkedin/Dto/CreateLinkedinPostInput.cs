namespace TinyServices.API.Linkedin.Dto;
    public class CreateLinkedinPostInput
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public List<string>? ImageUrl{get; set;}
    }
