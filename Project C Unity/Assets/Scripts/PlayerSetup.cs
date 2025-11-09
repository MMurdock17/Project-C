using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    public Movement movement;
    public GameObject camera;
    public string username;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
    }

    [PunRPC]
    public void SetUsername(string name)
    {
        username = name;
    }

}
