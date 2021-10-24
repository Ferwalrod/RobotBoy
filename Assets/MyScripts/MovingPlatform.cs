using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private int i = 1;
    public float m_speed;
    public List<Transform> Waypoints;
    public float minDistance;
    private float SqrDistance;
    // Start is called before the first frame update
    void Start()
    {
        SqrDistance = minDistance * minDistance;
        StartCoroutine(MovePlatform());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            Vector3 vector = (Waypoints[i].position - gameObject.transform.position);
            float ActualDistance = vector.magnitude;
            gameObject.transform.position += vector.normalized * m_speed * Time.deltaTime;
            if (ActualDistance <= SqrDistance)
            {
                i++;
                if (i == Waypoints.Count)
                {
                    i = 0;
                }
            }
            yield return null;
        }
    }


}
