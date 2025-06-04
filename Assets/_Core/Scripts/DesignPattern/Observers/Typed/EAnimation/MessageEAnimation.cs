using UnityEngine;

namespace AlreadyGone.DesignPattern.Observers.Typed.EAnimation
{
    [CreateAssetMenu(fileName = "new_" + nameof(MessageEAnimation), menuName = "Messages/String")]
    public class MessageEAnimation : TypedMessage<Animations.EAnimations>
    { }
}