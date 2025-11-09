using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    public GameObject player;
    public Transform[] spawnPoints;
    public GameObject roomCam;

    public GameObject nameUI;
    public GameObject connectingUI;

    private string username = "unnamed";

    
    void Awake()
    {
        instance = this;
    }

    public void ChangeUsername(string name)
    {
        username = name;
    }

    public void JoinRoomButtonPressed()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        PhotonNetwork.JoinOrCreateRoom("test", null, null);

        Debug.Log("Connected now");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("Connected and in a Room");

        roomCam.SetActive(false);

        RespawnPlayer();
    }

    public void RespawnPlayer()
    {

        Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

        GameObject spawnPlayer = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        spawnPlayer.GetComponent<PlayerSetup>().IsLocalPlayer();
        spawnPlayer.GetComponent<Health>().isLocalPlayer = true;
        spawnPlayer.GetComponent<PhotonView>().RPC("SetUsername", RpcTarget.AllBuffered, username);

        PhotonNetwork.LocalPlayer.NickName = username;
    }

}
