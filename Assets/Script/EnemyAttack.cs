using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public GameObject target;
	public float attackTimer;
	public float coolDown;
	public GameObject skeleton;
	public Animation anim;
	// Use this for initialization
	
	void Start(){
		attackTimer = 0;
		coolDown = 2.0f;
		anim = skeleton.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	
	void Update(){
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if (attackTimer < 0)
			attackTimer = 0;
		
		if (attackTimer == 0){
			Attack();
			attackTimer = coolDown;
		}
		
		
	}
	
	private void Attack(){
		target = GameObject.FindGameObjectWithTag("Player");
		float distance = Vector3.Distance(target.transform.position, transform.position);
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
		Debug.DrawLine (target.transform.position, transform.position, Color.blue);
		//Debug.Log ("Attack Distance: " +target.transform.position );

		if (distance < 5f) {
			if (direction > 0){
				PlayerHealth eh = (PlayerHealth)target.GetComponent("PlayerHealth");
				eh.AddjustCurrentHealth(-5);
			}
		}
	}
}
