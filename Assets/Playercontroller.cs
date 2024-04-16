//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Playercontroller.inputactions
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

public partial class @Playercontroller: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Playercontroller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Playercontroller"",
    ""maps"": [
        {
            ""name"": ""Character controls"",
            ""id"": ""f4e77dc8-c36f-49af-bb05-18da376952f5"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1a19cab8-cb8d-4a93-9f60-e8403b851269"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""f51652ef-72ed-4d23-8667-7497d5b949ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""00da7793-f7b8-410b-8df6-37c330ac1e4d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e8f5377-36ca-4b26-b752-fe5389021e40"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character controls
        m_Charactercontrols = asset.FindActionMap("Character controls", throwIfNotFound: true);
        m_Charactercontrols_Movement = m_Charactercontrols.FindAction("Movement", throwIfNotFound: true);
        m_Charactercontrols_Run = m_Charactercontrols.FindAction("Run", throwIfNotFound: true);
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

    // Character controls
    private readonly InputActionMap m_Charactercontrols;
    private List<ICharactercontrolsActions> m_CharactercontrolsActionsCallbackInterfaces = new List<ICharactercontrolsActions>();
    private readonly InputAction m_Charactercontrols_Movement;
    private readonly InputAction m_Charactercontrols_Run;
    public struct CharactercontrolsActions
    {
        private @Playercontroller m_Wrapper;
        public CharactercontrolsActions(@Playercontroller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Charactercontrols_Movement;
        public InputAction @Run => m_Wrapper.m_Charactercontrols_Run;
        public InputActionMap Get() { return m_Wrapper.m_Charactercontrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharactercontrolsActions set) { return set.Get(); }
        public void AddCallbacks(ICharactercontrolsActions instance)
        {
            if (instance == null || m_Wrapper.m_CharactercontrolsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharactercontrolsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
        }

        private void UnregisterCallbacks(ICharactercontrolsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
        }

        public void RemoveCallbacks(ICharactercontrolsActions instance)
        {
            if (m_Wrapper.m_CharactercontrolsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharactercontrolsActions instance)
        {
            foreach (var item in m_Wrapper.m_CharactercontrolsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharactercontrolsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharactercontrolsActions @Charactercontrols => new CharactercontrolsActions(this);
    public interface ICharactercontrolsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
