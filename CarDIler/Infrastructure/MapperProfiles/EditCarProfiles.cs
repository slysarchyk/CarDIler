using AutoMapper;
using CarDIler.Data.Models.Car;
using CarDIler.ViewModel;

namespace CarDIler.Infrastructure.MapperProfiles
{
    public class EditCarProfiles : Profile
    {
        public EditCarProfiles()
        {
            CreateMap<Car, EditCarViewModel>();
        }
    }
}
