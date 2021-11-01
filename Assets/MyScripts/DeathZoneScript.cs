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
            gameObject.GetComponent<AudioSource>().Play();
            if (GameManager.Instance.CurrentCheckPoint == null)
            {
                collision.transform.position = Vector3.zero;
                int lives=--GameManager.Instance.PlayerLives;
                GUIManager.Instance.UpdateLives(lives);
            }
            else
            {
                collision.transform.position = GameManager.Instance.CurrentCheckPoint.position;
                int lives=--GameManager.Instance.PlayerLives;
                GUIManager.Instance.UpdateLives(lives);
            }
            collision.enabled = true;
        }
    }

}
