using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	private GameCamera cam;

	void Start () {
		cam = GetComponent<GameCamera>();
		SpawnPlayer();
	}
	
	public void SpawnPlayer(){
		cam.SetTarget((Instantiate(player, new Vector3(0,5,0), Quaternion.identity) as GameObject).transform);
		
	}
}
