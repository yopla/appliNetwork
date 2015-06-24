using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject [] touchesOld;
	private RaycastHit hit;
	private GameObject Rarm;
	public float speed = 1f;

			




	void Start (){


	}
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR
		if (Input.GetMouseButton (0) || Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)){
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
			
		
		
		

			
			Ray rayon = camera.ScreenPointToRay(Input.mousePosition);
			
			
			if (Physics.Raycast(rayon, out hit, touchInputMask)){
				
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);
				
			if (Input.GetMouseButtonDown (0)) {
					
					recipient.SendMessage ("OnTouchMoved", hit.point, SendMessageOptions.DontRequireReceiver);
					Debug.Log ("The Touch is down on" + this.name);
				
				}
				
			if (Input.GetMouseButtonUp (0)) {
					
					recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
					Debug.Log ("The Touch is up" + this.name);
				}
				
			if (Input.GetMouseButton (0)) {
					
					recipient.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}
				

				
				
			}
			
		
		
		foreach (GameObject button in touchesOld){

		
			
			if(!touchList.Contains(button)){
				button.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				
				
			}
			}
		}

#endif

		if (Input.touchCount > 0) {
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

		


		foreach (Touch touch in Input.touches){

			Ray ray = camera.ScreenPointToRay(touch.position);


			if (Physics.Raycast(ray, out hit, touchInputMask)){

				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);

				if (touch.phase == TouchPhase.Began) {

					recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					
				}

			

				if (touch.phase == TouchPhase.Ended) {
					
					recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
				}

				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
					
					recipient.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
				}

				if (touch.phase == TouchPhase.Canceled) {
					
					recipient.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);

				}
				
				

				
			

										}

		foreach (GameObject button in touchesOld){

			 

			if(!touchList.Contains(button)){
				button.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);

						
				}			
			}							 
		}
	
	}
}
	}

	