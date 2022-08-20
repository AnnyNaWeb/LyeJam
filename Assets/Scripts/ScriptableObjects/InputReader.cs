using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

namespace LyeJam
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "LyeJam/Input Reader")]
    public class InputReader : ScriptableObject,
        GameInputAction.IThrowActions
    {
        public event Action<Vector2, float> OnSwipeEvent;
        public event Action<Vector2, float> OnDragEvent;
        public event Action OnResetEvent;
        public event Action OnPauseEvent;

        private GameInputAction _inputAction;
        private Vector2 _startTouchPosition;
        private Vector2 _fingerPos;
        private float _startTime;
        private bool _swipePressed = false;

        public void Initialize()
        {
            if (_inputAction == null)
            {
                _inputAction = new GameInputAction();
                _inputAction.Throw.SetCallbacks(this);
            }
            _inputAction.Enable();

            EnhancedTouchSupport.Enable();
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += OnFingerStartTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp += OnFingerEndTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove += OnFingerMove;
        }

        public void DisableReader()
        {
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= OnFingerStartTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerUp -= OnFingerEndTouch;
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerMove -= OnFingerMove;
            EnhancedTouchSupport.Disable();
        }

        public void Update()
        {
            if(_swipePressed)
            {
                OnDragEvent?.Invoke(_fingerPos, Time.time - _startTime);
            }
        }

        private void OnFingerStartTouch(Finger finger)
        {
            if (GameManager.Instance.isPaused) return;
            _startTouchPosition = finger.screenPosition;
            _startTime = Time.time;
            _swipePressed = true;
        }

        private void OnFingerEndTouch(Finger finger)
        {
            if (GameManager.Instance.isPaused) return;
            EndSwipe();
        }

        private void OnFingerMove(Finger finger)
        {
            if (GameManager.Instance.isPaused) return;
            if(_swipePressed)
            {
                _fingerPos = finger.screenPosition;
            }
        }

        private void EndSwipe()
        {
            _swipePressed = false;
            OnSwipeEvent?.Invoke(_fingerPos, Time.time - _startTime);
        }

        public void OnMouseClick(InputAction.CallbackContext context)
        {
            if (GameManager.Instance.isPaused) return;
            
            if(context.started)
            {
                _startTime = Time.time;
                _swipePressed = true;
            }
            else if (context.canceled)
            {
                EndSwipe();
            }
        }

        public void OnMouseMove(InputAction.CallbackContext context)
        {
            if (GameManager.Instance.isPaused) return;
            if(_swipePressed)
            {
                _fingerPos = context.ReadValue<Vector2>();
            }
        }

        public void OnReset(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnResetEvent?.Invoke();
            }
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnPauseEvent?.Invoke();
            }
        }
    }
}
