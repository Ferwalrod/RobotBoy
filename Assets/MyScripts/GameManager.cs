using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform CurrentCheckPoint;
    [HideInInspector]
    public static GameManager Instance;

    public int Score;
    public int PlayerLives=3;
    // Start is called before the first frame update

    void Start()
    {
        Score = 0;
        CurrentCheckPoint = null;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
