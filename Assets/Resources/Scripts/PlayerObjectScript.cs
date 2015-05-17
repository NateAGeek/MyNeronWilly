using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerObjectScript: MonoBehaviour{

	//Public Prefrancese
	public Vector2    sensitivity       = new Vector2(10.0f, 10.0f);
	public float      speed             = 5.0f;
	public float      jumpVelocity      = 5.0f;
	public GameObject GameHUDCanvas;

	//Component Vars
	private Rigidbody rigidbody;
	private Camera    camera;

	// Movement Vars
	private Vector2   rotationMin       = new Vector2(-360.0f, -60.0f);
	private Vector2   rotationMax       = new Vector2(360.0f, 60.0f);
	private Vector3   rotation          = new Vector3(0.0f, 0.0f, 0.0f);
	private bool      onGround          = true;
	private bool      hitSomethingInAir = false;
	private bool      freeze            = false;
	

    void Start() {
		camera = GetComponentInChildren<Camera>();
		rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {

		//Check if frozen for movment and other abilities to be active
		if (!freeze) {
			//Do the Calculations for rotation
			rotation.x += Input.GetAxis ("Mouse X") * sensitivity.x;
			rotation.y += Input.GetAxis ("Mouse Y") * sensitivity.y;
			rotation.y = Mathf.Clamp (rotation.y, rotationMin.y, rotationMax.y);

			transform.localEulerAngles = new Vector3 (0.0f, rotation.x, 0.0f);
			camera.transform.localEulerAngles = new Vector3 (-rotation.y, 0.0f, 0.0f);

			//Movement Controls
			if (!hitSomethingInAir) {
				Vector3 targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
				targetVelocity = transform.TransformDirection (targetVelocity);
				targetVelocity = new Vector3 (targetVelocity.x * speed, rigidbody.velocity.y, targetVelocity.z * speed);
				Vector3 velocityChange = targetVelocity - rigidbody.velocity;

				rigidbody.AddForce (velocityChange, ForceMode.VelocityChange);
			}
			if (Input.GetButtonDown ("Crouch")) {
				transform.localScale -= new Vector3 (0.0f, 0.25f, 0.0f);
			}
			if (Input.GetButtonUp ("Crouch")) {
				transform.localScale += new Vector3 (0.0f, 0.25f, 0.0f);
			}
			if (Input.GetButtonDown ("Sprint")) {
				this.speed = 10f;
			}
			if (Input.GetButtonUp ("Sprint")) {
				this.speed = 5f;
			}
			if (onGround && Input.GetButtonDown ("Jump")) {
				rigidbody.AddForce (transform.up * jumpVelocity, ForceMode.VelocityChange);
			}
		}
		
	}
	
	void FixedUpdate() {
		
	}

    void OnCollisionEnter(Collision hit) {

		//If we hit a wall or something while in the air, should begin to ignore velocity vectors
		if (!onGround && hit.collider.tag == "Untagged") {
			hitSomethingInAir = true;
		}
    }

	void OnCollisionStay(Collision hit){

		//If we are on the ground we have hit something we should acknowledge the velocity vectors
		if (onGround && hit.collider.tag == "Untagged") {
			hitSomethingInAir = false;
		} else {
			//But if not and we are staying on a wall, we should ignore velocity vectors
			hitSomethingInAir = true;
		}
	}

	void OnCollisionExit(Collision hit) {
		//If we exit a collision we should just assume that we have not hit a wall or anything
		hitSomethingInAir = false;
	}

	void OnTriggerEnter(Collider hit){
		//Trigger for feet to see if on floor to entity
		onGround = true;

	}

	void OnTriggerExit(Collider hit){
		//Trigger for feet to see if off floor to entity
		onGround = false;
	}

	public void setFreeze(bool f){
		freeze = f;
	}
	
}