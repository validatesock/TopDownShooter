﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class UISettingsScreen : UIBaseScreen
    {
        public override void Awake()
        {
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
            List<InputButton> lButtons = new List<InputButton>();
            lButtons.Add(InputButton.A);
            UIManager.Instance.Prompts.SetLeftPrompts(lButtons);

            List<InputButton> rButtons = new List<InputButton>();
            rButtons.Add(InputButton.B);
            UIManager.Instance.Prompts.SetRightPrompts(rButtons);

            base.SetPrompts();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Shutdown()
        {
            UIManager.Instance.Prompts.ClearPrompts();
            base.Shutdown();
        }
    }
}