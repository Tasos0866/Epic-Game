using UnityEngine;
using System.Collections;

public class Player : Entity{

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .025f;
	float accelerationTimeGrounded = .05f;
	float walkSpeed = 8;
	float runSpeed = 12;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller controller;

	void Start (){
		controller = GetComponent<Controller>();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

	}
	

	void Update (){
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float speed= (Input.GetButton("Run")? runSpeed : walkSpeed);

		float targetVelocityX = input.x * speed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, 
		                               (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);


	}
}