namespace Behaviours
{
    sealed class ComponentsInitializer : BaseInitializer
    {
        protected override void FillInitializers()
        {
            Initializers.Add(new CamerasInitializer());
            Initializers.Add(new LevelLoaderInitializer());
            Initializers.Add(new GameStateControllerInitializer());
        }
    }
}
