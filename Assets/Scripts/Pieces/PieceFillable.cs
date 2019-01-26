using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFillable : PieceBase {


	public bool IsFilled{
		get{ 
			return isFilled;
		}
	}
	protected bool isFilled;

	[SerializeField]
	protected GameObject bodyFilled;
	[SerializeField]
	protected GameObject bodyUnfilled;

	public void Fill()
	{
		isFilled = true;
		bodyUnfilled.SetActive (false);
		bodyFilled.SetActive (true);
	}
}
