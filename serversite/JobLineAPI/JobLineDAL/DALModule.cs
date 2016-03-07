using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using JobLineDAL.Contracts;
using JobLineDAL.Entities;
using JobLineDAL.Repositories;

namespace JobLineDAL
{
    public class DalModule : Module
    {
        private readonly string _connectionString;

        public DalModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new JobLineDbContext(_connectionString)).
                As<IDbContext>().InstancePerRequest();
            builder.RegisterType<BaseRepository<Role>>().
                As<IRepository<Role>>().InstancePerRequest();
            builder.RegisterType<BaseRepository<User>>().
                As<IRepository<User>>().InstancePerRequest();
            builder.RegisterType<BaseRepository<UserProfile>>().
                As<IRepository<UserProfile>>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
