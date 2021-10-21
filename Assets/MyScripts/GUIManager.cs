using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GUIManager Instance=null;
    public Text LiveText;
    public Text ScoreText;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void UpdateLives(int incoming)
    {
        LiveText.text = incoming.ToString();
    }
    public void UpdateScore(int incoming)
    {
        ScoreText.text = "Score:" + " " + incoming.ToString();
    }
}
