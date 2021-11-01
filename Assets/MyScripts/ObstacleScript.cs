using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    private int i = 1;
    public float m_speed;
    public List<Transform> Waypoints;
    public float minDistance;
    private float SqrDistance;

    [SerializeField]
    public bool IsMovingObstacle;

    // Start is called before the first frame update
    void Start()
    {
        SqrDistance = minDistance * minDistance;
        if (IsMovingObstacle)
        {
            StartCoroutine(MoveObstacle());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.enabled = false;
            gameObject.GetComponent<AudioSource>().Play();
            if (GameManager.Instance.CurrentCheckPoint == null)
            {
                collision.transform.position = Vector3.zero;
                int lives = --GameManager.Instance.PlayerLives;
                GUIManager.Instance.UpdateLives(lives);
            }
            else
            {
                collision.transform.position = GameManager.Instance.CurrentCheckPoint.position;
                int lives = --GameManager.Instance.PlayerLives;
                GUIManager.Instance.UpdateLives(lives);
            }
            collision.enabled = true;
        }
    }
    IEnumerator MoveObstacle()
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
    //If you want to Trigger an obstacle in some point, call this function
    void ActivateMovement()
    {
        StartCoroutine(MoveObstacle());
    }
    void StopMovement()
    {
        StopAllCoroutines();
    }
}
