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
        private FireType mFireType = FireType.Regular;

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
        private int mBurstCount = 3;

        [SerializeField]
        private float mBurstDelay = 0.1f;

        [SerializeField]
        private Projectile mProjectTilePrefab;
        #endregion

        // Gun State
        private bool mCanFire = true;
        private bool mFireButtonDown = false;

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
            VldateSck.InputManager.Instance.AddInputListener(OnInputEvent);
        }

        public void Disable()
        {
            VldateSck.InputManager.Instance.RemoveInputListener(OnInputEvent);
        }

        void FixedUpdate()
        {
            mMousePositionWS = InputManager.Instance.MousePosition2D;
            transform.right = mMousePositionWS - transform.position;
        }

        void Update()
        {
        }

        public void ToggleFireMode()
        {
            int curType = (int)mFireType;
            curType++;
            if(curType >= (int)FireType.Count)
            {
                curType = (int)FireType.First;
            }
            mFireType = (FireType)curType;

            mFireButtonDown = false;
        }

        private IEnumerator AutoFire()
        {
            while(mFireButtonDown)
            {
                mCanFire = false;
                DoFire();
                yield return new WaitForSeconds(mShotDelayStart);
            }
            mCanFire = true;
        }

        private IEnumerator BurstFire()
        {
            mCanFire = false;
            int burstCount = mBurstCount;
            while(burstCount > 0)
            {
                DoFire();
                yield return new WaitForSeconds(mBurstDelay);
                burstCount--;
            }
            yield return new WaitForSeconds(mShotDelayStart);
            mCanFire = true;
        }

        private IEnumerator RegularFire()
        {
            mCanFire = false;
            DoFire();
            yield return new WaitForSeconds(mShotDelayStart);
            mCanFire = true;
        }

        private void OnInputEvent(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            // Attempt to fire.
            if(input == mFireInput)
            {
                if(buttonDown)
                {
                    mFireButtonDown = true;
                    AttemptFire();
                }
                else
                {
                    mFireButtonDown = false;
                }
            }
        }

        public void AttemptFire()
        {
            if(mCanFire)
            {
                switch(mFireType)
                {
                    case FireType.Regular:
                        StartCoroutine(RegularFire());
                        break;
                    case FireType.Auto:
                        StartCoroutine(AutoFire());
                        break;
                    case FireType.Burst:
                        StartCoroutine(BurstFire());
                        break;
                }

            }
        }

        private void DoFire()
        {
            GameObject instantiatedPrefab = GameObject.Instantiate(mProjectTilePrefab.gameObject);
            if (instantiatedPrefab != null)
            {
                instantiatedPrefab.transform.position = mLaunchPoint.position;
                instantiatedPrefab.transform.rotation = mLaunchPoint.rotation;

                Projectile projComp = instantiatedPrefab.GetComponent<Projectile>();

                if (projComp != null)
                {
                    // We actually have a bullet.
                    projComp.Fire(mVelocity, mDamageMin, mDamageMax);
                }
            }
        }
    }
}