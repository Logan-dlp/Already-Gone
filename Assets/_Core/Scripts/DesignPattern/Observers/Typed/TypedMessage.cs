using System;
using UnityEngine;

namespace AlreadyGone.DesignPattern.Observers.Typed
{
    public abstract class TypedMessage<T> : ScriptableObject
    {
        public Action<T> TypedMessageAction { get; set; }

        public void Notify(T message)
        {
            TypedMessageAction?.Invoke(message);
        }
    }
}