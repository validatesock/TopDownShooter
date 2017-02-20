using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    /* ***************************************************************************
    * Class: InputManager
    * Purpose: Manages inputs from all sources and pipes them through their respective 
    * Subsystems by using an input event delegate that said subsystem subscribes to.
    * Usage: This Singleton MonoBehaviour must be active in a scene. Add your input listener using
    * AddInputListener and remove it using RemoveInputListener
    *************************************************************************** */
    public class InputManager : Singleton<InputManager>
    {
        public delegate void OnInputEventDelegate(VldateSck.Input.InputLogical input, bool buttonDown);
        private static event OnInputEventDelegate InputEventDelegate;

        private MouseInteraction mMouseInteraction = null;

        public override void Awake()
        {
            // TODO: Make this something I can set logically.
            VldateSck.Input.InterfaceAbstraction.SetInputType(Input.InputType.KB_MOUSE);
            base.Awake();
        }

        public void Start()
        {
            // TODO: This shouldn't be in start. Have a bootstrap script that starts all managers.
            Initialize();
        }

        public void Initialize()
        {
            if(VldateSck.Input.InterfaceAbstraction.InputType == Input.InputType.KB_MOUSE)
            {
                mMouseInteraction = new VldateSck.MouseInteraction();
            }
        }

        private void InvokeDelegate(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            if(InputEventDelegate != null)
            {
                InputEventDelegate(input, buttonDown);
            }
        }

        void Update()
        {
            // Primary Action
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.PRIMARY_ACTION))
            {
                InvokeDelegate(Input.InputLogical.PRIMARY_ACTION, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.PRIMARY_ACTION))
            {
                InvokeDelegate(Input.InputLogical.PRIMARY_ACTION, false);
            }

            // Secondary Action
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.SECONDARY_ACTION))
            {
                InvokeDelegate(Input.InputLogical.SECONDARY_ACTION, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.SECONDARY_ACTION))
            {
                InvokeDelegate(Input.InputLogical.SECONDARY_ACTION, false);
            }

            // Menu
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.MENU))
            {
                InvokeDelegate(Input.InputLogical.MENU, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.MENU))
            {
                InvokeDelegate(Input.InputLogical.MENU, false);
            }

            // Back
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.BACK))
            {
                InvokeDelegate(Input.InputLogical.BACK, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.BACK))
            {
                InvokeDelegate(Input.InputLogical.BACK, false);
            }

            // Cancel
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.CANCEL))
            {
                InvokeDelegate(Input.InputLogical.CANCEL, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.CANCEL))
            {
                InvokeDelegate(Input.InputLogical.CANCEL, false);
            }

            // Navigation DPAD FORWARD
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.DPAD_FORWARD))
            {
                InvokeDelegate(Input.InputLogical.DPAD_FORWARD, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.DPAD_FORWARD))
            {
                InvokeDelegate(Input.InputLogical.DPAD_FORWARD, false);
            }

            // Navigation DPAD BACK
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.DPAD_BACK))
            {
                InvokeDelegate(Input.InputLogical.DPAD_BACK, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.DPAD_BACK))
            {
                InvokeDelegate(Input.InputLogical.DPAD_BACK, false);
            }

            // Navigation DPAD RIGHT
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.DPAD_RIGHT))
            {
                InvokeDelegate(Input.InputLogical.DPAD_RIGHT, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.DPAD_RIGHT))
            {
                InvokeDelegate(Input.InputLogical.DPAD_RIGHT, false);
            }

            // Navigation DPAD LEFT
            if (VldateSck.Input.InterfaceAbstraction.GetButtonDown(Input.InputLogical.DPAD_LEFT))
            {
                InvokeDelegate(Input.InputLogical.DPAD_LEFT, true);
            }

            if (VldateSck.Input.InterfaceAbstraction.GetButtonUp(Input.InputLogical.DPAD_LEFT))
            {
                InvokeDelegate(Input.InputLogical.DPAD_LEFT, false);
            }
        }

        public void AddInputListener(OnInputEventDelegate listener)
        {
            if(listener != null)
            {
                // Ensure we do not duplicate the listener.
                RemoveInputListener(listener);
                InputEventDelegate += listener;
            }
        }

        public void RemoveInputListener(OnInputEventDelegate listener)
        {
            if(listener != null)
            {
                InputEventDelegate -= listener;
            }
        }

        public override void OnDestroy()
        {
            mMouseInteraction = null;
            // TODO: Is there a better way to destroy the listeners?
            InputEventDelegate = null;
            base.OnDestroy();
        }
    }
}