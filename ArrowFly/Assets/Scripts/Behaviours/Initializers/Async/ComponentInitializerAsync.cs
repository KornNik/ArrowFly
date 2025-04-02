namespace Behaviours
{
    sealed class ComponentInitializerAsync : BaseInitializerAsync
    {
        protected override void FillInitializers()
        {
            Initializers.Add(new CameraInitializerAsync());
            Initializers.Add(new LevelLoaderInitializerAsync());
            Initializers.Add(new GameStateInitializerAsync());
        }
    }
}
