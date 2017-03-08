using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class UIButtonInfo : MonoBehaviour
    {
        [SerializeField]
        private UINavigationType mNavType = UINavigationType.None;
        public UINavigationType NavType { get { return mNavType; } }

        [SerializeField]
        private UIScreenId mAdvanceScreen = UIScreenId.None;
        public UIScreenId AdvanceScreen { get { return mAdvanceScreen; } }

        private UnityEngine.UI.Button mButton;

        public void Awake()
        {
            mButton = GetComponent<UnityEngine.UI.Button>();
            Debug.Assert(mButton != null, "Button: " + name + " has no UIButton component");

            if (mButton != null)
            {
                mButton.onClick.AddListener(OnClick);
            }
        }

        public void OnClick()
        {
            UIManager.Instance.OnUIInput(this);
        }

        public void OnDestroy()
        {
            if(mButton != null)
            {
                mButton.onClick.RemoveListener(OnClick);
            }
        }
    }
}