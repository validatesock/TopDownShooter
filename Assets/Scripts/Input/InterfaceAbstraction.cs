using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    namespace Input
    {
        /// <summary>
        /// Provides an abstracted interface from input such that a game can simply ask for an input by logical name and get the correct output for 
        /// any number of input types.
        /// </summary>
        public class InterfaceAbstraction
        {
            private static readonly int LEFT_MOUSE_BUTTON = 0;
            private static readonly int RIGHT_MOUSE_BUTTON = 1;
            private static readonly int MIDDLE_MOUSE_BUTTON = 2;

            // Default to KB + MOUSE
            private static InputType sInputType = InputType.KB_MOUSE;
            public static InputType InputType { get { return sInputType; } }

            public static void SetInputType(InputType inputType)
            {
                sInputType = inputType;
            }

            public static bool GetButtonDown(InputLogical logicalInput)
            {
                bool isDown = false;
                isDown = GetButtonDownInternal(logicalInput);
                return isDown;
            }

            private static bool GetButtonDownInternal(InputLogical logicalInput)
            {
                bool isDown = false;
                switch(sInputType)
                {
                    case InputType.KB_MOUSE:
                        isDown = GetButtonDownKBM(logicalInput);
                        break;
                    case InputType.XBOX_CONTROLLER:
                        isDown = GetButtonDownXBOX(logicalInput);
                        break;
                    default:
                        Debug.LogError("Not supported input yet.");
                        break;
                }
                return isDown;
            }

            public static bool GetButtonUp(InputLogical logicalInput)
            {
                bool isUp = false;
                isUp = GetButtonUpInternal(logicalInput);
                return isUp;
            }

            private static bool GetButtonUpInternal(InputLogical logicalInput)
            {
                bool isUp = false;
                switch (sInputType)
                {
                    case InputType.KB_MOUSE:
                        isUp = GetButtonUpKBM(logicalInput);
                        break;
                    case InputType.XBOX_CONTROLLER:
                        isUp = GetButtonUpXBOX(logicalInput);
                        break;
                    default:
                        Debug.LogError("Not supported input yet.");
                        break;
                }
                return isUp;
            }

            private static bool GetButtonDownKBM(InputLogical logicalInput)
            {
                bool isDown = false;

                switch (logicalInput)
                {
                    case InputLogical.PRIMARY_ACTION:
                        isDown = UnityEngine.Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON);
                        break;
                    case InputLogical.SECONDARY_ACTION:
                        isDown = UnityEngine.Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON);
                        break;
                    case InputLogical.CONFIRM:
                        isDown = UnityEngine.Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON) || UnityEngine.Input.GetKeyDown(KeyCode.Return);
                        break;
                    case InputLogical.BACK:
                        isDown = UnityEngine.Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON) || UnityEngine.Input.GetKeyDown(KeyCode.Escape);
                        break;
                    case InputLogical.MENU:
                        isDown = UnityEngine.Input.GetMouseButtonDown(MIDDLE_MOUSE_BUTTON) || UnityEngine.Input.GetKeyDown(KeyCode.Tab);
                        break;
                    case InputLogical.CANCEL:
                        isDown = UnityEngine.Input.GetKeyDown(KeyCode.Escape);
                        break;
                    case InputLogical.UNIQUE_ACTION:
                        isDown = UnityEngine.Input.GetKeyDown(KeyCode.Space);
                        break;
                    case InputLogical.DPAD_FORWARD:
                        isDown = UnityEngine.Input.GetKeyDown(KeyCode.W);
                        break;
                    case InputLogical.DPAD_BACK:
                        isDown = UnityEngine.Input.GetKeyDown(KeyCode.S);
                        break;
                    case InputLogical.DPAD_LEFT:
                        isDown = UnityEngine.Input.GetKeyDown(KeyCode.A);
                        break;
                    case InputLogical.DPAD_RIGHT:
                        isDown = UnityEngine.Input.GetKeyDown(KeyCode.D);
                        break;
                    default:
                        Debug.LogError("Unsupported input: " + logicalInput);
                        isDown = false;
                        break;
                }

                return isDown;
            }

            private static bool GetButtonDownXBOX(InputLogical logicalInput)
            {
                return false;
            }

            private static bool GetButtonUpKBM(InputLogical logicalInput)
            {
                bool isUp = false;

                switch (logicalInput)
                {
                    case InputLogical.PRIMARY_ACTION:
                        isUp = UnityEngine.Input.GetMouseButtonUp(LEFT_MOUSE_BUTTON);
                        break;
                    case InputLogical.SECONDARY_ACTION:
                        isUp = UnityEngine.Input.GetMouseButtonUp(RIGHT_MOUSE_BUTTON);
                        break;
                    case InputLogical.CONFIRM:
                        isUp = UnityEngine.Input.GetMouseButtonUp(LEFT_MOUSE_BUTTON) || UnityEngine.Input.GetKeyUp(KeyCode.Return);
                        break;
                    case InputLogical.BACK:
                        isUp = UnityEngine.Input.GetMouseButtonUp(RIGHT_MOUSE_BUTTON) || UnityEngine.Input.GetKeyUp(KeyCode.Escape);
                        break;
                    case InputLogical.MENU:
                        isUp = UnityEngine.Input.GetMouseButtonUp(MIDDLE_MOUSE_BUTTON) || UnityEngine.Input.GetKeyUp(KeyCode.Tab);
                        break;
                    case InputLogical.CANCEL:
                        isUp = UnityEngine.Input.GetKeyUp(KeyCode.Escape);
                        break;
                    case InputLogical.UNIQUE_ACTION:
                        isUp = UnityEngine.Input.GetKeyUp(KeyCode.Space);
                        break;
                    case InputLogical.DPAD_FORWARD:
                        isUp = UnityEngine.Input.GetKeyUp(KeyCode.W);
                        break;
                    case InputLogical.DPAD_BACK:
                        isUp = UnityEngine.Input.GetKeyUp(KeyCode.S);
                        break;
                    case InputLogical.DPAD_LEFT:
                        isUp = UnityEngine.Input.GetKeyUp(KeyCode.A);
                        break;
                    case InputLogical.DPAD_RIGHT:
                        isUp = UnityEngine.Input.GetKeyUp(KeyCode.D);
                        break;
                    default:
                        Debug.LogError("Unsupported input: " + logicalInput);
                        isUp = false;
                        break;
                }

                return isUp;
            }

            private static bool GetButtonUpXBOX(InputLogical logicalInput)
            {
                return false;
            }
        }
    }
}