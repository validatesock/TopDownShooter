using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class PlayerCharacter : Character
    {
        // Components
        [SerializeField]
        private Gun mCurrentGun;

        // Tunables
        [SerializeField]
        private float mVelocity = 10.0f;

        [SerializeField]
        private float mDashVelocity = 30.0f;

        [SerializeField]
        private float mDashTime = 0.2f;

        [SerializeField]
        private float mDashCooldown = 1.0f;

        // Dash 
        private bool mCanDash = true;
        private bool mIsDashing = false;
        private Vector3 mDashDir = Vector3.zero;
        private float mDashTicker = 0.0f;

        // Keep track of input
        private bool[] mInputDirectionStates = new bool[(int)MovementDirection.Count] { false, false, false, false };

        public override void Start()
        {
            VldateSck.InputManager.Instance.AddInputListener(OnMovementEvent);
            VldateSck.InputManager.Instance.AddInputListener(OnInputEvent);

            base.Start();
        }

        void OnDestroy()
        {
            VldateSck.InputManager.Instance.RemoveInputListener(OnMovementEvent);
            VldateSck.InputManager.Instance.RemoveInputListener(OnInputEvent);
        }

        void FixedUpdate()
        {
            Vector3 curPos = transform.position;

            if (!mIsDashing)
            {
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
            }
            else
            {
                if (mDashTicker >= 0.0f)
                {
                    mDashTicker -= Time.fixedDeltaTime;
                    curPos += mDashDir * (mDashVelocity * Time.fixedDeltaTime);
                }
                else
                {
                    // End of DASH
                    mIsDashing = false;
                    mDashTicker = 0.0f;
                    StartCoroutine(DoDashCooldown());
                }
            }

            curPos.z = 0.0f;
            transform.position = curPos;
        }

        private void Dash()
        {
            Vector3 dashTarget = InputManager.Instance.MousePosition2D;
            mDashDir = dashTarget - transform.position;
            mDashDir = mDashDir.normalized;
            mIsDashing = true;
            mCanDash = false;
            mDashTicker = mDashTime;
        }

        private IEnumerator DoDashCooldown()
        {
            yield return new WaitForSeconds(mDashCooldown);
            mCanDash = true;
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

        private void OnInputEvent(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            switch (input)
            {
                case Input.InputLogical.SECONDARY_ACTION:
                    if(buttonDown)
                    {
                        mCurrentGun.ToggleFireMode();
                    }
                    break;
                case Input.InputLogical.UNIQUE_ACTION:
                    if(buttonDown)
                    {
                        if(!mIsDashing && mCanDash)
                        {
                            Dash();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}