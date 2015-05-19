using UnityEngine;
using System.Collections;

public class AxonTerm : MonoBehaviour {

	public float    depletionTime = 10.0f;
	public float    depletionTimer;

	public string   type = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (depletionTimer >= depletionTime) {
			GameObject drop = GameObject.Instantiate(Resources.Load("Prefabs/"+type), transform.position+(transform.forward*Random.Range(1.0f, 1.5f)), transform.rotation) as GameObject;
			Rigidbody rig   = drop.GetComponent<Rigidbody>();
			rig.AddTorque(Random.onUnitSphere*1.0f);
			rig.AddForce(Random.onUnitSphere*5.0f);
			depletionTimer = 0.0f;
		}
		depletionTimer += Time.deltaTime;
	}
}
