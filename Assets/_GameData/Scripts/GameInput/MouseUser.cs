using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._GameData.Scripts.GameInput
{
    public enum MouseButton
    {
        Left,
        Right
    }
    public class MouseUser : MonoBehaviour
    {
        private InputActions _inputActions;

        public Vector2 MousePosition { get; private set; }

        public Vector2 MouseInWorldPosition => Camera.main.ScreenToWorldPoint(MousePosition);

        private bool _isLeftMouseButtonPressed;
        private bool _isRightMouseButtonPressed;


        private void OnEnable()
        {
            _inputActions = new InputActions();
            _inputActions.Game.MousePosition.performed += OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed += OnPerformActionPerformed;
            _inputActions.Game.PerformAction.canceled += OnPerformActionCancelled;
            _inputActions.Game.CancelAction.performed += OnCancelActionPerformed;
            _inputActions.Game.CancelAction.canceled += OnCancelActionCancelled;
        }
        private void OnDisable()
        {
            _inputActions.Game.MousePosition.performed -= OnMousePositionPerformed;
            _inputActions.Game.PerformAction.performed -= OnPerformActionPerformed;
            _inputActions.Game.PerformAction.canceled -= OnPerformActionCancelled;
            _inputActions.Game.CancelAction.performed -= OnCancelActionPerformed;
            _inputActions.Game.CancelAction.canceled -= OnCancelActionCancelled;
        }
        private void OnMousePositionPerformed(InputAction.CallbackContext context)
        {
            MousePosition = context.ReadValue<Vector2>();
        }
        private void OnPerformActionPerformed(InputAction.CallbackContext context)
        {
            _isLeftMouseButtonPressed = true;
        }
        private void OnPerformActionCancelled(InputAction.CallbackContext context)
        {
            _isLeftMouseButtonPressed = false;
        }
        private void OnCancelActionPerformed(InputAction.CallbackContext context)
        {
            _isRightMouseButtonPressed = true;
        }
        private void OnCancelActionCancelled(InputAction.CallbackContext context)
        {
            _isRightMouseButtonPressed = false;
        }
        public bool IsMouseButtonPressed(MouseButton button)
        {
            return button == MouseButton.Left ? _isLeftMouseButtonPressed : _isRightMouseButtonPressed;
        }

    }
}