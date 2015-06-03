using UnityEngine;

using System.Collections;

public class ArrowControl : MonoBehaviour {

	public bool isPickup = false;
	public int gravityRotate = 1;
	private Rigidbody myRigidBody;
    public AudioSource hitSound;
    Collision newParent;
    [Range(1, 5)]
    public float pushBackDistance;
    float velocityMagnitude;
    //public Color collideColor;
    //public Color normalColor;

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
        hitSound.Play();
        newParent = collision;
        Destroy(GetComponent<Collider>());  //make it not collide anymore
        Destroy(GetComponent<Rigidbody>()); //make it not have mass 
        Destroy(this.gameObject, 1); //destroy arrow after a second
        transform.SetParent(collision.transform);


        //--------------------------------------------------------------------------

    }
}
