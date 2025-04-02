using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Massaging
{
    class MessagingSystem : Singleton<MessagingSystem>
    {
        public delegate bool MessageHandlerDelegate(BaseMessage message);

        private float _maxQueueProccessingTime = 0.16667f;
        private Dictionary<string, List<MessageHandlerDelegate>> _listnerDictionary =
            new Dictionary<string, List<MessageHandlerDelegate>>();
        private Queue<BaseMessage> _queueMassages = new Queue<BaseMessage>();
        public static MessagingSystem Instance
        {
            get
            {
                return (MessagingSystem)_instanceSingleton;
            }
            set
            {
                _instanceSingleton = value;
            }
        }

        #region UnityMethods

        private void Update()
        {
            float timer = 0.0f;
            while (_queueMassages.Count > 0)
            {
                if (_maxQueueProccessingTime > 0.0f)
                {
                    if (timer > _maxQueueProccessingTime)
                    {
                        return;
                    }
                    BaseMessage massage = _queueMassages.Dequeue();
                    if (!TriggerMassege(massage))
                    {
                        Debug.Log("Error when processing message: " + massage.Name);
                    }
                    if (_maxQueueProccessingTime > 0.0f)
                    {
                        timer += Time.deltaTime;
                    }
                }
            }
        }

        #endregion


        public bool AttachListner(Type type, MessageHandlerDelegate handlerDelegate)
        {
            if (type == null)
            {
                Debug.Log("type == null");
                return false;
            }

            string msgName = type.Name;
            if (!_listnerDictionary.ContainsKey(msgName))
            {
                _listnerDictionary.Add(msgName, new List<MessageHandlerDelegate>());
            }

            List<MessageHandlerDelegate> listHandler = _listnerDictionary[msgName];
            if (listHandler.Contains(handlerDelegate))
            {
                return false;
            }

            listHandler.Add(handlerDelegate);
            return true;
        }

        public bool DetachListner(Type type, MessageHandlerDelegate handlerDelegate)
        {
            if (type == null)
            {
                Debug.Log("MessagingSystem: DetachListener failed due to no message type specified");
                return false;
            }

            string messageName = type.Name;
            if (!_listnerDictionary.ContainsKey(type.Name))
            {
                return false;
            }

            List<MessageHandlerDelegate> listHandler = _listnerDictionary[type.Name];
            if (!listHandler.Contains(handlerDelegate))
            {
                return false;
            }

            listHandler.Remove(handlerDelegate);
            return true;
        }

        public bool QueueMassage(BaseMessage massage)
        {
            if (!_listnerDictionary.ContainsKey(massage.Name))
            {
                return false;
            }
            _queueMassages.Enqueue(massage);

            return true;
        }

        private bool TriggerMassege(BaseMessage massage)
        {
            string msgName = massage.Name;
            if (!_listnerDictionary.ContainsKey(msgName))
            {
                Debug.Log("MessagingSystem: Message \"" + msgName + "\" has nolisteners!");
                return false;
            }

            List<MessageHandlerDelegate> listHandlers = _listnerDictionary[msgName];
            for (int i = 0; i < listHandlers.Count; i++)
            {
                if (listHandlers[i](massage))
                {
                    return true;
                }
            }

            return true;
        }
    }
}

