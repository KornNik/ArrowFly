using System.Collections.Generic;

namespace Behaviours
{
    abstract class BaseInitializer : IInitialization
    {
        private List<IInitialization> _initializers = new List<IInitialization>();

        public List<IInitialization> Initializers => _initializers;

        public void Initialization()
        {
            FillInitializers();
            Initialize();
        }

        private void Initialize()
        {
            foreach (var initializer in _initializers)
            {
                initializer.Initialization();
            }
        }
        protected abstract void FillInitializers();
    }
}
