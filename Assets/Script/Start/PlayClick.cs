using UnityEngine;
using System.Collections;

public class PlayClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			Debug.Log("Quit");
			Application.Quit();
		}
	
	}
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Application.LoadLevel ("fps");
		}
	}

}
