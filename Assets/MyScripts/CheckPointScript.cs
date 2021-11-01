using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CheckPointScript : MonoBehaviour
{
    [HideInInspector]
    public bool IsChecked;

    private SpriteRenderer Sprite;
    private ParticleSystem Particles;
    private Light2D Light;

    private void Start()
    {
        Particles = gameObject.GetComponentInChildren<ParticleSystem>();
        Light = gameObject.GetComponent<Light2D>();
        Light.enabled = false;
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
            Light.enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
           
        }
    }
}
