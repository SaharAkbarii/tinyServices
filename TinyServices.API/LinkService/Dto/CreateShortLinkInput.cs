
namespace TinyServices.API.LinkService.Dto;

public record CreateShortLinkInput(string MainLink, DateTimeOffset? DeadLine, Guid CompanyId);

