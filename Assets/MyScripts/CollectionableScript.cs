using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableScript : MonoBehaviour
{

    public int Points=100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.Score += Points;
            GUIManager.Instance.UpdateScore(GameManager.Instance.Score);
            //Add some audio effects
            Destroy(gameObject);
        }
    }
}
