using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public DoorScript attachedDoor;
    [SerializeField]
    public ParticleSystem TakenItemParticles;
    [SerializeField]
    public ParticleSystem ActualParticleSystem;
    [SerializeField]
    public SpriteRenderer Sprite;
    void Start()
    {
        TakenItemParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attachedDoor.Unlocked = true;
            if (TakenItemParticles != null)
            {
                TakenItemParticles.Play();
                Sprite.enabled = false;
                var Emiter = ActualParticleSystem.emission;
                Emiter.enabled = false;
                Destroy(this.gameObject, TakenItemParticles.main.duration);
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                if (audio != null && audio.clip != null)
                {
                    audio.Play();
                }
                else
                {
                    Debug.LogError("Sound not found");
                }
            }
            else
            {
                Debug.LogError("ParticleSystem not found");
                Destroy(this.gameObject);
            }
        }
    }
}
