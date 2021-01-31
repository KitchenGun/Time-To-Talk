using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState
{
    Play,
    Stop
}


public class Block_Loop : MonoBehaviour
{

    public float Speed = 3;
    public GameObject[] Block;
    public GameObject A_Zone;
    public GameObject B_Zone;

    public GameState GS;
    public PlayerState PS;
    public GameObject PlayerS;
    public GameObject Cover;
    public GameObject GUI;
    public Text RText;
    public Text Result;
    
    public float Meter;
    public bool D;

    

    void Move()//움직이는함수
    {
        A_Zone.transform.Translate(Vector3.left * Speed * Time.deltaTime);
        B_Zone.transform.Translate(Vector3.left * Speed * Time.deltaTime);

        if(B_Zone.transform.position.x<=0)//화면밖으로 나갈시
        {
            Destroy(A_Zone);
            A_Zone = B_Zone;
            Make();
        }
    }
    private void Awake()
    {
        GS = GameState.Play;
        GUI.SetActive(true);
        Cover.SetActive(false);
        D = true;
    }

    
    private void Update()
    {
        
        if (D==true)
        {
            Meter += Time.deltaTime * Speed;
            RText.text = Meter.ToString("N1")+"M".ToString();
            Move();
        }
        else
        {
            Result.text = RText.text;
            //GUI.SetActive(false);
            Death();
        }
        
               
    }

    void Make()//생성
    {
        int A = Random.RandomRange(0, Block.Length);
        B_Zone = Instantiate
            (Block[A], new Vector3(29, -7, 0), transform.rotation) as GameObject;
    }
    void Death()
    {
        D = false;

        Cover.SetActive(true);
    }
    //public void Reply()
    //{
    //    Application.LoadLevel("Game");
    //}
    //public void Main()
    //{
    //    Application.LoadLevel("Main");
    //}
}
