using UnityEngine;
using UnityEngine.Events;

namespace AlreadyGone.DesignPattern.Observers
{
    public class MessageListener : MonoBehaviour
    {
        [SerializeField] private Message[] _messageArray;
        [SerializeField] private UnityEvent _callbacks;

        private void OnEnable()
        {
            foreach (Message message in _messageArray)
            {
                message.MessageAction += InvokeCallbacks;
            }
        }

        private void OnDisable()
        {
            foreach (Message message in _messageArray)
            {
                message.MessageAction -= InvokeCallbacks;
            }
        }

        private void InvokeCallbacks()
        {
            _callbacks?.Invoke();
        }
    }
}