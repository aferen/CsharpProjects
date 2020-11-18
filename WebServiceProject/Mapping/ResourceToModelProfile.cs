using AutoMapper;
using WebServiceProject.Models.Resources;
using WebServiceProject.Models;

namespace WebServiceProject.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<UserCredentialsResource, User>();
        }
    }
}