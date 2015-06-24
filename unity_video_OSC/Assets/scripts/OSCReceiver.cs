using UnityEngine;
using System.Collections;

public class OSCReceiver : MonoBehaviour {
	// public variables to listen to OSC
	public string RemoteIP = "192.168.1.75"; // connected ip-adres (127.0.0.1) is local
	public int SendToPort = 8000;         // send osc to specified port (not used here)
	public int ListenerPort = 1260;       // listen to messages on a certain port (digixperiment uses 1260)
	
	private Osc handler ;					// handler from incomming messages
	private OscMessage oscM ;


	public void Awake ()
	{
		//Initializes on start up to listen for messages
		//make sure this game object has both UDPPackIO and OSC script attached
		UDPPacketIO udp = GetComponent<UDPPacketIO>();
		udp.init(RemoteIP, SendToPort, ListenerPort);
		handler = GetComponent<Osc>();
		handler.init(udp);
		
		// pass oscMessages to the OSCmessage function		
		handler.SetAllMessageHandler(OSCmessage);
		
		Debug.Log("OSC is running");

		OscMessage oscM = Osc.StringToOscMessage("/demarre");
		handler.Send(oscM);

	}


	
	public void Sen(string Mess){
		OscMessage oscM = Osc.StringToOscMessage(Mess);
		handler.Send(oscM);
	}

	
	// handles all OSC messages
	// its not possible to call functions from this function (why...?)
	
	void OSCmessage(OscMessage oscMessage) 
	{	//Debug.Log(Osc.OscMessageToString(oscMessage));
		

		// check if incoming message is a /tijdvak message


		/*if((oscMessage.Address) == "/backA") Back = "videoa";
		if((oscMessage.Address) == "/backB") Back = "videob";
		if((oscMessage.Address) == "/middleA") Middle = "videoa";
		if((oscMessage.Address) == "/ForceA")ForceA= 1;
*/

		if((oscMessage.Address) == "/GB") Middle = "videoa";
		if((oscMessage.Address) == "/GH") Middle = "videob";
		if((oscMessage.Address) == "/DB") Back = "videoa";
		if((oscMessage.Address) == "/DH") ForceA= 1;

		//float force = (float) oscMessage.Values[0];
		//int index = (int) oscMessage.Values[1];
		//Rarm.SendMessage("inputReceived",1f);
		//Rarm.rigidbody.AddForce(new Vector3(1,0,0));
			
	}


	// Use this for initialization
	GameObject Rarm ;


	public VideoPlay BackGround;
	public VideoPlay MiddleGround;
	string Back="rien";
	string Middle="rien";
	int ForceA=0;

	void Start () {
		Rarm = GameObject.FindGameObjectWithTag ("RightArm");

	//VideoPlan = GameObject.FindGameObjectWithTag ("VideoPlane");
	//	VideoPlan = GameObject.FindGameObjectWithTag ("VideoPlane");

	}
	
	// Update is called once per frame
	void Update () {

		// Rarm.rigidbody.AddForce(new Vector3(0,-20,0))


		if (Back == "videoa") {
			Back = "rien";
			BackGround.videoa();
			}

		if (Middle == "videoa") {
			Middle = "rien";
			MiddleGround.videoa();
		}
		if (Middle == "videob") {
			Middle = "rien";
			MiddleGround.videob();
		}

		if (ForceA == 1) {
			Rarm.transform.Translate (0, -0.5f, 0);
			ForceA = 0;
		}

	}
}
