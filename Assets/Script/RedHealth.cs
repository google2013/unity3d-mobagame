using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RedHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;
	public bool Victory;
	public Transform target;
	private Transform myTransform;
	public Text VictoryText;
	// Use this for initialization
	void Start () {
		VictoryText.text = "";
		Victory = false;
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
	}
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
	}
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1)){
			GameObject go = GameObject.FindGameObjectWithTag ("Player");
			target = go.transform;
			myTransform = transform;
			float distance = Vector3.Distance (target.position, myTransform.position);
			if(distance < 10){
				AddjustCurrentHealth(-5);
				VictoryText.text = "Redhost " + curHealth+ "%";
			}
			//Debug.Log("Health: " + curHealth );
			if(curHealth == 0){
				Victory = true;
				VictoryText.text = "Victory! Press R to play";
				Destroy(gameObject);
			}
		}
	}
}
