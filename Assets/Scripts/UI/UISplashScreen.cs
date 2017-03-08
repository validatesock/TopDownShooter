using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class UISplashScreen : UIBaseScreen
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            VldateSck.InputManager.Instance.AddInputListener(OnInputEvent);
            base.Start();
        }

        void OnDestroy()
        {
            VldateSck.InputManager.Instance.RemoveInputListener(OnInputEvent);
        }

        public override void Update()
        {
            base.Update();
        }

        private void OnInputEvent(VldateSck.Input.InputLogical input, bool buttonDown)
        {
            switch (input)
            {
                default:
                    UIManager.Instance.TransitionToScreen(UIScreenId.MainMenu);
                    break;
            }
        }
    }
}