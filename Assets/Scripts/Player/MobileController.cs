using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

	public void OnPointerDown(PointerEventData data){
		if(gameObject.CompareTag("Left Button")){
			PlayerController.instance.MovePlayerLeft ();
		}

		if(gameObject.CompareTag("Right Button")){
			PlayerController.instance.MovePlayerRight ();
		}
	}

	public void OnPointerUp(PointerEventData data){
		PlayerController.instance.StopMoving ();
	}

}
