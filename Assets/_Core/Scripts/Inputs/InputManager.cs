using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenIt.Inputs
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;
        public static InputManager Instance => _instance;
        
        private PlayerInput _currentPlayerInput;
        private InputDevices _currentDevice;
        private bool _isVisibleCursor;

        private void OnEnable()
        {
            InputSystem.onBeforeUpdate += OnInputDeviceChanged;
        }

        private void OnDisable()
        {
            InputSystem.onBeforeUpdate -= OnInputDeviceChanged;
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            
            _instance._currentPlayerInput = FindFirstObjectByType<PlayerInput>();
        }

        private void OnInputDeviceChanged()
        {
            switch (_currentPlayerInput.currentControlScheme)
            {
                case "Keyboard":
                    Cursor.visible = _isVisibleCursor;
                    Cursor.lockState = _isVisibleCursor ? CursorLockMode.None : CursorLockMode.Locked;
                    break;
                case "Gamepad":
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
            }
        }

        public void ChangeActionMap(string mappingName)
        {
            if (_currentPlayerInput.actions.FindActionMap(mappingName) != null)
            {
                _currentPlayerInput.SwitchCurrentActionMap(mappingName);
            }
            else
            {
                Debug.LogError($"No mapping found for {mappingName}.");
            }
        }

        public void SetCusorVisibility(bool isVisibility)
        {
            _isVisibleCursor = isVisibility;
        }
    }
}