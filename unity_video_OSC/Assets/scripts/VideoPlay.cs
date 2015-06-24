using UnityEngine;
using System.Collections;

public class VideoPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		//movTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//public void videoa(){	} /// POUR TABLETTE
//	public void videob(){	}



	public MovieTexture movTexture1;   /// POUR MASTER

	public MovieTexture maskTexture1;
	public MovieTexture movTexture2;
	public MovieTexture maskTexture2;


	public void videoa(){
		movTexture1.Stop();
		maskTexture1.Stop();
		renderer.material.SetTexture ("_Mask", maskTexture1);
		renderer.material.mainTexture = movTexture1;
		movTexture1.Play();
		maskTexture1.Play();

	}
	public void videob(){
		movTexture2.Stop();
		maskTexture2.Stop();
		renderer.material.mainTexture = movTexture2;
		renderer.material.SetTexture ("_Mask", maskTexture2);
		movTexture2.Play();
		maskTexture2.Play();

	}


}
