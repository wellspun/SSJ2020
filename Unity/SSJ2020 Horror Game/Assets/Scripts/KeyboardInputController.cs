using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : MonoBehaviour
{
	[Header( "Default Keyboard Controls" )]
	public KeyCode InteractKC = KeyCode.E;

	private void Update() {

		if( Input.GetKeyDown( InteractKC ) ) {
			InteractableCon.Instance.InteractWithCurrInteractable();
		}
		
	}
}
