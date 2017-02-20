using UnityEngine;
using System.Collections;
/* ****************************************************************************
 * Class: MouseInteractable
 * Purpose: Abstract class used to enforce MouseInteractable behaviour.
 * Usage: Implement OnMouseInteraction in object
 *************************************************************************** */
namespace VldateSck
{
	public abstract class MouseInteractable : MonoBehaviour 
	{
		public abstract void OnMouseInteraction (VldateSck.Input.InputLogical input, bool buttonDown);
	}
}