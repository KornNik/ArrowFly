using Behaviours;

namespace Helpers
{
    class SingletoneSimple<T> : IInitialization where T : SingletoneSimple<T>
    {
        private bool _alive;
        private static T _instance;

        public static bool IsAlive
        {
            get
            {
                if (_instance == null)
                    return false;
                return _instance._alive;
            }
        }

        public SingletoneSimple()
        {
            _alive = true;
        }
        ~SingletoneSimple()
        {
            _alive = false;
        }

        public virtual void Initialization()
        {
            var instanceReference = this as T;
            if (instanceReference == null)
            {
                if (ReferenceEquals(_instance, null))
                {
                    _instance = new SingletoneSimple<T>() as T;
                }
            }
            else
            {
                _instance = instanceReference;
            }
        }
        public virtual void CleanUp()
        {
            _alive = false;
        }

        protected static SingletoneSimple<T> _instanceSingleton
        {
            get
            {
                if (ReferenceEquals(_instance, null))
                {
                    throw new System.Exception($"Some object trying access SingletoneSimple but its dasnt exist");
                }
                else
                {
                    return _instance;
                }
            }
            set { _instance = value as T; }
        }
        public static T GetInstance()
        {
            var currentInstance = _instanceSingleton as T;
            return currentInstance;
        }
    }
}
