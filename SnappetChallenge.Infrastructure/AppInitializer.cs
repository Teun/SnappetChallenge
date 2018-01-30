using System.Collections.Generic;

namespace SnappetChallenge.Infrastructure
{
    public class AppInitializer : IAppInitializer
    {
        private readonly IEnumerable<IInitializer> initializers;

        public AppInitializer(IEnumerable<IInitializer> initializers)
        {
            this.initializers = initializers;
        }

        public void Start()
        {
            foreach (var initializer in initializers)
            {
                initializer.Init();
            }
        }
    }
}