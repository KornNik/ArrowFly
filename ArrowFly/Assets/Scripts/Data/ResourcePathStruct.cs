using System;

namespace Data
{
    [Serializable]
    struct ResourcePathStruct<TType> where TType : struct
    {
        public TType Type;
        public string ResourcePath;
    }
}
