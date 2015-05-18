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
			hit.gameObject.GetComponent<PlayerObjectScript>().EnableDisplayPrompt("Pick Up Dopamine by pressing \"A\".");

		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.tag == "Player") {
			hit.gameObject.GetComponent<PlayerObjectScript>().DisableDisplayPrompt();
		}
	}
}
