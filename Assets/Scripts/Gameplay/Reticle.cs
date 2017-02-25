using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VldateSck
{
    public class Reticle : MonoBehaviour
    {
        void FixedUpdate()
        {
            transform.position = InputManager.Instance.MousePosition2D;
        }

        public void Disable()
        {

        }

        public void Enable()
        {

        }
    }
}