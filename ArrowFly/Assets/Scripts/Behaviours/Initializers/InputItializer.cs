using Controllers;

namespace Behaviours
{
    sealed class InputItializer : IInitialization
    {
        public void Initialization()
        {
            var inputController = new InputLoader();
        }
    }
}
