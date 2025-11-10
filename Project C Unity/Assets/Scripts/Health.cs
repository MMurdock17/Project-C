using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public bool isLocalPlayer;

    public RectTransform healthBar;
    private float originalHealthBarSize;

    public TextMeshProUGUI healthText;


    private void Start()
    {
        originalHealthBarSize = healthBar.sizeDelta.x;
    }


    [PunRPC]
    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);
        
        healthText.text = health.ToString();

        if (health <= 0)
        {
            if (isLocalPlayer)
            {
                RoomManager.instance.RespawnPlayer();

                RoomManager.instance.deaths++;
                RoomManager.instance.SetHashes();
            }
            

            Destroy(gameObject);
        }
    }

}
