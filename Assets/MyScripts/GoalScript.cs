using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string WinLevelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 

        SceneManager.LoadScene(WinLevelName, LoadSceneMode.Single);
        }
    }
}
