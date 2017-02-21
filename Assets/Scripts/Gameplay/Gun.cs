using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    /* ***************************************************************************
    * Class: Gun
    * Purpose: 
    * Usage: 
    *************************************************************************** */
    public class Gun : MonoBehaviour
    {
        #region SerializedFields
        [SerializeField]
        private GunType mGunType = GunType.None;

        [SerializeField]
        private AmmoType mAmmoType = AmmoType.None;

        [SerializeField]
        private VldateSck.Input.InputLogical mFireInput = Input.InputLogical.None;

        [SerializeField]
        private string mGunName = "NoGun";

        [SerializeField]
        private int mAmmoMax = 0;

        [SerializeField]
        private int mAmmoStart = 0;

        [SerializeField]
        private float mShotDelayMin = 0.5f;

        [SerializeField]
        private float mShotDelayStart = 1.0f;

        [SerializeField]
        private float mDamageMin = 1.0f;

        [SerializeField]
        private float mDamageMax = 10.0f;

        [SerializeField]
        private Transform mLaunchPoint;

        [SerializeField]
        private float mVelocity = 10.0f;

        [SerializeField]
        private Projectile mProjectTilePrefab;
        #endregion

        // Gun State
        private bool mCanFire = true;
        private bool mHasFired = false;
        private float mCurrentShotDelay = 0.0f;
        private float mShotDelayTicker = 0.0f;

        // Reticule
        private Vector3 mMousePositionWS = Vector3.zero;

        void Start()
        {
            Enable();
        }

        void OnDestroy()
        {
            Disable();
        }

        public void Enable()
        {
            mCurrentShotDelay = mShotDelayStart;
            VldateSck.InputManager.Instance.AddInputListener(OnInputEvent);
        }

        public void Disable()
        {
            VldateSck.InputManager.Instance.RemoveInputListener(OnInputEvent);
        }

        void FixedUpdate()
        {
            mMousePositionWS = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            mMousePositionWS.z = 0.0f;
            transform.right = mMousePositionWS - transform.position;
        }

        void Update()
        {
            if (!mCanFire && mHasFired)
            {
                mShotDelayTicker -= Time.deltaTime;
            }

            if (mHasFired && mShotDelayTicker <= 0.0f)
            {
                mCanFire = true;
                mHasFired = false;
                mShotDelayTicker = 0.0f;
            }
        }

        private void OnInputEvent(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            // Attempt to fire.
            if(input == mFireInput)
            {
                AttemptFire();
            }
        }

        public void AttemptFire()
        {
            if(mCanFire)
            {
                mCanFire = false;
                mHasFired = true;
                mShotDelayTicker = mCurrentShotDelay;
                // Fire.
                GameObject instantiatedPrefab = GameObject.Instantiate(mProjectTilePrefab.gameObject);
                if(instantiatedPrefab != null)
                {
                    instantiatedPrefab.transform.position = mLaunchPoint.position;
                    instantiatedPrefab.transform.rotation = mLaunchPoint.rotation;

                    Projectile projComp = instantiatedPrefab.GetComponent<Projectile>();

                    if(projComp != null)
                    {
                        // We actually have a bullet.
                        projComp.Fire(mVelocity, mDamageMin, mDamageMax);
                    }
                }
            }
        }
    }
}