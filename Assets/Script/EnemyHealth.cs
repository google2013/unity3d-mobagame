using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;
	public float healthBarLength;
	public Transform target;
	private Transform myTransform;
	private PlayerHealth eh;
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2; 
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
		eh = (PlayerHealth)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerHealth");
	}
	void OnGUI(){
		GUI.Box(new Rect(10, 40, healthBarLength, 20), curHealth + "/" + maxHealth);
	}
	void OnMouseOver(){
		if(Input.GetMouseButtonDown(1) && eh.GameOver() == false){
			GameObject go = GameObject.FindGameObjectWithTag ("Player");
			target = go.transform;
			myTransform = transform;
			float distance = Vector3.Distance (target.position, myTransform.position);
			if(distance < 10){
				AddjustCurrentHealth(-10);
			}
			Debug.Log("Health: " + curHealth );
			if(curHealth == 0){
				Destroy(gameObject);
			}
		}
	}
	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;
		
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
