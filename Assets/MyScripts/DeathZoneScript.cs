using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.enabled = false;
            if (GameManager.Instance.CurrentCheckPoint == null)
            {
                collision.transform.position = Vector3.zero;
                GameManager.Instance.PlayerLives--;
            }
            else
            {
                collision.transform.position = GameManager.Instance.CurrentCheckPoint.position;
                GameManager.Instance.PlayerLives--;
            }
            collision.enabled = true;
        }
    }

}
