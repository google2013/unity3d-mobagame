using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxDistance;
	public GameObject Gold;
	private Transform myTransform;


	public float attackTimer;
	public float coolDown;
	

	
	void Awake(){
		myTransform = transform;
		
	}
	
	// Use this for initialization
	
	void Start(){
		maxDistance = 3;
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		attackTimer = 0;
		coolDown = 2.0f;
	}
	void AttackTower(GameObject tower){
		GreenHealth Gr = (GreenHealth)tower.GetComponent ("GreenHealth");
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if (attackTimer < 0)
			attackTimer = 0;

		if (attackTimer == 0){
			// Attack tower
			Gr.AddjustCurrentHealth (-2);
			attackTimer = coolDown;
		}
	}
	
	// Update is called once per frame
	void Update(){
		float distance = Vector3.Distance (target.position, myTransform.position);
		if (distance > maxDistance && distance < 25) {
			//Debug.Log("Move towards target ===========>");
			//Look at the target
			Debug.DrawLine (target.position, myTransform.position, Color.yellow);
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		} else {
			GameObject[] green = GameObject.FindGameObjectsWithTag("Green");
			bool hastower = false;
			foreach (GameObject tower in green) {
				Debug.DrawLine (tower.transform.position, myTransform.position, Color.black);
				if(Vector3.Distance(tower.transform.position, myTransform.position) < 20){
					myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation (tower.transform.position - myTransform.position), rotationSpeed * Time.deltaTime);
					myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
					hastower = true;
					AttackTower(tower);
				}
			}
			if(hastower == false){
				Debug.DrawLine (Gold.transform.position, myTransform.position, Color.red);
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation (Gold.transform.position - myTransform.position), rotationSpeed * Time.deltaTime);
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			}
		}
	}
}
