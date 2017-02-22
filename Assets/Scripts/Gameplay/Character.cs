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
    }
}