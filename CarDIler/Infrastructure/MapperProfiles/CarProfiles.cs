using AutoMapper;
using CarDIler.Data.Models.Car;
using CarDIler.ViewModel;

namespace CarDIler.Infrastructure.MapperProfiles
{
    public class CarProfiles : Profile
    {
        public CarProfiles()
        {
            CreateMap<AddCarViewModel, Car>()
                .ForMember(x => x.Id, otp => otp.Ignore());
        }
    }
}
