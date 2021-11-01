using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpScript : MonoBehaviour
{

    [SerializeField]
    public ParticleSystem TakenItemParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null && audio.clip != null)
            {
                audio.Play();
            }
            else
            {
                Debug.LogError("Sound not found");
            }
            GUIManager.Instance.UpdateLives(++GameManager.Instance.PlayerLives);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            var emision = gameObject.GetComponentInChildren<ParticleSystem>().emission;
            emision.enabled = false;
            TakenItemParticles.Play();
            Destroy(gameObject, TakenItemParticles.main.duration);
            Destroy(this.gameObject);
        }
    }
}
