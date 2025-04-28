using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace AlreadyGone.Inputs
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;
        public static InputManager Instance => _instance;

        private bool _isActiveInput;
        public bool IsActiveInput => _isActiveInput;
        
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
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            _instance._currentPlayerInput = FindFirstObjectByType<PlayerInput>();
            SetCursorVisibility(_currentPlayerInput.currentActionMap.name == "UI");
        }

        private void OnInputDeviceChanged()
        {
            switch (_currentPlayerInput.currentControlScheme)
            {
                case "Keyboard":
                    EventSystem.current.SetSelectedGameObject(null);
                    Cursor.visible = _isVisibleCursor;
                    Cursor.lockState = _isVisibleCursor ? CursorLockMode.None : CursorLockMode.Locked;
                    break;
                case "Gamepad":
                    if (EventSystem.current.currentSelectedGameObject == null)
                        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
                    
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

        public void SetCursorVisibility(bool isVisibility)
        {
            _isVisibleCursor = isVisibility;
        }

        public void EnableInput()
        {
            _currentPlayerInput.ActivateInput();
            _isActiveInput = true;
        }

        public void DisableInput()
        {
            _currentPlayerInput.DeactivateInput();
            _isActiveInput = false;
        }
    }
}