using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class Slider : MonoBehaviour {
	
	public Transform knob;
	public float speed = 0.01f;
	//private GameObject Rarm;
	public OSCSender sender;

	private Vector3 targetPos;
	private float sliderPercent;

	private float sliderLength;
	
	void Start () {
		sliderLength = GetComponent<BoxCollider> ().size.x;
		//Rarm = GameObject.FindGameObjectWithTag ("RightArm");
		targetPos = knob.position + Vector3.right * (sliderLength/-2 + sliderLength * sliderPercent);
		knob.position = targetPos; 
	}
	
	void Update () {
				knob.position = Vector3.Lerp (knob.position, targetPos, Time.deltaTime * 7);
		
				sliderPercent = Mathf.Clamp01 ((knob.localPosition.x + sliderLength / 2) / sliderLength);

		/*if (Input.GetMouseButtonDown (0)) { //If Click
			receiver.Sen("/leX/"+Input.mousePosition[0].ToString());
		} */
		//Debug.Log (Screen.width);
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {

			/*if ( (Input.GetTouch(0).position[0] < Screen.width/2)
			    && (Input.GetTouch(0).position[1] < Screen.height/2) )
				sender.Sen ("/GB");

			
			if ( (Input.GetTouch(0).position[0] < Screen.width/2)
			    && (Input.GetTouch(0).position[1] > Screen.height/2) )
				sender.Sen ("/GH");

			if ( (Input.GetTouch(0).position[0] > Screen.width/2)
			    && (Input.GetTouch(0).position[1] < Screen.height/2) )
				sender.Sen ("/DB");
		
			if ( (Input.GetTouch(0).position[0] > Screen.width/2)
			    && (Input.GetTouch(0).position[1] > Screen.height/2) )
				sender.Sen ("/DH");
*/

		//	sender.Sen();

			//sender.Sen("/leX/"+Input.GetTouch(0).position[0].ToString());

		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
						//Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
						//Rarm.transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
						//Debug.Log("send");
		}
		}

	void OnTouchStay(Vector3 point) {
		targetPos = new Vector3(point.x,targetPos.y,targetPos.z);
	}

	}


	



	

