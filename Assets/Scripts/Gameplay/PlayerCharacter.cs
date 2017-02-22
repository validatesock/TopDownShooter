using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class PlayerCharacter : Character
    {
        [SerializeField]
        private Gun mCurrentGun;

        [SerializeField]
        private float mVelocity = 10.0f;

        // Keep track of inpuit
        private bool[] mInputDirectionStates = new bool[(int)MovementDirection.Count] { false, false, false, false };

        void Start()
        {
            VldateSck.InputManager.Instance.AddInputListener(OnMovementEvent);
        }

        void OnDestroy()
        {
            VldateSck.InputManager.Instance.RemoveInputListener(OnMovementEvent);
        }

        void FixedUpdate()
        {
            Vector3 curPos = transform.position;

            if (mInputDirectionStates[(int)MovementDirection.Forward])
            {
                curPos += transform.up * (mVelocity * Time.fixedDeltaTime);
            }
            if (mInputDirectionStates[(int)MovementDirection.Backward])
            {
                curPos -= transform.up * (mVelocity * Time.fixedDeltaTime);
            }
            if (mInputDirectionStates[(int)MovementDirection.Left])
            {
                curPos -= transform.right * (mVelocity * Time.fixedDeltaTime);
            }
            if (mInputDirectionStates[(int)MovementDirection.Right])
            {
                curPos += transform.right * (mVelocity * Time.fixedDeltaTime);
            }

            curPos.z = 0.0f;

            transform.position = curPos;
        }

        private void OnMovementEvent(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            // If we have movement input
            if (input >= Input.InputLogical.MOVEMENT_START && input <= Input.InputLogical.MOVEMENT_END)
            {
                switch(input)
                {
                    case Input.InputLogical.DPAD_FORWARD:
                        mInputDirectionStates[(int)MovementDirection.Forward] = buttonDown;
                        break;
                    case Input.InputLogical.DPAD_BACK:
                        mInputDirectionStates[(int)MovementDirection.Backward] = buttonDown;
                        break;
                    case Input.InputLogical.DPAD_LEFT:
                        mInputDirectionStates[(int)MovementDirection.Left] = buttonDown;
                        break;
                    case Input.InputLogical.DPAD_RIGHT:
                        mInputDirectionStates[(int)MovementDirection.Right] = buttonDown;
                        break;
                    default:
                        Debug.LogError("Character movement event handler should not get here.");
                        break;
                }
            }
        }
    }
}