using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    struct ResorcePrefabStruct<TType> where TType : struct
    {
        public TType Type;
        public GameObject Gameobject;
    }
}
