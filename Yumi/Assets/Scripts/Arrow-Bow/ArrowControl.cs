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
        if (collision.gameObject.tag == "Enemy")
        {
            transform.SetParent(collision.transform); //arrow sticks on enemy
        }
        //delete all when scaling fixed to 1 for objects----------------------------
        else if (collision.transform.name == "Moving Platform") 
        {
            transform.SetParent(collision.transform);
        }/*
        else if (collision.transform.parent.name != "scalefix")  //fix scaling on unscaled objects
        {

            GameObject unscaledparent = new GameObject();
            unscaledparent.name = "scalefix";
            unscaledparent.transform.SetParent(collision.transform.parent);
            collision.transform.SetParent(unscaledparent.transform);
            transform.SetParent(unscaledparent.transform.parent);
        }*/
        else
        {
            transform.SetParent(collision.transform.parent);
        }
        //--------------------------------------------------------------------------

    }
}
