using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    // Start is called before the first frame update

    public Text FinalScoreText;

    void Start()
    {
        FinalScoreText.text = "Your score:" + " " + GameManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
