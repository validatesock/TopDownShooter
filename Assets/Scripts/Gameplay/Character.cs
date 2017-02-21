using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private float mMaxHealth;
        public float MaxHealth { get { return mMaxHealth; } }

        [SerializeField]
        private float mMaxStamina;
        public float MaxStamina { get { return mMaxStamina; } }

        [SerializeField]
        private Gun mCurrentGun;

        void Start()
        {
            VldateSck.InputManager.Instance.AddInputListener(OnInputEvent);
        }

        void OnDestroy()
        {
            VldateSck.InputManager.Instance.RemoveInputListener(OnInputEvent);
        }

        private void OnInputEvent(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            // TODO: DO this!
        }
    }
}