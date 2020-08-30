using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	static GameController Instance;

	private void Awake() {

		if( Instance == null )
			Instance = this;
		if( Instance != this )
			Destroy( gameObject );
		
	}
}
