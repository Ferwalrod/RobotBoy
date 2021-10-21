using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [HideInInspector]
    public bool IsChecked;

    private SpriteRenderer Sprite;

    private void Start()
    {
        //gameObject.GetComponent<ParticleSystem>().;
        IsChecked = false;
        Sprite=gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&!IsChecked)
        {
            GameManager.Instance.CurrentCheckPoint = gameObject.transform;
            IsChecked = true;
            Sprite.color = Color.blue;
           
        }
    }
}
