using UnityEngine;

using System.Collections;

public class ArrowControl : MonoBehaviour {

	public bool isPickup = false;
	public int gravityRotate = 1;
	private Rigidbody myRigidBody;




	void Start(){
		this.myRigidBody = this.GetComponent<Rigidbody>();
	}

	void Update ()
	{
		//transform.up = -myRigidBody.velocity ;
		if (!myRigidBody.Equals(null)){
			transform.right =  myRigidBody.velocity;
		}
	}

	void OnCollisionEnter(Collision collision){

		Destroy (GetComponent<Rigidbody>());

		if (collision.transform.parent.name != "scaleFix"){
			GameObject unScaledParent = new GameObject();
			unScaledParent.name="scaleFix";
			unScaledParent.transform.SetParent(collision.transform.parent);
			collision.transform.SetParent(unScaledParent.transform);
		}
		transform.SetParent(collision.transform.parent);

	}	
}