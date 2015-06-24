using UnityEngine;
using System.Collections;

public class RagDollMovement : MonoBehaviour
{
   
	private GameObject Rarm;
	private GameObject Larm;
	private GameObject Rleg;
	private GameObject Lleg;
	private GameObject Rknee;
	private GameObject Lknee;
	private GameObject Relbow;
	private GameObject Lelbow;


	void Start ()
	{

		Rarm = GameObject.FindGameObjectWithTag ("RightArm");
		Larm = GameObject.FindGameObjectWithTag ("LeftArm");
		Rleg = GameObject.FindGameObjectWithTag ("RightLeg");
		Lleg = GameObject.FindGameObjectWithTag ("LeftLeg");
		Rknee = GameObject.FindGameObjectWithTag ("RightKnee");
		Lknee = GameObject.FindGameObjectWithTag ("LeftKnee");
		Relbow = GameObject.FindGameObjectWithTag ("RightElbow");
		Lelbow = GameObject.FindGameObjectWithTag ("LeftElbow");


	}
    void Update()
    {
        
		if (Input.GetKey(KeyCode.Keypad7))
			
			Rarm.transform.Translate (0.2f,0,0);

		if (Input.GetKey(KeyCode.Keypad9))

			Larm.transform.Translate (0,0.2f,0);

		if (Input.GetKey(KeyCode.Keypad1))
			
			Rleg.transform.Translate (0,-0.2f,0);
		
		if (Input.GetKey(KeyCode.Keypad3))
			
			Lleg.transform.Translate (0,0.2f,0);

		if (Input.GetKey(KeyCode.Keypad4))
			
			Rknee.transform.Translate (0,-0.2f,0);
		
		if (Input.GetKey(KeyCode.Keypad6))
			
			Lknee.transform.Translate (0,0.2f,0);

		if (Input.GetKey(KeyCode.Keypad8))
			
			Relbow.transform.Translate (0,-0.2f,0);
		
		if (Input.GetKey(KeyCode.Keypad5))
			
			Lelbow.transform.Translate (0,0.2f,0);

        }

	void onTriggerEnter (Collider other){

		Debug.Log ("Trigger");
	}
    }

