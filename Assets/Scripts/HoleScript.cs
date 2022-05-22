using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Untagged"){

			other.transform.parent.GetComponent<OpponentManager>().DropObjs();
		}
	}
}
