//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Movement/MovementControler.inputactions
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

public partial class @MovementControler : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MovementControler()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MovementControler"",
    ""maps"": [
        {
            ""name"": ""PlayerMovementControler"",
            ""id"": ""6453bfa3-5a05-4d9d-90e8-6a77da236a74"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c10f706e-0efc-4841-8baf-dba640518b04"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ViewRotate"",
                    ""type"": ""Value"",
                    ""id"": ""f55ab1fa-947f-431a-a901-39797b8406d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""45fe19e1-6312-4eef-8d11-f42089afeaa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8ac9b57-4aeb-419a-afeb-40da0149472c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""ViewRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""acbe9b7d-d748-4b79-8dde-1f2d2473698e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a089494b-6832-4637-832c-7eb371cef804"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7dcebdd3-2cb1-424d-8c05-68b2722f1413"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9e049027-ff5a-4149-929f-9491909056d8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""742cd5ac-637c-464f-8ae6-ae5fc0888c27"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""202cb4ad-da3c-4934-86b5-4c058c3d24ee"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMovementControler
        m_PlayerMovementControler = asset.FindActionMap("PlayerMovementControler", throwIfNotFound: true);
        m_PlayerMovementControler_Move = m_PlayerMovementControler.FindAction("Move", throwIfNotFound: true);
        m_PlayerMovementControler_ViewRotate = m_PlayerMovementControler.FindAction("ViewRotate", throwIfNotFound: true);
        m_PlayerMovementControler_Jump = m_PlayerMovementControler.FindAction("Jump", throwIfNotFound: true);
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

    // PlayerMovementControler
    private readonly InputActionMap m_PlayerMovementControler;
    private IPlayerMovementControlerActions m_PlayerMovementControlerActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementControler_Move;
    private readonly InputAction m_PlayerMovementControler_ViewRotate;
    private readonly InputAction m_PlayerMovementControler_Jump;
    public struct PlayerMovementControlerActions
    {
        private @MovementControler m_Wrapper;
        public PlayerMovementControlerActions(@MovementControler wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMovementControler_Move;
        public InputAction @ViewRotate => m_Wrapper.m_PlayerMovementControler_ViewRotate;
        public InputAction @Jump => m_Wrapper.m_PlayerMovementControler_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementControler; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementControlerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementControlerActions instance)
        {
            if (m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnMove;
                @ViewRotate.started -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnViewRotate;
                @ViewRotate.performed -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnViewRotate;
                @ViewRotate.canceled -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnViewRotate;
                @Jump.started -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerMovementControlerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @ViewRotate.started += instance.OnViewRotate;
                @ViewRotate.performed += instance.OnViewRotate;
                @ViewRotate.canceled += instance.OnViewRotate;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerMovementControlerActions @PlayerMovementControler => new PlayerMovementControlerActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    public interface IPlayerMovementControlerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnViewRotate(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}