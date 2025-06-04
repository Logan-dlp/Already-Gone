using System;
using UnityEngine;

namespace AlreadyGone.DesignPattern.Observers
{
    [CreateAssetMenu(fileName = "new_" + nameof(Message), menuName = "Messages/Void")]
    public class Message : ScriptableObject
    {
        public Action MessageAction { get; set; }

        public void Notify()
        {
            MessageAction?.Invoke();
        }
    }
}