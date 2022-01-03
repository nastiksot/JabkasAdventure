// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Modules/InputModule/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""ButtonInput"",
            ""id"": ""d86c05ff-7311-4910-8cf0-945cb78fdf4f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9099fa78-3ef4-462d-b6c2-99e1cb7de54b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ee1a73ad-69ea-4814-9739-1a174afb585f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""91a8a472-94c6-40d8-a855-3e710d92a6df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""35b712b6-19d0-4fbd-9827-dcfa532d6e13"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""900c967e-d8c3-4501-893d-a3f3c5ac2522"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8024d779-4aea-4b52-b21b-24f5f51e70d0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ButtonInput
        m_ButtonInput = asset.FindActionMap("ButtonInput", throwIfNotFound: true);
        m_ButtonInput_Move = m_ButtonInput.FindAction("Move", throwIfNotFound: true);
        m_ButtonInput_Jump = m_ButtonInput.FindAction("Jump", throwIfNotFound: true);
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

    // ButtonInput
    private readonly InputActionMap m_ButtonInput;
    private IButtonInputActions m_ButtonInputActionsCallbackInterface;
    private readonly InputAction m_ButtonInput_Move;
    private readonly InputAction m_ButtonInput_Jump;
    public struct ButtonInputActions
    {
        private @PlayerInput m_Wrapper;
        public ButtonInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ButtonInput_Move;
        public InputAction @Jump => m_Wrapper.m_ButtonInput_Jump;
        public InputActionMap Get() { return m_Wrapper.m_ButtonInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ButtonInputActions set) { return set.Get(); }
        public void SetCallbacks(IButtonInputActions instance)
        {
            if (m_Wrapper.m_ButtonInputActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ButtonInputActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ButtonInputActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ButtonInputActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ButtonInputActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ButtonInputActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ButtonInputActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_ButtonInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public ButtonInputActions @ButtonInput => new ButtonInputActions(this);
    public interface IButtonInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
