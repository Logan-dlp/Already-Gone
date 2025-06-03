using System;
using UnityEngine;

namespace AlreadyGone.DesignPattern.Observers
{
    public class Message : ScriptableObject
    {
        public Action MessageAction { get; set; }

        public void Notify()
        {
            MessageAction?.Invoke();
        }
    }
}