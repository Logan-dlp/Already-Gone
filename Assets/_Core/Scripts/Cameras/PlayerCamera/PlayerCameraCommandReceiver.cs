using UnityEngine;

namespace AlreadyGone.Camera.PlayerCamera
{
    public class PlayerCameraCommandReceiver
    {
        public void ExecuteOperation(GameObject gameObject, Vector2 direction, float sensitivity)
        {
            gameObject.transform.parent.Rotate(direction.x * Time.fixedDeltaTime * sensitivity * Vector3.up);

            float horizontalMovement = gameObject.transform.localEulerAngles.x - direction.y * Time.fixedDeltaTime * sensitivity;

            if (horizontalMovement <= 90) horizontalMovement = horizontalMovement > 0 ? Mathf.Clamp(horizontalMovement, 0, 85) : horizontalMovement;
            if (horizontalMovement > 270) horizontalMovement = Mathf.Clamp(horizontalMovement, 275, 360);
            
            gameObject.transform.localEulerAngles = Vector3.right * horizontalMovement;
        }
    }
}