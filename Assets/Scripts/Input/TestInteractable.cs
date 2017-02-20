using UnityEngine;
using System.Collections;

public class TestInteractable : VldateSck.MouseInteractable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnMouseInteraction (VldateSck.Input.InputLogical input, bool buttonDown)
	{
		switch (input) {
            case VldateSck.Input.InputLogical.PRIMARY_ACTION:
			Debug.Log ("It's me!");
			break;
		}
	}
}
