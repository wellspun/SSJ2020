using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterController ) )]
public class PlayerFirstPersonController : MonoBehaviour
{

	[Range( 0, 100 )]
	public float MoveSpeed = 1;
	[Range( 0, 1000 )]
	public float MouseYSpeed = 100;
	[Range( 0, 1000 )]
	public float MouseXSpeed = 100;

    //[Header( "Obj Refs" )]
    private CharacterController characterController;
	private Camera charCamera;


	private void Awake() {

		characterController = GetComponent<CharacterController>();
		charCamera = GetComponentInChildren<Camera>();

	}

	float vertRotation = 0;
	private void Update() {

		Vector3 moveVec = Input.GetAxis( "Vertical" ) * transform.forward + Input.GetAxis( "Horizontal" ) * transform.right;
		moveVec *= MoveSpeed;
		characterController.Move( moveVec * Time.deltaTime );


		float mouseMoveY = Input.GetAxis( "Mouse Y" ) * Time.deltaTime * MouseYSpeed;
		vertRotation -= mouseMoveY;
		vertRotation = Mathf.Clamp( vertRotation, -90, 90 );
		charCamera.transform.localRotation = Quaternion.Euler( vertRotation, 0, 0 );


		Vector3 mouseMoveXVec = Input.GetAxis( "Mouse X" ) * Vector3.up * Time.deltaTime * MouseXSpeed;
		transform.Rotate( mouseMoveXVec );
	}
}
