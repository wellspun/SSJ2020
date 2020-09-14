using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

	private Animator anim;

	private void Awake() {
		anim = GetComponent<Animator>();
	}

	public void OpenCloseDoor() {
		anim.SetTrigger( "OpenCloseDoor" );
	}
}
