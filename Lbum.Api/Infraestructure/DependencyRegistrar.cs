using Autofac;
using Lbum.Api.Infraestructure.DependencyManagement;
using Lbum.Core.Configuration;
using Lbum.Core.Infraestructure;
using Lbum.Domain.Cont;
using Lbum.Domain.Impl;
using Lbum.Repository.Contrat;
using Lbum.Repository.Impl;

namespace Lbum.Api.Infraestructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 2;
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, LbumConfig config)
        {
            //installation localization domain
            builder.RegisterType<ConceptoDomainImpl>().As<IConceptoDomainCont>().InstancePerLifetimeScope();

            //installation localization repository
            builder.RegisterType<ConceptoRepositoryImpl>().As<IConceptoRepository>().InstancePerLifetimeScope();

            //installation localization data
            //builder.RegisterType<IConceptoDomainCont>().As<IConceptoDomainCont>().InstancePerLifetimeScope();

        }
    }
}
