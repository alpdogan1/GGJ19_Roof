using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceNormal : PieceBase {


	public bool IsMovableOnto{
		get{ 
			return isMovableOnto;
		}
		set{ 
			isMovableOnto = value;
		}
	}
	[SerializeField]
	protected bool isMovableOnto;

	public MeshRenderer MeshRenderer{
		get{ 
			return meshRenderer;
		}
	}
	[SerializeField]
	protected MeshRenderer meshRenderer;

	void Start()
	{
	


	}
}
