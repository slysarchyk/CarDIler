using AutoMapper;
using CarDIler.Data.Models;
using CarDIler.ViewModel;

namespace CarDIler.Infrastructure.MapperProfiles
{
    public class BlogPostProfiles : Profile
    {
        public BlogPostProfiles()
        {
            CreateMap<AddBlogPostViewModel, BlogPost>()
                .ForMember(x => x.Id, otp => otp.Ignore())
                .ForMember(x => x.AddedBy, otp => otp.Ignore())
                .ForMember(x => x.Date, otp => otp.Ignore())
                .ForMember(x => x.CoverPath, otp => otp.Ignore());
        }
    }
}
