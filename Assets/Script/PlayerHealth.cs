using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth: MonoBehaviour {

	// Use this for initialization
	public int Victory ;
	public int score = 0;
	public int maxHealth = 100;
	public int curHealth = 100;
	public Text gameOverText;
	public float healthBarLength;
	public bool gameOver = false;
	public bool Win = false;
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;  
		gameOverText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
		if (curHealth == 0) {
			gameOverText.text = "Game Over! Press R to replay";
			gameOver = true;
		}
		if (score == Victory) {
			Win = true;
		}
	}
	public bool GameOver(){
		return gameOver;
	}
	
	void OnGUI(){
		GUI.Box(new Rect(10,10, healthBarLength, 20), curHealth + "/" + maxHealth);
		if (gameOver == true) {

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
