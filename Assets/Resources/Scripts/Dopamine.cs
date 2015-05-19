using UnityEngine;
using System.Collections;

public class Dopamine : MonoBehaviour, NeurotransmitterInterface {

	private string name = "Dopamine";

	private PlayerObjectScript playerRef;

	// Use this for initialization
	void Start () {
		playerRef = GameObject.Find ("Player").GetComponent<PlayerObjectScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit){
		if (hit.tag == "Player") {
			playerRef.EnableDisplayPrompt("Pick Up Dopamine by pressing \"A\".");
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.tag == "Player") {
			playerRef.DisableDisplayPrompt();
		}
	}

	void OnDestroy(){
		playerRef.DisableDisplayPrompt();
	}

	public string getName(){
		return name;
	}
}
