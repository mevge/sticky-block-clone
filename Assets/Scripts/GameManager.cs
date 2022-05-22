using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerMovement playerMovement;
	public List<GameObject> collectedOpponentList;
	public Transform collectedOpponentsListTransform;
	public Material collectedObjsMat;
	public Transform particleEffect;

	public enum PlayerMovement
	{
		Move,
		Stop
	}

	public void MakeSphereFunction(){

		foreach (GameObject objs in collectedOpponentList){
			
			objs.GetComponent<OpponentManager>().CreateSphere();
		}
	}
}