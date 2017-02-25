using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private CameraController mCameraController;

        [SerializeField]
        private PlayerCharacter mPlayerCharacter;

        // Use this for initialization
        void Start()
        {
            mCameraController.Initialize(mPlayerCharacter);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

