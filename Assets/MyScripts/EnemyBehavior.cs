using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private int i = 1;
    public float m_speed;
    public bool IsPatrolling;
    //Options about patrol
    public float minDistance;
    private float SqrDistance;
    public List<Transform> patrolPositions;

    private Transform PlayerTransform=null;
    //OriginPoint is used only if it hasn't patrol mode
    private Vector3 OriginPoint;
    void Start()
    {
        SqrDistance = minDistance * minDistance;
        OriginPoint = gameObject.transform.position;
        if (IsPatrolling)
        {
            StartCoroutine(Patrol());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform != null)
        {
            Vector3 Vector = (PlayerTransform.position - gameObject.transform.position).normalized*m_speed*2*Time.deltaTime;
            Vector.z = 0f;
            this.gameObject.transform.position += Vector;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerTransform = collision.transform;
            StopAllCoroutines();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerTransform = null;
        if (IsPatrolling)
        {
            StartCoroutine(Patrol());
        }
        else
        {
            StartCoroutine(ReturnToOrigin());
        }
    }

    IEnumerator ReturnToOrigin()
    {
        bool HasReturned = false;
        while (!HasReturned)
        {
            Vector3 vector = (OriginPoint - gameObject.transform.position);
            float ActualDistance = vector.magnitude;
            gameObject.transform.position += vector.normalized * m_speed * Time.deltaTime;
            if (ActualDistance <= SqrDistance)
            {
                HasReturned = true;
            }
            yield return null;
        }
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            Vector3 vector = (patrolPositions[i].position - gameObject.transform.position);
            float ActualDistance = vector.magnitude;
            gameObject.transform.position += vector.normalized * m_speed * Time.deltaTime;
            if (ActualDistance <= SqrDistance)
            {
                i++;
                if (i == patrolPositions.Count)
                {
                    i = 0;
                }
            }
            yield return null;
        }
    }
}
