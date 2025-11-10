using UnityEngine;
using Photon.Pun;

public class PlayerPhotonSoundManager : MonoBehaviour
{
    
public AudioSource gunShootSource;
public AudioClip[] allGunShootSFX;


public void PlayShootSFX(int index)
{
    GetComponent<PhotonView>().RPC("PlayShootSFX_RPC", RpcTarget.All, index);
}

[PunRPC]
public void PlayShootSFX_RPC(int index)
{
    gunShootSource.clip = allGunShootSFX[index];

    gunShootSource.pitch = UnityEngine.Random.Range(0.7f, 1.2f);
    gunShootSource.volume = UnityEngine.Random.Range(0.2f, 0.35f);

    gunShootSource.Play();
}

}
