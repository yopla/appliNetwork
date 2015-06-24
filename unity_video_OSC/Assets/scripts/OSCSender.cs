using UnityEngine;
using System.Collections;

public class OSCSender : MonoBehaviour {
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
	{	

	}



	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



	}
}
