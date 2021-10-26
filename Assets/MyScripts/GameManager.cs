using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Transform CurrentCheckPoint;
    [HideInInspector]
    public static GameManager Instance;
    [HideInInspector]
    public MousePointer Pointer;

    public int Score=0;
    public int PlayerLives=3;
    // Start is called before the first frame update

    void Start()
    {
        Score = 0;
        CurrentCheckPoint = null;
        Instance = this;
        Pointer = GameObject.FindGameObjectWithTag("MousePointer").GetComponent<MousePointer>();
        DontDestroyOnLoad(this.gameObject);
        GUIManager.Instance.UpdateLives(PlayerLives);
        GUIManager.Instance.UpdateScore(Score);
        GUIManager.Instance.UpdateShurikenCharges(Pointer.ShurikenCharges);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLives == 0)
        {
            PlayerLives = -1;
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }
    }
}
