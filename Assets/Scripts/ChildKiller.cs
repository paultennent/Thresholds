using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildKiller : MonoBehaviour {

    public GameObject player;
    public ParticleSystem particles;
    public GameObject mask;

    public void killChildren()
    {
        player.GetComponent<Renderer>().enabled = false;
        mask.GetComponent<Renderer>().enabled = false;
        particles.Stop();
    }
}
