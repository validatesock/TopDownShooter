using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class CharacterCollisionDetector : MonoBehaviour
    {
        [SerializeField]
        private Character mCharacter;

        private Collider2D mCollider;

        void Awake()
        {
            // validate
            Debug.Assert(Validate());
        }

        private bool Validate()
        {
            bool isValid = false;
            mCollider = GetComponent<Collider2D>();
            isValid = (mCollider != null && mCollider.isTrigger);          
            return isValid;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider != null)
            {
                // Figure out what kind of object collider is
                Projectile proj = collider.GetComponent<Projectile>();

                // We have a projectile
                if (proj != null)
                {
                    float damage = proj.Damage;
                    mCharacter.OnDamageRecieved(damage);
                }
            }
        }
    }
}