using UnityEngine;
using System.Collections;

public class FallingDeath : MonoBehaviour {

	//GameManager gm = new GameManager();
	public Transform spawnPoint;
	public GameObject player;

	void OnTriggerEnter(Collider c) {
		Debug.Log("heyyo");
		if (c.tag == "Player"){
			Destroy (GameObject.FindWithTag("Player"));
			GameObject playerInstance= Instantiate(player, spawnPoint.transform.position, Quaternion.identity) as GameObject;
			playerInstance.name="Player";

		}
	}

}