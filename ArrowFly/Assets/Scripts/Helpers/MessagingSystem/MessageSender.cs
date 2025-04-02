using System;
using UnityEngine;

namespace Helpers.Massaging
{
    class MessageSender : MonoBehaviour
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MessagingSystem.Instance.QueueMassage(new CstmMessage(5, 13.355f));
            }
        }
    }
}
