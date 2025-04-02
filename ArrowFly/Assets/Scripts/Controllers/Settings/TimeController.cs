using Behaviours;
using Data;
using Helpers;
using UnityEngine;

namespace Controllers
{
    class TimeController : ITimeController
    {
        private DefaultTimeData _timeData;

        public TimeController()
        {
            _timeData = Services.Instance.DatasBundle.ServicesObject.GetData<DefaultTimeData>();
        }

        public void PauseTime()
        {
            Time.timeScale = _timeData.PauseTime;
        }
        public void ResumeTime()
        {
            Time.timeScale = _timeData.NormalTime;
        }
    }
}
