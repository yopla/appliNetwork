using UnityEngine;
using System.Collections;

public class TouchButtonColor : TouchButtonLogic {

	void OnTouchBegan()
	{
		Camera.main.backgroundColor = Color.green;
	}
	
	void OnTouchEnded ()
	{
		Camera.main.backgroundColor = Color.red;
	}
	
}

