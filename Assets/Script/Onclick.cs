using UnityEngine;
using System.Collections;

public class Onclick : MonoBehaviour {
	//GameObject go = GameObject.FindGameObjectWithTag("Player"); 

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1)){		
			Debug.Log("Mouse is down");
		}
	}
}