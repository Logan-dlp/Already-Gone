using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace AlreadyGone.Inputs
{
    using Extensions;
    using DesignPattern.Singletons;
    
    public class InputManager : MonoSingleton<InputManager>
    {
        private bool _isActiveInput;
        public bool IsActiveInput => _isActiveInput;
        
        private PlayerInput _currentPlayerInput;
        private bool _isVisibleCursor;

        private void OnEnable()
        {
            InputSystem.onBeforeUpdate += UpdateCursorVisibility;
        }

        private void OnDisable()
        {
            InputSystem.onBeforeUpdate -= UpdateCursorVisibility;
        }

        protected override void Awake()
        {
            base.Awake();
            
            _currentPlayerInput = FindFirstObjectByType<PlayerInput>();
            SetCursorVisibility(Instance._currentPlayerInput.currentActionMap.name == "UI");
        }

        private void UpdateCursorVisibility()
        {
            if (_isVisibleCursor)
            {
                switch (_currentPlayerInput.currentControlScheme)
                {
                    case "Keyboard":
                        EventSystem.current.SetSelectedGameObject(null);
                    
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        break;
                    case "Gamepad":
                        if (EventSystem.current.currentSelectedGameObject == null)
                            EventSystem.current.SetFirstGameObjectSelectable();
                    
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        break;
                }
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
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