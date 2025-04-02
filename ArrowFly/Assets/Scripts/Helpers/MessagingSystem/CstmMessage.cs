namespace Helpers.Massaging
{
    class CstmMessage : BaseMessage
    {
        public readonly int INT_VALUE;
        public readonly float FLOAT_VALUE;

        public CstmMessage(int intValue, float floatValue)
        {
            INT_VALUE = intValue;
            FLOAT_VALUE = floatValue;
        }
    }
}

