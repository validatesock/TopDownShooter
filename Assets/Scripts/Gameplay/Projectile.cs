using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    /* ***************************************************************************
    * Class: Projectile
    * Purpose: 
    * Usage: 
    *************************************************************************** */
    public class Projectile : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField]
        private float mColliderRadius = 1.0f;

        [SerializeField]
        private float mShotDuration = 1.5f;
        #endregion

        // Components
        private CircleCollider2D mColliderComp;

        // Projectile State
        private float mDamage = 0.0f;
        public float Damage { get { return mDamage; } }
        private float mVelocity = 0.0f;
        private bool mIsFired = false;
        private float mShotDurationTicker = 0.0f;

        void Awake()
        {
            mColliderComp = GetComponent<CircleCollider2D>();
            Debug.Assert(mColliderComp != null);

            // Set our tunable radius
            if(mColliderComp != null)
            {
                mColliderComp.radius = mColliderRadius;
            }
        }

        void FixedUpdate()
        {
            if (mIsFired)
            {
                if (mShotDurationTicker >= 0.0f)
                {

                    mShotDurationTicker -= Time.fixedDeltaTime;
                    Vector3 curPos = transform.position;

                    curPos += transform.right * (mVelocity * Time.fixedDeltaTime);
                    curPos.z = 0.0f;

                    transform.position = curPos;
                }
                else
                {
                    // End of BULLET.
                    mIsFired = false;
                    mShotDurationTicker = 0.0f;
                    Destroy();
                }

            }
        }

        public void Fire(float velocity, float damageMin, float damageMax)
        {
            // Determine our damage.
            mDamage = Random.Range(damageMin, damageMax);
            mVelocity = velocity;
            mIsFired = true;
            mShotDurationTicker = mShotDuration;
        }

        private void Destroy()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
