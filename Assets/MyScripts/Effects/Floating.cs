using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float m_floatingSpeed;
    public float m_timeDirection;
    public FloatingDirection Direction;

    private Vector3 direction;
    private float m_remainingTime = 0f;
    void Start()
    {
        if (Direction.Equals(FloatingDirection.HORIZONTAL))
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.up;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_remainingTime >= m_timeDirection)
        {
            m_remainingTime = 0f;
            direction *= -1f;
            transform.position += direction * Time.deltaTime*m_floatingSpeed;
        }
        else
        {
            m_remainingTime += Time.deltaTime;
            transform.position += direction * Time.deltaTime*m_floatingSpeed;
        }
    }

    public enum FloatingDirection
    {
        VERTICAL, HORIZONTAL
    }
}
