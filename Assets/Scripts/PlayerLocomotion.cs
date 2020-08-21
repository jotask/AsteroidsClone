// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerLocomotion.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerLocomotion : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerLocomotion()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerLocomotion"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""e4010193-f8a9-4e11-b4cb-63b07221fb6e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0c562b8e-f1ef-481e-8b14-a02844c21da2"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ca47a849-4ea0-4b28-bf68-a8641b42db3f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""774bd4be-bd43-46bd-8f6b-722f509e28b9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""09e3c198-e764-4011-a322-929d66f54306"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f24a0bad-bdce-40d9-be50-7b1301cf54e8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""36711453-2a8f-4c92-ad36-b79572056620"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4f276c01-6e5d-4de4-84e8-7293e7e10318"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerAction"",
            ""id"": ""5112b588-dd4a-489f-a32a-1992aad1c106"",
            ""actions"": [
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""e2d66c20-c245-48b5-a933-e53844741bcc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37d5e9d8-d2df-44b8-bffc-983bb337bf12"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eea96a7-bdb0-4ab2-82f5-941e541bbaea"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shot"",
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
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        // PlayerAction
        m_PlayerAction = asset.FindActionMap("PlayerAction", throwIfNotFound: true);
        m_PlayerAction_Shot = m_PlayerAction.FindAction("Shot", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerMovement_Movement;
    public struct PlayerMovementActions
    {
        private @PlayerLocomotion m_Wrapper;
        public PlayerMovementActions(@PlayerLocomotion wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerAction
    private readonly InputActionMap m_PlayerAction;
    private IPlayerActionActions m_PlayerActionActionsCallbackInterface;
    private readonly InputAction m_PlayerAction_Shot;
    public struct PlayerActionActions
    {
        private @PlayerLocomotion m_Wrapper;
        public PlayerActionActions(@PlayerLocomotion wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shot => m_Wrapper.m_PlayerAction_Shot;
        public InputActionMap Get() { return m_Wrapper.m_PlayerAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionActions instance)
        {
            if (m_Wrapper.m_PlayerActionActionsCallbackInterface != null)
            {
                @Shot.started -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_PlayerActionActionsCallbackInterface.OnShot;
            }
            m_Wrapper.m_PlayerActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
            }
        }
    }
    public PlayerActionActions @PlayerAction => new PlayerActionActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface IPlayerActionActions
    {
        void OnShot(InputAction.CallbackContext context);
    }
}
