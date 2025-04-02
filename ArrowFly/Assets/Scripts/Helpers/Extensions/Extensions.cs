using System;

namespace Helpers.Extensions
{
    static class Extensions
    {
        // Functions usage
        //someObject.With(e => e.SetActive(true));
        //someObject.With(e => e.SetActive(true), () => _weapon.IsActive());
        //someObject.With(e => e.SetActive(true), _weapon.IsActive());

        public static T With<T>(this T self, Action<T> set )
        {
            set?.Invoke(self);
            return self;
        }
        public static T With<T>(this T self, Action<T> apply, Func<bool> when)
        {
            if(when())
            {
                apply?.Invoke(self);
            }
            return self;
        }
        public static T With<T>(this T self, Action<T> apply, bool when)
        {
            if (when)
            {
                apply?.Invoke(self);
            }
            return self;
        }
    }
}
