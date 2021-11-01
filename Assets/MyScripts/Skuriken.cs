using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skuriken : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float m_Speed;

    [SerializeField]
    public ParticleSystem Explosive;

    IEnumerator Start()
    {
        Explosive.Stop();
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Forward = transform.forward * m_Speed;
        Forward.z = 0f;
        transform.position += Forward;
        gameObject.transform.Rotate(0f, 0f, 180f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShurikenInteractuable interactuable = collision.GetComponent<ShurikenInteractuable>();
        if (interactuable!=null)
        {
            if (interactuable.Type.Equals(ShurikenInteractuable.InteractuableType.DESTRUCTIBLE))
            {
                Destroy(interactuable.gameObject);
                Explosive.Play();
                gameObject.GetComponent<TrailRenderer>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(this.gameObject,Explosive.main.duration);
            }
            else
            {
                interactuable.IsActivated = true;
            }
        }
    }

}
