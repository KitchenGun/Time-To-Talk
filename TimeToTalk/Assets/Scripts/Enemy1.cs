using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState
{
    Run,
    Death
}

public class Enemy1 : MonoBehaviour
{
    public Animator ene1;
    public ZombieState ZS;
    public Rigidbody rb;
    public GameObject Ene1;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        ZS = ZombieState.Run;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(ZS==ZombieState.Run)
        {
            this.transform.position+=Vector3.left * 0.8f * Time.deltaTime;
        }
        if (Ene1.transform.position.z > 8.3 || Ene1.transform.position.z < 7.7)
        {
            Destroy(Ene1, 1);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Bullet")
        {
            Debug.Log("kill");
            ZS = ZombieState.Death;
            rb.AddForce(Vector3.right*100, ForceMode.Impulse);
            rb.AddForce(Vector3.up*100, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
            Destroy(Ene1, 1);
        }
    }
}
