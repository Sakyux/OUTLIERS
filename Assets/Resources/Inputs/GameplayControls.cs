//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/GameplayControls.inputactions
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

public partial class @GameplayControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameplayControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameplayControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""0891b258-4dff-4972-823a-b48ea19df143"",
            ""actions"": [
                {
                    ""name"": ""Cross"",
                    ""type"": ""Button"",
                    ""id"": ""774f2d48-f30b-45f6-a4e8-ccaac24d5a37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Square"",
                    ""type"": ""Button"",
                    ""id"": ""c57364c4-16bc-4a0b-a52f-a2d23105bf27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Triangle"",
                    ""type"": ""Button"",
                    ""id"": ""24d7ef9b-c669-405c-b07b-f0310f4cae13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Circle"",
                    ""type"": ""Button"",
                    ""id"": ""34b228ee-fba3-45fb-9aab-3483b9fd82ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpArrow"",
                    ""type"": ""Button"",
                    ""id"": ""f2b5bb2f-2ddd-4058-9351-6c3293d1665b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DownArrow"",
                    ""type"": ""Button"",
                    ""id"": ""7e0ea8a2-87f0-4e5a-a3e9-ae52201a2087"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftArrow"",
                    ""type"": ""Button"",
                    ""id"": ""4757a99d-cc59-431e-8003-f26d2b849b99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightArrow"",
                    ""type"": ""Button"",
                    ""id"": ""4b556b94-7263-46d1-8705-8595f81ec19b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftButton"",
                    ""type"": ""Button"",
                    ""id"": ""26f33818-dee5-47d5-902c-d83d4fa11a24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightButton"",
                    ""type"": ""Button"",
                    ""id"": ""ea262129-634e-4b1a-8c7d-ea2a86ffe2f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""a9c8932d-daef-4b8c-b8dd-8bac329cf66c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""2da8b831-728c-4055-9b61-b93eec287fc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc67ffa5-8349-4f78-82e8-b18173e15020"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cross"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f41e3548-de02-45de-8d43-288f9998a544"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Square"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""965a5bbf-6bdb-4046-907a-cb23bf8a65ab"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e004ebc9-7b86-4284-89bb-3e6b9a3955de"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Circle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""959104fb-b102-43d3-bfba-fe348a7a73f8"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3a603dd-beef-4a61-9ab7-595e44a1eabb"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f17289b0-562a-4408-9d61-b8ae9e33f17f"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21e884a3-7a57-4d99-a0f1-f335f833ce2d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightArrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d4253d1-8560-4328-88b3-fd1d7c920444"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50ef1d95-66b6-4c6a-8337-498cb41e1833"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a36b86da-41a6-4817-b503-00d22db28642"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1920c911-4188-4637-9ae5-9dd8e2e02e4c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Cross = m_Gameplay.FindAction("Cross", throwIfNotFound: true);
        m_Gameplay_Square = m_Gameplay.FindAction("Square", throwIfNotFound: true);
        m_Gameplay_Triangle = m_Gameplay.FindAction("Triangle", throwIfNotFound: true);
        m_Gameplay_Circle = m_Gameplay.FindAction("Circle", throwIfNotFound: true);
        m_Gameplay_UpArrow = m_Gameplay.FindAction("UpArrow", throwIfNotFound: true);
        m_Gameplay_DownArrow = m_Gameplay.FindAction("DownArrow", throwIfNotFound: true);
        m_Gameplay_LeftArrow = m_Gameplay.FindAction("LeftArrow", throwIfNotFound: true);
        m_Gameplay_RightArrow = m_Gameplay.FindAction("RightArrow", throwIfNotFound: true);
        m_Gameplay_LeftButton = m_Gameplay.FindAction("LeftButton", throwIfNotFound: true);
        m_Gameplay_RightButton = m_Gameplay.FindAction("RightButton", throwIfNotFound: true);
        m_Gameplay_LeftTrigger = m_Gameplay.FindAction("LeftTrigger", throwIfNotFound: true);
        m_Gameplay_RightTrigger = m_Gameplay.FindAction("RightTrigger", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Cross;
    private readonly InputAction m_Gameplay_Square;
    private readonly InputAction m_Gameplay_Triangle;
    private readonly InputAction m_Gameplay_Circle;
    private readonly InputAction m_Gameplay_UpArrow;
    private readonly InputAction m_Gameplay_DownArrow;
    private readonly InputAction m_Gameplay_LeftArrow;
    private readonly InputAction m_Gameplay_RightArrow;
    private readonly InputAction m_Gameplay_LeftButton;
    private readonly InputAction m_Gameplay_RightButton;
    private readonly InputAction m_Gameplay_LeftTrigger;
    private readonly InputAction m_Gameplay_RightTrigger;
    public struct GameplayActions
    {
        private @GameplayControls m_Wrapper;
        public GameplayActions(@GameplayControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cross => m_Wrapper.m_Gameplay_Cross;
        public InputAction @Square => m_Wrapper.m_Gameplay_Square;
        public InputAction @Triangle => m_Wrapper.m_Gameplay_Triangle;
        public InputAction @Circle => m_Wrapper.m_Gameplay_Circle;
        public InputAction @UpArrow => m_Wrapper.m_Gameplay_UpArrow;
        public InputAction @DownArrow => m_Wrapper.m_Gameplay_DownArrow;
        public InputAction @LeftArrow => m_Wrapper.m_Gameplay_LeftArrow;
        public InputAction @RightArrow => m_Wrapper.m_Gameplay_RightArrow;
        public InputAction @LeftButton => m_Wrapper.m_Gameplay_LeftButton;
        public InputAction @RightButton => m_Wrapper.m_Gameplay_RightButton;
        public InputAction @LeftTrigger => m_Wrapper.m_Gameplay_LeftTrigger;
        public InputAction @RightTrigger => m_Wrapper.m_Gameplay_RightTrigger;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Cross.started += instance.OnCross;
            @Cross.performed += instance.OnCross;
            @Cross.canceled += instance.OnCross;
            @Square.started += instance.OnSquare;
            @Square.performed += instance.OnSquare;
            @Square.canceled += instance.OnSquare;
            @Triangle.started += instance.OnTriangle;
            @Triangle.performed += instance.OnTriangle;
            @Triangle.canceled += instance.OnTriangle;
            @Circle.started += instance.OnCircle;
            @Circle.performed += instance.OnCircle;
            @Circle.canceled += instance.OnCircle;
            @UpArrow.started += instance.OnUpArrow;
            @UpArrow.performed += instance.OnUpArrow;
            @UpArrow.canceled += instance.OnUpArrow;
            @DownArrow.started += instance.OnDownArrow;
            @DownArrow.performed += instance.OnDownArrow;
            @DownArrow.canceled += instance.OnDownArrow;
            @LeftArrow.started += instance.OnLeftArrow;
            @LeftArrow.performed += instance.OnLeftArrow;
            @LeftArrow.canceled += instance.OnLeftArrow;
            @RightArrow.started += instance.OnRightArrow;
            @RightArrow.performed += instance.OnRightArrow;
            @RightArrow.canceled += instance.OnRightArrow;
            @LeftButton.started += instance.OnLeftButton;
            @LeftButton.performed += instance.OnLeftButton;
            @LeftButton.canceled += instance.OnLeftButton;
            @RightButton.started += instance.OnRightButton;
            @RightButton.performed += instance.OnRightButton;
            @RightButton.canceled += instance.OnRightButton;
            @LeftTrigger.started += instance.OnLeftTrigger;
            @LeftTrigger.performed += instance.OnLeftTrigger;
            @LeftTrigger.canceled += instance.OnLeftTrigger;
            @RightTrigger.started += instance.OnRightTrigger;
            @RightTrigger.performed += instance.OnRightTrigger;
            @RightTrigger.canceled += instance.OnRightTrigger;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Cross.started -= instance.OnCross;
            @Cross.performed -= instance.OnCross;
            @Cross.canceled -= instance.OnCross;
            @Square.started -= instance.OnSquare;
            @Square.performed -= instance.OnSquare;
            @Square.canceled -= instance.OnSquare;
            @Triangle.started -= instance.OnTriangle;
            @Triangle.performed -= instance.OnTriangle;
            @Triangle.canceled -= instance.OnTriangle;
            @Circle.started -= instance.OnCircle;
            @Circle.performed -= instance.OnCircle;
            @Circle.canceled -= instance.OnCircle;
            @UpArrow.started -= instance.OnUpArrow;
            @UpArrow.performed -= instance.OnUpArrow;
            @UpArrow.canceled -= instance.OnUpArrow;
            @DownArrow.started -= instance.OnDownArrow;
            @DownArrow.performed -= instance.OnDownArrow;
            @DownArrow.canceled -= instance.OnDownArrow;
            @LeftArrow.started -= instance.OnLeftArrow;
            @LeftArrow.performed -= instance.OnLeftArrow;
            @LeftArrow.canceled -= instance.OnLeftArrow;
            @RightArrow.started -= instance.OnRightArrow;
            @RightArrow.performed -= instance.OnRightArrow;
            @RightArrow.canceled -= instance.OnRightArrow;
            @LeftButton.started -= instance.OnLeftButton;
            @LeftButton.performed -= instance.OnLeftButton;
            @LeftButton.canceled -= instance.OnLeftButton;
            @RightButton.started -= instance.OnRightButton;
            @RightButton.performed -= instance.OnRightButton;
            @RightButton.canceled -= instance.OnRightButton;
            @LeftTrigger.started -= instance.OnLeftTrigger;
            @LeftTrigger.performed -= instance.OnLeftTrigger;
            @LeftTrigger.canceled -= instance.OnLeftTrigger;
            @RightTrigger.started -= instance.OnRightTrigger;
            @RightTrigger.performed -= instance.OnRightTrigger;
            @RightTrigger.canceled -= instance.OnRightTrigger;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnCross(InputAction.CallbackContext context);
        void OnSquare(InputAction.CallbackContext context);
        void OnTriangle(InputAction.CallbackContext context);
        void OnCircle(InputAction.CallbackContext context);
        void OnUpArrow(InputAction.CallbackContext context);
        void OnDownArrow(InputAction.CallbackContext context);
        void OnLeftArrow(InputAction.CallbackContext context);
        void OnRightArrow(InputAction.CallbackContext context);
        void OnLeftButton(InputAction.CallbackContext context);
        void OnRightButton(InputAction.CallbackContext context);
        void OnLeftTrigger(InputAction.CallbackContext context);
        void OnRightTrigger(InputAction.CallbackContext context);
    }
}
