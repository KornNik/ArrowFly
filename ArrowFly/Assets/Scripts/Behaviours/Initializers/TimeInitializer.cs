using Helpers;
using Controllers;

namespace Behaviours
{
    class TimeInitializer : IInitialization
    {
        public void Initialization()
        {
            var timeController = new TimeController();
            Services.Instance.TimeController.SetObject(timeController);
        }
    }
}
