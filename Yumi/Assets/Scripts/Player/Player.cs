using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

	bool doubleJump=false;

	Controller controller;

    public AudioSource landingSound;//NOT IMPLEMENTED YET
                                    //if (velocity.y < -15){
                                    //    landingSound.mute = false
                                    //}


    public Image healthBar;
    public Text healthText;
    public float maxHealth;


    void Start (){
        controller = GetComponent<Controller>();
		
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

        //this looks so bad but dunno a better way than this.
        healthBar =GameObject.Find("HealthbarSystem").GetComponent<Transform>().transform.FindChild("HealthBG").FindChild("Health").GetComponent<Image>();
        healthText = GameObject.Find("HealthbarSystem").GetComponent<Transform>().transform.FindChild("HealthBG").FindChild("Health").FindChild("Text").GetComponent<Text>();
        maxHealth = health; //max health is the health when initialized
        healthBar.fillAmount = 1;
        healthText.text = "100";
    }

	void Update (){
		if (controller.collisions.above) {
			velocity.y = 0;
		}
		if (controller.collisions.below){
			velocity.y = 0;
            doubleJump = false;
        }

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		//single jump
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) 
            && controller.collisions.below) {
			velocity.y = jumpVelocity;
        }

		//double jump
		if (!controller.collisions.above && !controller.collisions.below 
            && !doubleJump 
            && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
            {
			velocity.y = jumpVelocity;
			doubleJump=true;
		}


		float speed= (Input.GetButton("Run")? runSpeed : walkSpeed);

		float targetVelocityX = input.x * speed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, 
		                               (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);


	}

    

    public void SetVelocity(Vector3 vel)
    {
        velocity += vel;
    }
    public Vector3 GetVelocity()
    {
        return velocity;
    }
}