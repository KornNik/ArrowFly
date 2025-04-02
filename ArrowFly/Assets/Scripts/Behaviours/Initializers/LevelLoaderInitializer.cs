using Helpers;

namespace Behaviours
{
    sealed class LevelLoaderInitializer : IInitialization
    {
        public void Initialization()
        {
            var lelveLoader = new LevelLoader();
            Services.Instance.LevelLoader.SetObject(lelveLoader);
        }
    }
}
