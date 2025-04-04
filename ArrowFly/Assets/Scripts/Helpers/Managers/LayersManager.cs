using UnityEngine;

namespace Helpers.Managers
{
    static class LayersManager
    {
        public const string UI = "UI";
        public const string DEFAULT = "Default";
        public const string GROUND = "Ground";
        public const string ARCHER = "Archer";
        public const string TARGET = "Target";
        public const string PROJECTILE = "Projectile";

        public const int DEFAULT_LAYER = 0;
        
        static LayersManager()
        {
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            UiLayer = LayerMask.GetMask(UI);
            Ground = LayerMask.GetMask(GROUND);
            Archer = LayerMask.GetMask(ARCHER);
            Target = LayerMask.GetMask(TARGET);
            Projectile = LayerMask.GetMask(PROJECTILE);
        }
        
        public static int DefaultLayer { get; }
        public static int UiLayer { get; }
        public static int Ground { get; }
        public static int Archer { get; }
        public static int Target { get; }
        public static int Projectile { get; }
    }
}
