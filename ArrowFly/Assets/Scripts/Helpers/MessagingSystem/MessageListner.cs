using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Massaging
{
    class MessageListner : MonoBehaviour
    {
        private void Start()
        {
            MessagingSystem.Instance.AttachListner(typeof(CstmMessage), this.HandleCstmMessage);
        }
        private void OnDestroy()
        {
            if (MessagingSystem.IsAlive)
            {
                MessagingSystem.Instance.DetachListner(typeof(CstmMessage), this.HandleCstmMessage);
            }
        }

        private bool HandleCstmMessage(BaseMessage message)
        {
            CstmMessage cstmMessage = message as CstmMessage;
            Debug.Log(string.Format("Got the message! {0}, {1}", cstmMessage.INT_VALUE, cstmMessage.FLOAT_VALUE));
            return true;
        }
    }
}
