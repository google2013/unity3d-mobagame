using UnityEngine;
using System.Collections;

public class SamuraiController : MonoBehaviour {
	public Animation anim;
	private PlayerHealth eh;
	private RedHealth rh ; 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		eh = (PlayerHealth)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerHealth");
		rh = (RedHealth) GameObject.FindGameObjectWithTag("Red").GetComponent("RedHealth");
		anim.Play ("idle");
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (rh.Victory);
		if (eh.GameOver () == false && rh.Victory == false) {
			Play ();
		} else {
			anim.Play ("idle");
			if (Input.GetKey(KeyCode.R)){
				Application.LoadLevel("scene2");
			}
		}
	}
	void Play(){
		if (Input.GetMouseButtonUp (1)) {
			anim.Play ("Attack");
		}
		if (Input.GetMouseButtonUp (0)) {
			anim.Play ("idle");
		}
		if (Input.GetKey (KeyCode.W)|| Input.GetKey (KeyCode.A)|| Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			anim.Play ("Run");
		}
		if (Input.GetKey (KeyCode.Space)) {
			anim.Play ("Jump");
		}
		if (Input.GetKeyUp (KeyCode.Space)||Input.GetKeyUp (KeyCode.W)|| Input.GetKeyUp (KeyCode.A)|| Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.D)) {
			anim.Play ("idle");
		}
	}
}
