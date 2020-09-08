using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[Serializeable]
//public class InteractEvent : UnityEvent { };

public class Interactable : MonoBehaviour
{

	public bool AllowInteraction = true;


	public UnityEvent OnInteract;

	public bool Interact() {
		if( AllowInteraction )
			if( OnInteract != null ) {
				OnInteract.Invoke();
				return true;
			}

		return false;
	}
}
