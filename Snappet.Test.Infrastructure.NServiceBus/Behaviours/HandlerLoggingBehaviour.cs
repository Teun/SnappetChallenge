using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Pipeline;

namespace Snappet.Test.Infrastructure.NServiceBus.Behaviours
{
    public class HandleLoggingBehaviour : Behavior<IInvokeHandlerContext>
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleLoggingBehaviour>();

        public override async Task Invoke(IInvokeHandlerContext context, Func<Task> next)
        {
            Type handlerType = context.MessageHandler.HandlerType;
            string handlerName = handlerType.Name;
            try
            {
                Log.Info($"Executing {handlerName} for message [{context.MessageMetadata.MessageType.Name}]...");

                await next().ConfigureAwait(false);
            }
            //catch (Exception ex)
            //{
            //    Log.Error($"Exception executing {handlerName} for message [{context.MessageMetadata.MessageType.Name}]", ex);
            //    throw;
            //}
            finally
            {
                Log.Info($"End Execution of {handlerName} for message [{context.MessageMetadata.MessageType.Name}]...");
            }
        }

        internal class HandleLoggingBehaviourStep : RegisterStep, INeedInitialization
        {
            public HandleLoggingBehaviourStep()
                : base(nameof(HandleLoggingBehaviour), typeof(HandleLoggingBehaviour),
                    "Logs when a handle starts and finishes")
            {
            }

            public void Customize(EndpointConfiguration configuration)
            {
                // Register the behavior in the pipeline
                configuration.Pipeline.Register<HandleLoggingBehaviourStep>();
            }
        }

    }
}