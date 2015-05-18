using UnityEngine;
using System.Collections;

public class LazorScript : MonoBehaviour {
	public float Speed = 0.5f;
	public float lifeTime = 10.0f;
	public Vector3 initVelocity;
	private float aliveTime = 0.0f;
	
	// Use this for initialization
	void Start () {
		aliveTime = 0.0f;
		GetComponent<Rigidbody>().velocity = transform.forward * Speed;
	}
	
	// Update is called once per frame
	void Update () {
		aliveTime += Time.deltaTime;
		if (aliveTime >= lifeTime) {
			Destroy(gameObject);		
		}
	}
	
	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Agonist") {
			AgonistInterface ag = hit.gameObject.GetComponent<AgonistInterface>();
			ag.Damage(10);
		}
	}
}
