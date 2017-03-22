using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    private GameObject eyecamera;
    private bool foundCam = false;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (!foundCam)
        {
            //allow sim control
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }
    }

    public override void OnStartLocalPlayer()
    {
        //check we're in VR
        eyecamera = GameObject.Find("Camera (eye)");
        if (eyecamera != null)
        {
            transform.position = eyecamera.transform.position;
            transform.parent = eyecamera.transform;
            foundCam = true;

            //turn off the renderers for ourself
            GetComponent<AvatarKiller>().killChildren();
        }
        else
        {
            //if we're not, we need to be higher up
			Transform spawn = GameObject.FindGameObjectWithTag("Respawn").transform;
            transform.position = new Vector3(spawn.position.x, spawn.position.y + 1.65f, spawn.position.z);
        }
    }
}