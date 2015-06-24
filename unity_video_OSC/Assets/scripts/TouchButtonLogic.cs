using UnityEngine;
using System.Collections;

public class TouchButtonLogic : MonoBehaviour {
	
	void Update () {
		// is there a touch on the screen

		if (Input.touches.Length <= 0)
		{
			//if no touches execute this code
		}

		else //if there is a touch

		{
			//loop through all the touches on screen
			for(int i= 0; i<Input.touchCount; i++)
			{ //executes this code for current touch (i) on screen

				if (this.guiTexture.HitTest(Input.GetTouch(i).position))
				{
					//if current touch hits our guitexture, run this code
					if (Input.GetTouch (i).phase == TouchPhase.Began)
					{
						//need to send message b/c function is not present in the script
						this.SendMessage("OnTouchBegan");
						//Debug.Log ("The Touch is down on" + this.name);

					}
					if (Input.GetTouch (i).phase == TouchPhase.Ended)
					{
						//need to send message b/c function is not present in the script
						this.SendMessage("OnTouchEnded");
						//Debug.Log ("The Touch is up on" + this.name);
						
					}

				}

			}
		}
	
	}
}
