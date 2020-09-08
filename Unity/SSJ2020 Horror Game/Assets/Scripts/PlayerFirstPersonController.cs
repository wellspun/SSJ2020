using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( CharacterController ) )]
public class PlayerFirstPersonController : MonoBehaviour
{

	[Header( "Mouse Movement" )]
	[Range( 0, 100 )]
	public float MoveSpeed = 1;
	[Range( 0, 1000 )]
	public float MouseYSpeed = 100;
	[Range( 0, 1000 )]
	public float MouseXSpeed = 100;

	[Header( "Player Interaction" )]
	[Range( 0, 10 )]
	public float InteractionRange = 2;


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


		RaycastHit[] interactablesHit = Physics.RaycastAll( charCamera.ViewportPointToRay( new Vector3( .5f, .5f ) ), InteractionRange, 1 << LayerController.InteractableLayer );
		if( interactablesHit.Length > 0 ) {

			foreach( RaycastHit rayHit in interactablesHit ) {
				Interactable interactableHit = rayHit.collider.gameObject.GetComponentInParent<Interactable>();
				if( interactableHit == null ) {
					Debug.LogError( "Interactable collider hit but no Interactable script, error" );
					continue;
				}
				if( !interactableHit.AllowInteraction )
					continue;

				InteractableCon.Instance.HighlightInteractable( interactableHit );
			}

		} else {
			InteractableCon.Instance.ClearHighlightedInteractable();
		}
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		if( Application.isPlaying )
			Gizmos.DrawRay( charCamera.ViewportPointToRay( new Vector3( .5f, .5f ) ) );
	}
}
