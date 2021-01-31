using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSet : MonoBehaviour {

	// Use this for initialization
	
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    public void InGameExit()
    {
        SceneManager.LoadScene("Main");
    }
}
