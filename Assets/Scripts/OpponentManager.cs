using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour {

	GameManager gameManager;
	public Transform sphere;

	void Start () {
		
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		sphere = transform.GetChild(0);
		gameManager.collectedOpponentList.Add(gameObject); 
		
		if(GetComponent<Rigidbody>() == null){
			
			gameObject.AddComponent<Rigidbody>();
			Rigidbody myRigidboy = GetComponent<Rigidbody>();
			myRigidboy.constraints = RigidbodyConstraints.FreezeAll;
			myRigidboy.useGravity = false;
			
			this.GetComponent<Renderer>().material = gameManager.collectedObjsMat;
		}
		
	}
	

	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Opponent"){

			other.gameObject.tag = "Player";
			other.transform.parent = gameManager.collectedOpponentsListTransform;
			gameManager.collectedOpponentList.Add(other.gameObject);
			other.gameObject.AddComponent<OpponentManager>();
		}
		
		if(other.gameObject.tag == "Obstacle"){
			gameManager.collectedOpponentList.Remove(gameObject);
			DestroyObjects();
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "OpponentList"){
			
			other.transform.parent = gameManager.collectedOpponentsListTransform;

			foreach (Transform Player in other.transform){
				if(!gameManager.collectedOpponentList.Contains(Player.gameObject)){

					gameManager.collectedOpponentList.Add(Player.gameObject);
					Player.gameObject.tag = "Player";
					Player.gameObject.AddComponent<OpponentManager>();
			}
		}
	}	

	if(other.gameObject.tag == "FinishStick"){

		gameManager.MakeSphereFunction();
	}
}

	
	void DestroyObjects(){
		gameManager.collectedOpponentList.Remove(gameObject);
		Destroy(gameObject);

		Transform particle = Instantiate(gameManager.particleEffect, transform.position, Quaternion.identity);
		particle.GetComponent<ParticleSystem>().startColor = gameManager.collectedObjsMat.color;
	}

	public void CreateSphere(){

		gameObject.GetComponent<BoxCollider>().enabled = false;
		gameObject.GetComponent<MeshRenderer>().enabled = false;

		sphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
		sphere.gameObject.GetComponent<SphereCollider>().enabled = true;
		sphere.gameObject.GetComponent<SphereCollider>().isTrigger = true;
		
		sphere.gameObject.GetComponent<Renderer>().material = gameManager.collectedObjsMat;
	}

	public void DropObjs(){

		sphere.gameObject.layer = 8;

		sphere.gameObject.GetComponent<SphereCollider>().isTrigger = false;
		sphere.gameObject.AddComponent<Rigidbody>();
		sphere.GetComponent<Rigidbody>().useGravity = true;
	}
}
