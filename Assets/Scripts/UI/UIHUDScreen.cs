using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class UIHUDScreen : UIBaseScreen
    {
        [SerializeField]
        private UnityEngine.UI.Text mHealthCounter;

        [SerializeField]
        private UnityEngine.UI.Text mStaminaCounter;

        public override void Awake()
        {
            VSEventManager.Instance.AddListener<HealthChangedEvent>(HandleHealthChangedEvent);
            VSEventManager.Instance.AddListener<StaminaChangedEvent>(HandleStaminaChangedEvent);
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void SetPrompts()
        {
            //List<InputButton> lButtons = new List<InputButton>();
            //lButtons.Add(InputButton.A);
            //UIManager.Instance.Prompts.SetLeftPrompts(lButtons);

            //List<InputButton> rButtons = new List<InputButton>();
            //rButtons.Add(InputButton.B);
            //UIManager.Instance.Prompts.SetRightPrompts(rButtons);

            base.SetPrompts();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        private void HandleHealthChangedEvent(HealthChangedEvent hce)
        {
            if(hce.Character == GameManager.Instance.PlayerCharacter)
            {
                mHealthCounter.text = hce.Health.ToString();
            }
        }

        private void HandleStaminaChangedEvent(StaminaChangedEvent sce)
        {
            if (sce.Character == GameManager.Instance.PlayerCharacter)
            {
                mStaminaCounter.text = sce.Stamina.ToString();
            }
        }

        public override void Shutdown()
        {
            //UIManager.Instance.Prompts.ClearPrompts();
            VSEventManager.Instance.RemoveListener<HealthChangedEvent>(HandleHealthChangedEvent);
            VSEventManager.Instance.RemoveListener<StaminaChangedEvent>(HandleStaminaChangedEvent);
            base.Shutdown();
        }
    }
}