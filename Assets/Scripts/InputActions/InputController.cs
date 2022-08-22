// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""70e1b8b2-b78a-421a-a8e4-7a9cd3eedfd6"",
            ""actions"": [
                {
                    ""name"": ""OnPointerDown"",
                    ""type"": ""Button"",
                    ""id"": ""6a2cdfcc-f6de-4d73-82ec-a6d0750ba4cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnPointerUp"",
                    ""type"": ""Button"",
                    ""id"": ""29035e08-ed84-42ea-8520-fa677c1fba78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""PointerDeltaPosition"",
                    ""type"": ""Value"",
                    ""id"": ""a2abfc77-1be1-4cd5-addc-902425fa3fed"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d4949438-d840-466a-97f4-6442b1eabb33"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38ba512e-ac78-4ce4-8c75-303c77a53c68"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPointerDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bc00431-cf8d-48ce-9769-0776c9a2d7ec"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerDeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22d956f7-5202-4e1d-b3b3-2259755ae548"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PointerDeltaPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7700eb7a-2583-4ff2-9b3e-f25b06143adf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6de0c882-06c9-4ba7-b93b-3ed1c1d5fa3b"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPointerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_OnPointerDown = m_PlayerMovement.FindAction("OnPointerDown", throwIfNotFound: true);
        m_PlayerMovement_OnPointerUp = m_PlayerMovement.FindAction("OnPointerUp", throwIfNotFound: true);
        m_PlayerMovement_PointerDeltaPosition = m_PlayerMovement.FindAction("PointerDeltaPosition", throwIfNotFound: true);
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

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_OnPointerDown;
    private readonly InputAction m_PlayerMovement_OnPointerUp;
    private readonly InputAction m_PlayerMovement_PointerDeltaPosition;
    public struct PlayerMovementActions
    {
        private @InputController m_Wrapper;
        public PlayerMovementActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnPointerDown => m_Wrapper.m_PlayerMovement_OnPointerDown;
        public InputAction @OnPointerUp => m_Wrapper.m_PlayerMovement_OnPointerUp;
        public InputAction @PointerDeltaPosition => m_Wrapper.m_PlayerMovement_PointerDeltaPosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @OnPointerDown.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnPointerDown;
                @OnPointerDown.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnPointerDown;
                @OnPointerDown.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnPointerDown;
                @OnPointerUp.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnPointerUp;
                @OnPointerUp.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnPointerUp;
                @OnPointerUp.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnOnPointerUp;
                @PointerDeltaPosition.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPointerDeltaPosition;
                @PointerDeltaPosition.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPointerDeltaPosition;
                @PointerDeltaPosition.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPointerDeltaPosition;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnPointerDown.started += instance.OnOnPointerDown;
                @OnPointerDown.performed += instance.OnOnPointerDown;
                @OnPointerDown.canceled += instance.OnOnPointerDown;
                @OnPointerUp.started += instance.OnOnPointerUp;
                @OnPointerUp.performed += instance.OnOnPointerUp;
                @OnPointerUp.canceled += instance.OnOnPointerUp;
                @PointerDeltaPosition.started += instance.OnPointerDeltaPosition;
                @PointerDeltaPosition.performed += instance.OnPointerDeltaPosition;
                @PointerDeltaPosition.canceled += instance.OnPointerDeltaPosition;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnOnPointerDown(InputAction.CallbackContext context);
        void OnOnPointerUp(InputAction.CallbackContext context);
        void OnPointerDeltaPosition(InputAction.CallbackContext context);
    }
}
