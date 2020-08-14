using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpinner : MonoBehaviour
{

	[Range( 0, 100 )]
	public float SpinSpeed = 5;
	private void Update() {
		transform.rotation = Quaternion.AngleAxis( SpinSpeed * Time.deltaTime, Vector3.up ) * transform.rotation;
	}

}
