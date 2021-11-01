using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool Unlocked;

    void Start()
    {
        Unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && Unlocked)
        {
            Animation animation = gameObject.GetComponent<Animation>();
            gameObject.GetComponent<AudioSource>().Play();
            animation.Play();

            yield return new WaitForSeconds(5.0f);

            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogWarning("Player has not key");
        }
    }
}
