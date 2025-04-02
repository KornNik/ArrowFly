namespace Helpers
{
    interface IServiceLocator<T>
    {
        V Register<V>(V newService) where V : T;
        void Unregister<V>(V service) where V : T;
        V GetService<V>() where V : T;
    }
}
