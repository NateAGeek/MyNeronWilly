using UnityEngine;
using System.Collections;

public class MDMA : MonoBehaviour, AgonistInterface {

	private NavMeshAgent navAgent;
	private bool 		 frozen          	 = false;
	private bool 		 stunAfterAttack 	 = false;
	private float        stunAfterAttackTime = 0.0f;
	private int 		 health              = 100;


	private Rigidbody    rigidbody;
	public GameObject    ToBlock;

	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		navAgent  = GetComponent<NavMeshAgent>();
		navAgent.destination = ToBlock.transform.position;
		rigidbody.Sleep();
	}
	
	void Update () {
		if (stunAfterAttack) {
			stunAfterAttackTime += Time.deltaTime;
		}
		if (stunAfterAttackTime >= 1.0) {
			stunAfterAttack = false;
			stunAfterAttackTime = 0.0f;
			rigidbody.Sleep();
			navAgent.Resume();
		}
	}
	void FixedUpdate(){

	}

	public void pauseMovement(){
		navAgent.Stop();
		stunAfterAttack = true;
	}

	public void Damage(int amount){
		health -= amount;
		Debug.Log ("Health: "+health);
		if (health < 0) {
			navAgent.Stop();
			Destroy(gameObject);
		}
	}

	public void KnockBack(Vector3 dir){
		rigidbody.WakeUp();
		rigidbody.AddForce(dir*10, ForceMode.Impulse);
		pauseMovement();
	}

	void OnTriggerEnter(Collider hit){
		
	}

	void OnTriggerStay(Collider hit){
		if (hit.tag == "Player") {
			navAgent.destination = hit.transform.position;
		}	
	}

	void OnTriggerExit(Collider hit){
		navAgent.destination = ToBlock.transform.position;
	}
}
