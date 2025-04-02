using UnityEngine;

namespace UI
{
    abstract class ButtonExtenderAction : ScriptableObject, IBtnExtenderAction
    {
        public abstract void PerformAction();
    }
}
