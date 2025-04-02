namespace Helpers.Massaging
{
    class BaseMessage
    {
        public string Name;
        public BaseMessage() { Name = this.GetType().Name; }
    }
}

