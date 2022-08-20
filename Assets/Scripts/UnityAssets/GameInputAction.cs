//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/Scripts/UnityAssets/GameInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LyeJam
{
    public partial class @GameInputAction : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameInputAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputAction"",
    ""maps"": [
        {
            ""name"": ""Throw"",
            ""id"": ""24702c35-e376-4cf3-a3c5-4e6e307a8067"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""d54fe150-805b-423b-99db-94e7e42a0ecf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""f011694e-c145-4142-ae95-37c746650919"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2b03ad9-6570-44f6-b825-81e804cde604"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50a2e1a4-4ca7-4591-a65c-e215414ba4c5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Throw
            m_Throw = asset.FindActionMap("Throw", throwIfNotFound: true);
            m_Throw_MouseClick = m_Throw.FindAction("MouseClick", throwIfNotFound: true);
            m_Throw_MouseMove = m_Throw.FindAction("MouseMove", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Throw
        private readonly InputActionMap m_Throw;
        private IThrowActions m_ThrowActionsCallbackInterface;
        private readonly InputAction m_Throw_MouseClick;
        private readonly InputAction m_Throw_MouseMove;
        public struct ThrowActions
        {
            private @GameInputAction m_Wrapper;
            public ThrowActions(@GameInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @MouseClick => m_Wrapper.m_Throw_MouseClick;
            public InputAction @MouseMove => m_Wrapper.m_Throw_MouseMove;
            public InputActionMap Get() { return m_Wrapper.m_Throw; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ThrowActions set) { return set.Get(); }
            public void SetCallbacks(IThrowActions instance)
            {
                if (m_Wrapper.m_ThrowActionsCallbackInterface != null)
                {
                    @MouseClick.started -= m_Wrapper.m_ThrowActionsCallbackInterface.OnMouseClick;
                    @MouseClick.performed -= m_Wrapper.m_ThrowActionsCallbackInterface.OnMouseClick;
                    @MouseClick.canceled -= m_Wrapper.m_ThrowActionsCallbackInterface.OnMouseClick;
                    @MouseMove.started -= m_Wrapper.m_ThrowActionsCallbackInterface.OnMouseMove;
                    @MouseMove.performed -= m_Wrapper.m_ThrowActionsCallbackInterface.OnMouseMove;
                    @MouseMove.canceled -= m_Wrapper.m_ThrowActionsCallbackInterface.OnMouseMove;
                }
                m_Wrapper.m_ThrowActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MouseClick.started += instance.OnMouseClick;
                    @MouseClick.performed += instance.OnMouseClick;
                    @MouseClick.canceled += instance.OnMouseClick;
                    @MouseMove.started += instance.OnMouseMove;
                    @MouseMove.performed += instance.OnMouseMove;
                    @MouseMove.canceled += instance.OnMouseMove;
                }
            }
        }
        public ThrowActions @Throw => new ThrowActions(this);
        public interface IThrowActions
        {
            void OnMouseClick(InputAction.CallbackContext context);
            void OnMouseMove(InputAction.CallbackContext context);
        }
    }
}
