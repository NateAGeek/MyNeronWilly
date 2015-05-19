using UnityEngine;
using System.Collections;

public class Lazors : Ability {
	public string name = "Example";
	public string discription = "Example Type";
	
	private bool activated = false;
	private GameObject Entity;
	
	public Lazors(GameObject entity){
		Entity = entity;
	}
	
	public void OnActivate(){
		
	}
	
	public void Activate(){
		if(activated){
			OnActivate();
			activated = !activated;
		}
		//Update Code
		if(Input.GetButtonDown("Attack")){
			Object.Instantiate(Resources.Load("Prefabs/Lazor"), Entity.transform.position, Entity.transform.rotation);	
		}
	}
	
	public void OnCollisionEnter(Collision entityHit){
		
	}
	
	public void OnCollisionExit(Collision entityHit){
		
	}
	
	public void OnTriggerEnter(Collider entityHit){
		
	}
	public void OnTriggerExit(Collider entityHit){
		
	}
	
	public void OnOver(){
		
	}
	
	public void OnRemove(){
		
	}
}