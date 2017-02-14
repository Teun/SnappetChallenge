using Autofac;
using SnappetChallenge.DataAccessLayer.Interfaces;
using SnappetChallenge.DataAccessLayer.Repositories;

namespace SnappetChallenge.DataAccessLayer
{
    public class AutoFacInit : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder
                .Register(x => new SubmittedAnswerJsonRepository(@"SnappetChallenge.DataAccessLayer.DataFiles.work.json"))
                .As<ISubmittedAnswerRepository>()
                .InstancePerDependency();
        }
    }
}
