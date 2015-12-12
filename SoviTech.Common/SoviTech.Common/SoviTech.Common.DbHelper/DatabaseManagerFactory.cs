
using Autofac;
using SoviTech.Common.Contracts;

namespace SoviTech.Common.DatabaseHelper
{
    /// <summary>
    /// Database Manager Factory to create database manager object
    /// </summary>
    public static class DatabaseManagerFactory
    {
        /// <summary>
        /// Register Object with DI container
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterDIContainter(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseManager>()
                .As<IDatabaseManager>()
                .AsImplementedInterfaces()
                .AsSelf();
                //.SingleInstance();

        }
    }
}
