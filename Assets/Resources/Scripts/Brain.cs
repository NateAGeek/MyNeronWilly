using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour {

	public float health = 100.0f;

	public float    depletionTime = 0.0f;
	public float    depletionTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (depletionTime > 0.0f) {
			Debug.Log ("Brain is Dep Time"+depletionTime);
			if (depletionTimer >= depletionTime) {
				Debug.Log ("Damage to the brain! Health: "+health);
				Damage(1.0f);
				depletionTimer = 0.0f;
			}
			depletionTimer += Time.deltaTime;
		}
	}

	public void incDepletionTime(float a){
		depletionTime -= a;
	}
	
	public void decDepletionTime(float a){
		depletionTime += a;
	}

	public void Damage(float i){
		health -= i;
	}
}
