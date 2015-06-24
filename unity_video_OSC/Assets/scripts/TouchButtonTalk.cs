using UnityEngine;
using System.Collections;

public class TouchButtonTalk : TouchButtonLogic {

	void OnTouchBegan()
	{
		Debug.Log ("The Touch is down on" + this.name);
	}

	void OnTouchEnded ()
	{
		Debug.Log ("The Touch is up on" + this.name);
	}

}
