using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceBase : MonoBehaviour {

	public enum Type
	{
		Normal=0,Activatable=1, Fillable=2
	}

	public Type MType{
		get{ 
			return mType;}
	}
	[SerializeField]
	protected Type mType;

	public GameObject MGameObject{
		get{ 
			return mGameobject;
		}
	}
	protected GameObject mGameobject;

	public Transform MTransform{
		get{ 
			return mTransform;
		}
	}
	protected Transform mTransform;

	void Awake()
	{
		mTransform = transform;
		mGameobject = gameObject;
	}
}
