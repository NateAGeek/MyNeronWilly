using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brain : MonoBehaviour {

	public int health = 100;

	public float    depletionTime = 10.0f;
	public float    depletionTimer;
	public Text     brainTextDisplay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (depletionTime < 10.0f) {
			if (depletionTimer >= depletionTime) {
				Debug.Log ("Damage to the brain! Health: "+health);
				Damage(1);
				brainTextDisplay.text = "Brain Health: "+health;
				depletionTimer = 0.0f;
			}
			depletionTimer += Time.deltaTime;
		}
	}

	public void incDepletionTime(float a){
		if (depletionTime > 2.0) {
			depletionTime -= a;
		}
	}
	
	public void decDepletionTime(float a){
		depletionTime += a;
	}

	public void Damage(int i){
		health -= i;
	}
}
