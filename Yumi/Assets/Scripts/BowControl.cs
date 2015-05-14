using UnityEngine;
using System.Collections;

public class BowControl : MonoBehaviour {


	private bool isPressed;
	private Vector3 mousePos;
	private LineRenderer lineRenderer;

	void Start(){
		isPressed=false;

		lineRenderer=GetComponent<LineRenderer>();
		lineRenderer.SetPosition(0,transform.position);
		lineRenderer.SetWidth (.1f, .1f);
		lineRenderer.SetColors (Color.cyan,Color.cyan);
	}

	void Update() {

		if (Input.GetMouseButtonDown(0)){
			mousePos = Input.mousePosition;


			Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
			isPressed=true;

		}

		if (isPressed){
			Vector3 dir = mousePos-Input.mousePosition;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
			Debug.DrawRay(transform.position, dir);

			lineRenderer.SetPosition (1, Input.mousePosition);

			/*dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);*/

		}

		if (Input.GetMouseButtonUp(0)){
			isPressed=false;
		}

	}

}