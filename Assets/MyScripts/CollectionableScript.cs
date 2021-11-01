using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionableScript : MonoBehaviour
{

    public int Points=100;

    [SerializeField]
    public ParticleSystem TakenItemParticles;
    [SerializeField]
    public SpriteRenderer Sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.Score += Points;
            GUIManager.Instance.UpdateScore(GameManager.Instance.Score);
            //Add some audio effects
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null && audio.clip!=null)
            {
                audio.Play();
            }
            else
            {
                Debug.LogError("Sound not found");
            }
            Sprite.enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            var emision = gameObject.GetComponentInChildren<ParticleSystem>().emission;
            emision.enabled = false;
            TakenItemParticles.Play();
            Destroy(gameObject,TakenItemParticles.main.duration);
        }
    }
}
