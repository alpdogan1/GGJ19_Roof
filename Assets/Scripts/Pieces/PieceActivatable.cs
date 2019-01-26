using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceActivatable : PieceBase {

	[SerializeField]
	private PieceBase[] hiddenPieces;


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.X)) {
			Activate ();
		}

	}
	public void Activate()
	{
		StartCoroutine (ActivationRoutine());
	}
	IEnumerator ActivationRoutine()
	{
		foreach (PieceNormal piece in hiddenPieces) {

			piece.MeshRenderer.enabled = true;
			piece.IsMovableOnto = true;
			yield return new WaitForSeconds (0.03f);

		}
	}
}
