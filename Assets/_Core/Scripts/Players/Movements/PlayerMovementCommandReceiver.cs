using UnityEngine;

namespace AlreadyGone.Players.Movements
{
    public class PlayerMovementCommandReceiver
    {
        public void ExecuteOperation(GameObject gameObject, 
                                        CharacterController controller, 
                                        Vector3 direction, 
                                        float speed)
        {
            Vector3 movement = gameObject.transform.forward * (direction.z * speed) 
                               + gameObject.transform.right * (direction.x * speed) 
                               + gameObject.transform.up * direction.y;
            
            controller.Move(movement * Time.fixedDeltaTime);
        }
    }
}