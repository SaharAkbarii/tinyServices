using AutoMapper;
using TinyServices.API.Divar.Dto;
using TinyServices.API.Divar.Model;
using TinyServices.API.Linkedin.Dto;
using TinyServices.API.Linkedin.Model;
using TinyServices.API.LinkService.Dto;
using TinyServices.API.LinkService.Model;
using TinyServices.API.NewsMagazine.Dto;
using TinyServices.API.NewsMagazine.Model;

namespace TinyServices.API;

public class TinyServicesMappingProfile : Profile
{
    public TinyServicesMappingProfile()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<ShortLink, ShortLinkDto>();
        CreateMap<OneTimeLink, OneTimeLinkDto>();
        CreateMap<DeepLink, DeepLinkDto>();
        CreateMap<CategoryProperty, CategoryPropertyDto>();
        CreateMap<SearchResult<Category>, SearchResultDto<CategoryDto>>();
        CreateMap<PropertyValue, PropertyValueDto>();
        CreateMap<Advertisement, AdvertisementDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<User, UserDto>();
        CreateMap<SearchResult<Advertisement>, SearchResultDto<AdvertisementDto>>();
        CreateMap<LinkedinPost, LinkedinPostDto>();
        CreateMap<LinkedinUser, LinkedinUserDto>();
        CreateMap<Like, LikeDto>();
        CreateMap<Comment, CommentDto>();
        CreateMap<ConnectionRequest, ConnectionRequestDto>();
        CreateMap<Connection, ConnectionDto>();
        CreateMap<PostInformation, PostInformationDto>();
        CreateMap<LinkedinUserInformation, LinkedinUserInformationDto>();
        CreateMap<News, NewsDto>();
        CreateMap<NewsLike<News>, NewsLikeDto>();
        CreateMap<NewsLike<NewsComment>, NewsLikeDto>();
        CreateMap<NewsComment, NewsCommentDto>();
        CreateMap<NewsDisLike<News>, NewsDisLikeDto>();
        CreateMap<NewsDisLike<NewsComment>, NewsDisLikeDto>();
        CreateMap<Status, StatusDto>();
        CreateMap<StatusDto, Status>();
        CreateMap<NewsUser, NewsUserDto>();
        CreateMap<NewsUserInformation, NewsUserInformationDto>();
        CreateMap<NewsInformation, NewsInformationDto>();
        CreateMap<NewsCommentInformation, NewsCommentInformationDto>();
        CreateMap<NewsCategory, NewsCategoryDto>();
        CreateMap<FavoriteCategory, FavoriteCategoryDto>();
        CreateMap<NewsCategoryContainer, NewsCategoryContainerDto>();
        
    }
}