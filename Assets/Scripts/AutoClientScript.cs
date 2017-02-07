using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutoClientScript : MonoBehaviour {

    public string fallbackIP = "192.168.1.109";

	// Use this for initialization
	void Start () {
        NetworkManager nm = GetComponent<NetworkManager>();
        nm.networkAddress = readIPData("serverip.txt");
        nm.networkPort = 7777;
        nm.StartClient();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private string readIPData(string filename)
    {
        string text = fallbackIP;
        try {
            text = System.IO.File.ReadAllText("serverip.txt");
        }catch(System.Exception e)
        {
            print("failed to laod serverip text file - relying on fallback IP");
        }
        return text;
    }
}
