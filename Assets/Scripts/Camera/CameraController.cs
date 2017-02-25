using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float mLerpFactor = 0.6f;

        private PlayerCharacter mPlayerCharacter;

        private float mCameraZ = 0.0f;

        void Awake()
        {
            mCameraZ = transform.position.z;
        }

        public void Initialize(PlayerCharacter playerCharacter)
        {
            mPlayerCharacter = playerCharacter;
        }

        void Update()
        {
            // Something with mouse position and character position..
            // Lerp this so it's smooth.
            // Position between the screen bounds and the player? Consider it a box that lerps to the central point.
            // for now
            Vector3 curPos = transform.position;

            Vector3 playerPos = mPlayerCharacter.transform.position;

            Vector3 newPos = Vector3.Lerp(curPos, playerPos, mLerpFactor * Time.fixedDeltaTime);

            newPos.z = mCameraZ;

            transform.position = newPos;
        }
    }
}

