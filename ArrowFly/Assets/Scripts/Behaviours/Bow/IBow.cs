using UnityEngine;

namespace Behaviours
{
    interface IBow
    {
        void OnStartDrawBow();
        void OnHoldDraw(Vector2 startMousePosition, Vector2 endMousePosition);
        void OnReleaseDraw();
        void ThrowArrow();
    }
}
