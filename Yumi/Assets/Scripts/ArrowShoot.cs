using UnityEngine;
using System.Collections;

public class ArrowShoot : MonoBehaviour {
	


	private Vector3 mousePos;

	//arrow properties
	public Rigidbody arrowPrefab; 

	public float arrowSpeed = 100f;
	public float fireRate = 0.0f;
	public float nextFire = 0.0f;

	private bool falsePull;
	private bool isPulled;

	public float pullStartTime = 0.0f;
	public float pullTime = 0f;
	//public float maxStrengthPullTime = 1f; // how long to hold button until max strength reached

	

	void Start(){
		falsePull = false;
		isPulled = false;
	}
	
	void Update(){

		// pull back string
		if(Input.GetMouseButtonDown(0))
		{
			mousePos = Input.mousePosition;
			isPulled=true;


			if(Time.time > nextFire)
			{
				nextFire = Time.time + fireRate; 
				pullStartTime = Time.time; //store the start time
				//animation.Play("PULLBACK");
			}
			else{
				falsePull = true;
			}


		}

		// fire arrow
		if(Input.GetMouseButtonUp(0)){
			if(!falsePull)
			{
				Vector3 offset = mousePos - Input.mousePosition;

				/*
				//nextFire = Time.time + pullTime; // this is the actual fire rate as things stand now
				//animation.Play("FIRE");

				float timePulledBack = Time.time - pullStartTime; // this is how long the button was held
				if(timePulledBack > maxStrengthPullTime) // this says max strength is reached 
					timePulledBack = maxStrengthPullTime; // max strength is ArrowSpeed * maxStrengthPullTime
				arrowSpeed = arrowSpeed * timePulledBack; // adjust speed directly using pullback 
				*/
				if ( offset.magnitude > Vector3.Magnitude(new Vector3(2,2,0) )){ //only if user pulls hard enough
					
					Rigidbody arrowInstance = Instantiate(arrowPrefab, 			//the object
					                                      transform.position,	//the 3d pos
					                                      transform.rotation) 	//the rotation
						as Rigidbody;		//reference conversions to rigidbody
					//arrowPrefab = Rigidbody.Instantiate(arrowPrefab); //can also instantiate like this.
					arrowInstance.name = "Arrow";

				float timePulledBack = Time.time - pullStartTime; // this is how long the button was held
				if(timePulledBack > 0.4f){ // this says max strength is reached 
					arrowSpeed *= 1.5f; // adjust speed directly using pullback
				}
				if(timePulledBack>0.8f){
					arrowSpeed *= 3f; // adjust speed directly using pullback
				}
				
				arrowInstance.AddForce(offset.normalized * arrowSpeed);
				DestroyObject(arrowInstance.gameObject, 5);
				arrowSpeed=300;

					Debug.Log (arrowInstance.mass*arrowSpeed);
				}
			}
			else{
				falsePull = false;
			}
		}

		if (isPulled){
			//drawTrajectory();
		}
	}



	void drawTrajectory(){
		/*
		float now = Time.time;
		float timePulledBack = Time.time - pullStartTime;
		
		if(timePulledBack > maxStrengthPullTime){
			timePulledBack = maxStrengthPullTime;
		}
		arrowSpeed *= timePulledBack;
		
		if (now+1 > Time.time){
			now=Time.time;
			Rigidbody arrowInstance = Instantiate(arrowPrefab, 			//the object
			                                      transform.position,	//the 3d pos
			                                      transform.rotation) 	//the rotation
				as Rigidbody;		//reference conversions to rigidbody
			//arrowPrefab = Rigidbody.Instantiate(arrowPrefab); //can also instantiate like this.
			arrowInstance.name = "Arrow";
			Vector3 offset = mousePos - Input.mousePosition;
			arrowInstance.AddForce(offset.normalized * arrowSpeed);
			DestroyObject(arrowInstance.gameObject, 5);
			arrowSpeed=1000;
		}
		
		if(Input.GetMouseButtonUp(0)){
			isPulled=false;
		}
		*/
	}
}