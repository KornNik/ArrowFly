namespace Behaviours
{
    sealed class SystemsInitializer : BaseInitializer
    {
        protected override void FillInitializers()
        {
            Initializers.Add(new DataInitializer());
            Initializers.Add(new SettingsInitializer());
            Initializers.Add(new TimeInitializer());
            Initializers.Add(new AudioInitializer());
            Initializers.Add(new InputItializer());
        }
    }
}
