using UnityEngine;
using System.Collections;

public class Dopamine : MonoBehaviour, NeurotransmitterInterface {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Player") {
			PlayerObjectScript player = hit.gameObject.GetComponent<PlayerObjectScript>();
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.tag == "Player") {
			PlayerObjectScript player = hit.gameObject.GetComponent<PlayerObjectScript>();
		}
	}
}
