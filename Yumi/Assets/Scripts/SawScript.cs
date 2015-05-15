using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour {

	public float speed = 300;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player"){
			c.GetComponent<Entity>().TakeDamage(10);
		}
	}
}