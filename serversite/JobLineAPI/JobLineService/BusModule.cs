using Autofac;
using JobLineDAL;

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

            //builder.RegisterType<AgendaItemBusinessService>().
            //    As<IAgendaBusinessService>().InstancePerRequest();

            //builder.RegisterType<ManufactureBusinessService>().
            //   As<IManufactureBusinessService>().InstancePerRequest();

            builder.RegisterModule(new DalModule(_connectionString));
            base.Load(builder);
        }

        private void RegisterMapper()
        {
            
        }
    }
}
