using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class Character : MonoBehaviour
    {
        // Tunables
        [SerializeField]
        protected float mMaxHealth;
        public float MaxHealth { get { return mMaxHealth; } }

        [SerializeField]
        protected float mMaxStamina;
        public float MaxStamina { get { return mMaxStamina; } }

        protected float mCurrentHealth;
        protected float mCurrentStamina;

        protected CharacterState mCharacterState;

        public virtual void Start()
        {
            // TODO: This should be called in an enemy / character factory.
            Initialize();
        }

        public virtual void Initialize()
        {
            SetHealth(mMaxHealth);
            SetStamina(mMaxStamina);

            mCharacterState = CharacterState.Alive;
        }
        
        public virtual void SetHealth(float value)
        {
            mCurrentHealth = value;
            mCurrentHealth = Mathf.Clamp(mCurrentHealth, 0.0f, mMaxHealth);
            HealthChangedEvent evt = new HealthChangedEvent(this, mCurrentHealth);
            VSEventManager.Instance.TriggerEvent(evt);
            Debug.Log("Character: " + name + " now has a health total of: " + mCurrentHealth);
        }

        public virtual void SetStamina(float value)
        {
            mCurrentStamina = value;
            mCurrentStamina = Mathf.Clamp(mCurrentStamina, 0.0f, mMaxStamina);
            StaminaChangedEvent evt = new StaminaChangedEvent(this, mCurrentStamina);
            VSEventManager.Instance.TriggerEvent(evt);
            Debug.Log("Character: " + name + " now has a stamina total of: " + mCurrentStamina);
        }

        public virtual void OnDamageRecieved(float damage)
        {
            ApplyDamage(damage);

            // TODO: Below is a hack. Remove it with proper damage handling.
            if (mCurrentHealth <= 0)
            {
                // kill!
                Debug.Log("I Died!");
                GameObject.Destroy(this.gameObject);
            }
        }

        protected virtual void ApplyDamage(float damage)
        {
            if(mCharacterState == CharacterState.Alive)
            {
                if(mCurrentHealth > 0)
                {
                    SetHealth(mCurrentHealth - damage);
                }
            }
        }

        protected virtual void UseStamina(float stamina)
        {
            // TODO!
        }
    }
}