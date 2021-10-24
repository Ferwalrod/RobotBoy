using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyTransform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform TransformToAttach;
    void Start()
    {
        TransformToAttach = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.parent = TransformToAttach;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
