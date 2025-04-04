using UnityEngine;

namespace Behaviours
{
    interface ICombat
    {
        void OnStartDrawBow();
        void OnHoldDraw(Vector2 startMousePosition, Vector2 endMousePosition);
        void OnReleaseDraw();
        void Attack();
    }

}
