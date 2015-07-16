using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float maxSpeed = 10f;
	float maxYSpeed = 10f;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = .2f;
	public LayerMask whatIsGround;

	float time;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis ("Horizontal");

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	// Update is called once per frame
	void Update () {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			grounded = false;
			time = Time.time;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 700f));
		}
		if(Input.GetKey (KeyCode.Space) && Time.time < time + .25){
			GetComponent<Rigidbody2D>().velocity = new Vector2( GetComponent<Rigidbody2D>().velocity.x, maxYSpeed);
		}
	}
}
