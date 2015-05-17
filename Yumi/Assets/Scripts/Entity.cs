using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

	public float health;
	public GameObject ragdoll;

	//TEMPORARY //////////////////////////////////////////////////////////
	public GameObject player;
	//TEMPORARY //////////////////////////////////////////////////////////

	public void TakeDamage(float dmg){
		health -=dmg;

		if (health<=0){
			Die();
		}
	}

	public void Die(){
		Debug.Log ("DIE");

		if (this.tag=="Player"){
			Ragdoll r =	(Instantiate(ragdoll, transform.position, transform.rotation) as GameObject).GetComponent<Ragdoll>();
			r.CopyPose(transform);
			DestroyObject(r.gameObject,2);
		}
		//Destroy(this.gameObject);


	}
}
