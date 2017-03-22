using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarKiller : MonoBehaviour {

	public GameObject[] toKill;

	public void killChildren()
	{
		foreach(GameObject i in toKill){
			i.GetComponent<Renderer>().enabled = false;
		}
	}
}
