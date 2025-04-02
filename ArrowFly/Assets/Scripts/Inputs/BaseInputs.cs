using Behaviours;
using UnityEngine;

namespace Inputs
{
    abstract class BaseInputs<T> : MonoBehaviour, IInitialization
    {
        protected T _controllObject;
        public BaseInputs(T controllObject)
        {
            _controllObject = controllObject;
        }

        public abstract void UpdateControll();

        public virtual void Update()
        {
            UpdateControll();
        }

        public abstract void Initialization();
    }
}
