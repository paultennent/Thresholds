using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutoServerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NetworkManager nm = GetComponent<NetworkManager>();
        nm.StartServer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
