namespace Behaviours
{
    sealed class SystemInitializerAsync : BaseInitializerAsync
    {
        protected override void FillInitializers()
        {
            Initializers.Add(new DataInitializerAsync());
            Initializers.Add(new SettingsInitializerAsync());
            Initializers.Add(new TimeInitializerAsync());
            Initializers.Add(new AudioInitializerAsync());
            Initializers.Add(new InputItializerAsync());
        }
    }
}
