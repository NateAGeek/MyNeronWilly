using UnityEngine;
using System.Collections;

public class Dendrite : MonoBehaviour {

	/*
	 * 
	 * Issues: Dude timers are off...? 
	 * 
	 * 
	 */

	//Needed to be set GameObjects
	public TextMesh text;
	public float    depletionTime = 10.0f;
	public float    depletionTimer;
	public GameObject TheBrain;

	//Public vars
	public string type = "None";

	//Private vars
	private Camera ActiveCamera;
	private int    charge = 10;
	private bool   WarnedBrain = false;

	private Brain  TheBrainComp;

	// Use this for initialization
	void Start () {
		TheBrainComp = TheBrain.GetComponent<Brain>();
		text.text = type + ": " + charge;
	}
	
	// Update is called once per frame
	void Update () {
		if (depletionTimer >= depletionTime) {
			Deplete(1);
			depletionTimer = 0.0f;
		}
		depletionTimer += Time.deltaTime;
	}

	void FixedUpdate(){
		if (charge < 0 && !WarnedBrain) {
			TheBrainComp.incDepletionTime(1.0f);
			WarnedBrain = true;
		}
		if (charge > 0 && WarnedBrain) {
			TheBrainComp.decDepletionTime(1.0f);
			WarnedBrain = false;
		}
		
	}

	void OnTriggerEnter(Collider hit){
		if (hit.gameObject.tag == "Agonist") {
			incDepletionTime(0.25f);
		}	
	}

	void OnTriggerExit(Collider hit){
		if (hit.gameObject.tag == "Agonist") {
			decDepletionTime(0.25f);
		}	
	}

	public string getType(){
		return type;
	}

	public void Deplete(int d){
		charge -= d;
		text.text = type + ": " + charge;
		if (charge < 0) {
			TheBrainComp.incDepletionTime(1.0f);
		}
	}

	//To charge the dendrite, feeding so it does not die out...
	public void Charge(int c){
		charge += c;
		text.text = type + ": " + charge;
		Debug.Log("Charging type("+type+") value:"+charge);
		if (charge < 0 && WarnedBrain) {
			TheBrainComp.Damage(1);
			TheBrainComp.decDepletionTime(1.0f);
		}
	}

	public void incDepletionTime(float a){
		depletionTime -= a;
	}

	public void decDepletionTime(float a){
		depletionTime += a;
	}

}
