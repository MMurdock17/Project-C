using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Pun.UtilityScripts;

public class PlayerSetup : MonoBehaviour
{
    public Movement movement;
    public GameObject camera;
    public string username;
    public TextMeshPro usernameText;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        camera.SetActive(true);
    }

    [PunRPC]
    public void SetUsername(string name)
    {
        username = name;

        usernameText.text = username;
    }
}
