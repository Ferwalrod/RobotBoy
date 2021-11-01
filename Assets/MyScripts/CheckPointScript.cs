using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [HideInInspector]
    public bool IsChecked;

    private SpriteRenderer Sprite;
    private ParticleSystem Particles;

    private void Start()
    {
        Particles = gameObject.GetComponentInChildren<ParticleSystem>();
        if (Particles != null)
        {
            var emision = Particles.emission;
            emision.enabled = false;
        }
        else
        {
            Debug.LogError("No se encontro el particle system");
        }
        IsChecked = false;
        Sprite=gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&!IsChecked)
        {
            GameManager.Instance.CurrentCheckPoint = gameObject.transform;
            IsChecked = true;
            Sprite.color = Color.cyan;
            var emision = Particles.emission;
            emision.enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
           
        }
    }
}
