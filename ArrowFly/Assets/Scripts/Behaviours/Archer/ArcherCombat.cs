using System;
using UnityEngine;

namespace Behaviours
{
    class CombatActions
    {
        public Action StartDraw;
        public Action EndDraw;
        public Action HoldDraw;
    }
    sealed class ArcherCombat : ICombat
    {
        private IBow _bow;
        private CombatActions _combatActions;

        public CombatActions Actions => _combatActions;

        public ArcherCombat(IBow bow)
        {
            _bow = bow;
            _combatActions = new CombatActions();
        }

        public void OnStartDrawBow()
        {
            _bow.OnStartDrawBow();
            _combatActions.StartDraw?.Invoke();
        }
        public void OnHoldDraw(Vector2 startMousePosition, Vector2 endMousePosition)
        {
            _bow.OnHoldDraw(startMousePosition, endMousePosition);
            _combatActions.HoldDraw?.Invoke();
        }
        public void OnReleaseDraw()
        {
            _bow.OnReleaseDraw();
            _combatActions.EndDraw?.Invoke();
        }

        public void Attack()
        {
            _bow.ThrowArrow();
        }
    }

}
