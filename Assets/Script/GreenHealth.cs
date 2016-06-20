using UnityEngine;
using System.Collections;

public class GreenHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
		//Debug.Log("Green: " + curHealth );
		if(curHealth == 0){
			Destroy(gameObject);
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
	}
}
