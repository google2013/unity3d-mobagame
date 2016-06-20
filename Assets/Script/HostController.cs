using UnityEngine;
using System.Collections;

public class HostController : MonoBehaviour {

	public GameObject creep;
	//public Vector3 spawnValues;
	public int creepCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	//private int score;
	//public GUIText scoreText;
	//public GUIText restartText;
	//public GUIText gameOverText;
	//private bool gameOver = false ;
	//private bool restart = false;
	// Use this for initialization
	void Start () {
		StartCoroutine ( SpawnCreep ());
	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator SpawnCreep ()//sinh ra doi tuong
	{
		yield return new WaitForSeconds(startWait);
		while (true) {
			for (int i= 0; i< creepCount; i++) {
				Vector3 spawnPosition = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
				//Random,range = ngau nhien;
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (creep, spawnPosition, spawnRotation);// tao hazard voi vi tri va goc quay
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			//if (gameOver) {
				//restartText.text ="Press R to restart!";
				//restart =true;
			//	break;
			//}
			
		}
	}

	//public void GameOver(){
	//	gameOver = true;
	//	gameOverText.text = "GameOver!";
	//}
}
