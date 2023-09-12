using TinyServices.API.LinkService.Model;

namespace TinyServices.API.LinkService.Dto.MappingExtention;
    public static class Mapper
    {
        public static ShortLinkDto ToDto(this ShortLink shortLink)
        {
            var dto = new ShortLinkDto()
            {
                MainLink = shortLink.MainLink,
                Token = shortLink.Token,
                Id = shortLink.Id
            };
            return dto;
        }
        public static List<ShortLinkDto> ToDto (this List <ShortLink> shortLinks)
        {
            return shortLinks?.Select(x => x.ToDto()).ToList();
        }

        public static DeepLinkDto ToDto(this DeepLink deepLink)
        {
            var dto = new DeepLinkDto()
            {
                IosLink = deepLink.IosLink,
                AndroidLink = deepLink.AndroidLink,
                DesktopLink = deepLink.DesktopLink,
                DefaultRoute = deepLink.DefaultRoute,
                ShortenLink = deepLink.Token,
                Id = deepLink.Id
            };
            return dto;
        }
        // public static CompanyDto ToDto (this Company company)
        // {
        //     var dto = new CompanyDto (company.Name, company.Id, company.ShortLinks.ToDto());
        //     return dto;
        // }
    }
