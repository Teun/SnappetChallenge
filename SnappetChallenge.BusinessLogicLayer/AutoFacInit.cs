using Autofac;
using SnappetChallenge.BusinessLogicLayer.Interfaces;
using SnappetChallenge.BusinessLogicLayer.Mappers;
using SnappetChallenge.BusinessLogicLayer.Services;

namespace SnappetChallenge.BusinessLogicLayer
{    
    public class AutoFacInit : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule(new SnappetChallenge.DataAccessLayer.AutoFacInit());

            builder
                .RegisterType<SubmittedAnswerMapper>()
                .As<ISubmittedAnswerMapper>()
                .SingleInstance();
            builder
                .RegisterType<SubmittedAnswerService>()
                .As<ISubmittedAnswerService>()
                .InstancePerDependency();
        }
    }
}
