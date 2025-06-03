using UnityEngine;

namespace AlreadyGone.DesignPattern.Observers.Typed.Vector2
{
    [CreateAssetMenu(fileName = "new_" + nameof(MessageVector2), menuName = "Messages/Vector 2")]
    public class MessageVector2 : TypedMessage<UnityEngine.Vector2>
    { }
}