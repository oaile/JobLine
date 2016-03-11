using Autofac;
using AutoMapper;
using JobLineBUS.Contracts;
using JobLineBUS.Dtos;
using JobLineBUS.Services;
using JobLineDAL;
using JobLineDAL.Entities;

namespace JobLineBUS
{
    public class BusModule : Module
    {
        private readonly string _connectionString;
        public BusModule(string connectionString)
        {
            _connectionString = connectionString;
            RegisterMapper();
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserService>().
                As<IUserService>().InstancePerRequest();

            //builder.RegisterType<ManufactureBusinessService>().
            //   As<IManufactureBusinessService>().InstancePerRequest();

            builder.RegisterModule(new DalModule(_connectionString));
            base.Load(builder);
        }

        private void RegisterMapper()
        {
            Mapper.CreateMap<BaseEntity, BaseDto>().ReverseMap();
            Mapper.CreateMap<User, UserDto>().ReverseMap();
            Mapper.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            Mapper.CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
