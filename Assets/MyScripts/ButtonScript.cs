using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedButton()
    {
        GameManager.Instance.Score = 0;
        GameManager.Instance.PlayerLives = 3;
        SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
    }
    
}
