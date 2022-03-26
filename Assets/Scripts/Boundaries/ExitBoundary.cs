using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D collider){
		if(collider.CompareTag("Platform") || collider.CompareTag("Background")){
			Destroy (collider.gameObject);
		}
	}
}
