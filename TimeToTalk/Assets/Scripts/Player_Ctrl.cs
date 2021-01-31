using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    Run,
    Jump,
    Fire,
    Death
}
public class Player_Ctrl : MonoBehaviour
{
    public static bool D;
    public PlayerState Ps;
    public float JumpPower = 500f;
    public GameObject FireT;
    public Animator Ani;
    public int Bullet=5;

    public Image StoryD0;
    public Image StoryD1;
    public Image StoryD2;
    public Image StoryD3;
    public Image StoryD4;

    public Image NoRun;

    public AudioClip[] Sound;

    public Text BText;
    public GameObject SEET;

    Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        FireT.SetActive(false);
        rb =GetComponent<Rigidbody>();
        //총알 이미지 필요 오디오 삽입 필요 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            NoRun.transform.position= new Vector3(630, 720, 0);
            Destroy(NoRun, 3);
        }
        Debug.Log(Bullet);
        rb.WakeUp();
		if(Input.GetKeyDown(KeyCode.Space)&&Ps!=PlayerState.Death)
        {
            if(Ps==PlayerState.Run)
            {
                Jump();
            }
            
        }
        BText.text = Bullet.ToString();

    }
    public void Jump()
    {
        if (Ps != PlayerState.Death && Ps != PlayerState.Jump && Ps != PlayerState.Fire) 
        {
            if (Ps == PlayerState.Run)
            {
                
                Ps = PlayerState.Jump;
                Ani.SetTrigger("Jump");
                rb.AddForce(new Vector3(0, JumpPower, 0));
            }
        }
    }
    
    void Run()
    {
        Ps = PlayerState.Run;
        
        Ani.SetTrigger("Run");
    }
    public void Fire()
    {
        if (Ps != PlayerState.Death &&  Bullet > 0) 
        {
            if (Ps == PlayerState.Run)
            {
                FireT.SetActive(true);
                Ani.SetTrigger("Fire");
                SoundPlay(1);
                if (Bullet != 0)
                {

                    Bullet--;
                }
                Run();
            }
        }
    }
    void GameOver0()//낙사
    {
        Ps = PlayerState.Death;
        SEET.SendMessage("Death");
        Debug.Log("die");
        Destroy(this);
        SoundPlay(2);
        StoryD0.transform.position = new Vector3(630, 720, 0);
    }
    void GameOver1()//좀비
    {
        Ps = PlayerState.Death;
        SEET.SendMessage("Death");
        Debug.Log("die");
        Destroy(this);
        SoundPlay(2);
        StoryD1.transform.position = new Vector3(630, 720, 0);
    }
    void GameOver2()//군인
    {
        Ps = PlayerState.Death;
        SEET.SendMessage("Death");
        Debug.Log("die");
        Destroy(this);
        SoundPlay(2);
        StoryD2.transform.position = new Vector3(630, 720, 0);
    }
    void GameOver3()//총알
    {
        Ps = PlayerState.Death;
        SEET.SendMessage("Death");
        Debug.Log("die");
        Destroy(this);
        SoundPlay(2);
        StoryD3.transform.position = new Vector3(630, 720, 0);
    }
    void GameOver4()//스펙터
    {
        Ps = PlayerState.Death;
        SEET.SendMessage("Death");
        Debug.Log("die");
        Destroy(this);
        SoundPlay(2);
        StoryD4.transform.position = new Vector3(630, 720, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(Ps!=PlayerState.Run && Ps != PlayerState.Death)
        {
            Run();
        }
    }
    void BulletGet()
    {
        Bullet++;
        SoundPlay(0);

    }
    private void OnTriggerEnter(Collider other)
    {
        rb.WakeUp();
        if(other.gameObject.name=="Bullet")
        {

            Destroy(other.gameObject);
            BulletGet();
        }
        if (other.gameObject.name == "DeathZone"&&Ps!=PlayerState.Death)
        {
            GameOver0();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "Die1") 
        {
            GameOver1();
        }
        if(collision.collider.name == "Die2")
        {
            GameOver2();
        }
        if (collision.collider.name == "Die3")
        {
            GameOver4();
        }
        if (collision.collider.name == "EBullet")
        {
            GameOver3();
        }
    }
    void SoundPlay(int Num)
    {
        GetComponent<AudioSource>().clip = Sound[Num];
        GetComponent<AudioSource>().Play();
    }

}
