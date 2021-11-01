using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenCharge : MonoBehaviour
{
    [SerializeField]
    public int charges;
    [SerializeField]
    public PowerUpType Type;
    [SerializeField]
    public float timeUntilReactivate;
    [SerializeField]
    public ParticleSystem TakenItemParticles;
    // Start is called before the first frame update
    void Start()
    {
        TakenItemParticles.Stop();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.Instance.Pointer.ShurikenCharges += charges;
            GUIManager.Instance.UpdateShurikenCharges(GameManager.Instance.Pointer.ShurikenCharges);
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            if (audio != null && audio.clip != null)
            {
                audio.Play();
            }
            else
            {
                Debug.LogError("Sound not found");
            }
            if (Type.Equals(PowerUpType.RENEWABLE))
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                var emision= gameObject.GetComponentInChildren<ParticleSystem>().emission;
                emision.enabled = false;
                TakenItemParticles.Play();
                yield return new WaitForSeconds(timeUntilReactivate);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                emision.enabled = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                var emision = gameObject.GetComponentInChildren<ParticleSystem>().emission;
                emision.enabled = false;
                TakenItemParticles.Play();
                Destroy(this.gameObject,TakenItemParticles.main.duration);
            }
        }
    }

    public enum PowerUpType
    {
        RENEWABLE,ONE_USE
    }
}
