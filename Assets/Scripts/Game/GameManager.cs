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
        public PlayerCharacter PlayerCharacter { get { return mPlayerCharacter; } }

        [SerializeField]
        private GameObject mPlayerPrefab;

        private bool mIsInGamePlay = false;
        public bool IsInGamePlay { get { return mIsInGamePlay; } }

        public override void Awake()
        {
            base.Awake();
        }

        public void SetCameraController()
        {
            if(Camera.main != null)
            {
                CameraController cc = Camera.main.GetComponent<CameraController>();
                Debug.Assert(cc != null, "Camera Controller component is null or invalid.");
                if(cc != null)
                {
                    mCameraController = cc;
                    mCameraController.Initialize(mPlayerCharacter);
                }
            }
        }

        public void SpawnPlayer()
        {
            GameObject instantiatedPrefab = GameObject.Instantiate(mPlayerPrefab);
            if (instantiatedPrefab != null)
            {
                PlayerCharacter pc = instantiatedPrefab.GetComponent<PlayerCharacter>();
                Debug.Assert(pc != null, "Player Prefab is null or invalid.");
                if(pc != null)
                {
                    mPlayerCharacter = pc;
                }
            }
        }

        // Use this for initialization
        void Start()
        {

            UIManager.Instance.TransitionToScreen(UIScreenId.Splash);
        }

        public void StartGame()
        { 
            SpawnPlayer();
            SetCameraController();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

