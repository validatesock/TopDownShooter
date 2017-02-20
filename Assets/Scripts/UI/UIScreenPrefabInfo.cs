using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    [System.Serializable]
    public class UIScreenPrefabInfo
    {
        [SerializeField]
        private UIScreenId mScreenId;
        public UIScreenId ScreenId { get { return mScreenId; } }

        [SerializeField]
        private GameObject mPrefab;
        public GameObject Prefab { get { return mPrefab; } }
    }
}
