using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public Image Story1;
    public Image Story2;
    public Image Story3;
    public Image Story4;
    public Image Est;
    public int A;

    private Vector3 Local;
    void Start()
    {
        A = -1;
        Debug.Log("start");
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (A >= 0)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    A++;
                }
            }
            
        }

        if (A==0)
        {
            Local = new Vector3(1280, 720, 1);
            Story1.transform.position = Local;
        }
        if (A == 1)
        {
            Local = new Vector3(1280, 720, 2);
            Story2.transform.position = Local;
        }
        if (A == 2)
        {
            Local = new Vector3(1280, 720, 3);
            Story3.transform.position = Local;
        }
        if (A == 3)
        {
            Local = new Vector3(1280, 720, 4);
            Story4.transform.position = Local;
        }

        if (A > 3)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void StartGame()
    {
        A = 0;
        
        Debug.Log("set");
    }
    public void NextPage()
    {
        A++;
    }
    
    public void GameExit()
    {
        Application.Quit();
    }
    public void EstEgg()
    {
        Est.transform.position = new Vector3(1280, 720, 4);
        Destroy(Est, 10);
    }

}
