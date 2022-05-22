using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public GameManager gameManager;
	public float controlSpeed, movementSpeed;
	float posX;
	bool isTouching;

	void Update() {
		
		GetInput();  // Calling method of GetInput in Update Method.
	}

	void FixedUpdate() {
		
		if(gameManager.playerMovement == GameManager.PlayerMovement.Move){               // Accessing to Enum from GameManager.
 
			transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;             
		}
		if(isTouching){                                                                  // Input, "touching" position receiving here. 

			posX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;       // X axis movement in here.
		}

		transform.position = new Vector3(posX, transform.position.y, transform.position.z);
	}

	void GetInput(){
		
		if(Input.GetMouseButton(0)){
			
			isTouching = true;
		}else {
			
			isTouching = false;
		}
	}
}
