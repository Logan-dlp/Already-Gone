using UnityEngine;
using UnityEngine.Events;

namespace AlreadyGone.DesignPattern.Observers.Typed
{
    public abstract class TypedMessageListener<T> : MonoBehaviour
    {
        [SerializeField] private TypedMessage<T>[] _messageArray;
        [SerializeField] private UnityEvent<T> _callbacks;

        private void OnEnable()
        {
            foreach (TypedMessage<T> message in _messageArray)
            {
                message.TypedMessageAction += InvokeCallbacks;
            }
        }

        private void OnDisable()
        {
            foreach (TypedMessage<T> message in _messageArray)
            {
                message.TypedMessageAction -= InvokeCallbacks;
            }
        }

        private void InvokeCallbacks(T message)
        {
            _callbacks?.Invoke(message);
        }
    }
}