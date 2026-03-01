using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour {
    int life;

    void Start() {
        life = 0;
    }
    public void clickedStart()
    {
        SceneManager.LoadScene("TestGameplay");
    }

    public void clickedQuit()
    {
        Application.Quit();
    }
    
    void Update() {
        Debug.Log(life);
    }
}
