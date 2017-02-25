using UnityEngine;
using System.Collections;

/* ***************************************************************************
 * Class: MouseInteraction
 * Purpose: Mouse Interaction Layer that listens to MouseInput events and finds the 
 * Mouse Interactable that the event was intended for. 
 * Usage: Create an instance of this class and imlement MouseInteracable in the class
 * you wish to recieve click events.
 *************************************************************************** */
namespace VldateSck
{
	public class MouseInteraction 
	{
		private static RaycastHit2D mHitInfo;

		public MouseInteraction()
		{
			VldateSck.InputManager.Instance.AddInputListener(OnMouseInteraction);
		}

		~MouseInteraction()
		{
            VldateSck.InputManager.Instance.RemoveInputListener(OnMouseInteraction);
        }

		static void OnMouseInteraction(VldateSck.Input.InputLogical input, bool buttonDown)
		{
			MouseInteractable interactable = null;
			if (MouseCast (out interactable)) 
			{
				if (interactable != null) 
				{
					interactable.OnMouseInteraction (input, buttonDown);
				}
			}
		}

		private static bool MouseCast(out MouseInteractable hitInteractable)
		{
			hitInteractable = null;
            mHitInfo = Physics2D.Raycast(InputManager.Instance.MousePosition2D, Vector2.zero);
            if(mHitInfo)
            {
                if (mHitInfo.collider != null) 
				{
					hitInteractable = mHitInfo.collider.GetComponent<MouseInteractable> ();
					return true;
				}
			}
			return false;
		}
	}
}