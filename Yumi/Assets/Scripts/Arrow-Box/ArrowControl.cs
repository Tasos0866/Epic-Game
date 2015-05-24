using UnityEngine;

using System.Collections;

public class ArrowControl : MonoBehaviour {

	public bool isPickup = false;
	public int gravityRotate = 1;
	private Rigidbody myRigidBody;

    Collision newParent;


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
        newParent = collision;
        Destroy (GetComponent<Rigidbody>());

        //delete all when scaling fixed to 1 for objects----------------------------
        if (collision.transform.parent.name != "scaleFix"){
			GameObject unScaledParent = new GameObject();
			unScaledParent.name="scaleFix";
			unScaledParent.transform.SetParent(collision.transform.parent);
			collision.transform.SetParent(unScaledParent.transform);
            transform.SetParent(unScaledParent.transform.parent);
        }
        transform.SetParent(collision.transform.parent);
        
        if (collision.transform.name == "Moving Platform")
        {
            transform.SetParent(collision.transform);
        }
        //--------------------------------------------------------------------------

    }

}