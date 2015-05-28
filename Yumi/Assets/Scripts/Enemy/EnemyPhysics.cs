using UnityEngine;
using System.Collections;

public class EnemyPhysics : Entity{

	public GameObject lookTarget;
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .025f;
	float accelerationTimeGrounded = .05f;
	public float walkSpeed = 8;
	public float runSpeed = 12;

	public float playerDistance;
	public float rotationDamping;
	

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;
	
	EnemyController controller;
	
	void Start (){
		controller = GetComponent<EnemyController>();
		
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		//print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
		
	}
	
	
	void Update (){

		if (lookTarget==null){
			lookTarget= GameObject.Find("Player") as GameObject;
		}

		playerDistance = Mathf.Abs(lookTarget.transform.position.x- transform.position.x);
		if (playerDistance < 15f)
		{
			//lookAtPlayer();
		}
		if (playerDistance < 12f)
		{
			if(playerDistance > 4f)
			{
				chase ();
			}
			else if(playerDistance < 4f)
			{
				attack ();
			}
		}
		else{
			velocity.x=0;
		}
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity* Time.deltaTime);
		/*
		 * 
		float targetVelocityX = input.x * speed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, 
		                               (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
		*/
		
	}

	void lookAtPlayer()
	{
		Vector3 targetPosition = lookTarget.transform.position; 

		targetPosition.y = transform.position.y;
		transform.LookAt(targetPosition);
		/*
		Quaternion rotation = Quaternion.LookRotation (lookTarget.transform.position - transform.position);
		// rotate an object from a point to another in a given amount of time
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
		*/
	}
	
	void chase() 
	{
		float dirX;
		// the enemy will move forward (enemy.forward) at speed moveSpeed * DeltaTime
		//transform.Translate (Vector3.forward * walkSpeed * Time.deltaTime);
		if (lookTarget.transform.position.x - transform.position.x>0){
			dirX=1;
		}else{
			dirX=-1;
		}
		float speed= (Input.GetButton("Run")? runSpeed : walkSpeed);

		float targetVelocityX = dirX * speed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, 
		                               (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);


	}
	
	void attack()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit))
		{
			if(hit.collider.gameObject.tag == "Player")
			{
				
			}
		}
		
	}
}