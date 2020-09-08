using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableCon : MonoBehaviour
{
	public static InteractableCon Instance;

	[SerializeField]
	private Interactable CurrHighlightedInteractable;

	public Material HighlightMat;

	private void Awake() {

		if( Instance == null )
			Instance = this;
		if( Instance != this )
			Destroy( gameObject );
		
	}

	public bool InteractWithCurrInteractable() {
		return CurrHighlightedInteractable.Interact();
	}

	public void HighlightInteractable( Interactable toHighlight ) {

		if( CurrHighlightedInteractable != null && CurrHighlightedInteractable != toHighlight ) {
			ClearHighlightedInteractable();
		}
		if( CurrHighlightedInteractable == null ) {
			DoHighlightInteractable( toHighlight );
			CurrHighlightedInteractable = toHighlight;
		}

	}



	private void DoHighlightInteractable( Interactable toHighlight ) {
		foreach( MeshRenderer mr in toHighlight.GetComponentsInChildren<MeshRenderer>() ) {
			mr.materials = mr.materials.Append( HighlightMat ).ToArray();
		}
	}
	private void UnHighlightInteractable( Interactable toUnHighlight ) {
		foreach( MeshRenderer mr in toUnHighlight.GetComponentsInChildren<MeshRenderer>() ) {
			mr.materials = mr.materials.Where( material => !material.name.Contains ( HighlightMat.name ) ).ToArray();
		}
	}

	internal void ClearHighlightedInteractable() {
		if( CurrHighlightedInteractable ) {
			UnHighlightInteractable( CurrHighlightedInteractable );
			CurrHighlightedInteractable = null;
		}
	}
}
