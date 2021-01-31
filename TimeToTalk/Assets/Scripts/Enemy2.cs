using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierState
{
    Fire,
    Death
}
public class Enemy2 : MonoBehaviour
{
    public Animator ene2;
    public SoldierState SS;
    public Rigidbody rb;
    public GameObject Ene2;
    public GameObject EBullet;
    public GameObject FirePoint;
    
    

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        ene2.SetBool("State", false);
        SS = SoldierState.Fire;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Ene2.transform.position.z > 0 || Ene2.transform.position.z < 1)
        //{
        //    Destroy(Ene2, 1);
        //}
        if (SS == SoldierState.Fire)
        {
            this.transform.position += Vector3.left * 0.5f * Time.deltaTime;
        }
        if (Ene2.transform.position.x < 13 && Ene2.transform.position.x > 12.5)
        {
            ene2.SetBool("State",true);
            Fire();
            
        }
        else
        {
            ene2.SetBool("State", false);
        }
        if(Ene2.transform.position.x < 3 && Ene2.transform.position.x > 2.6)
        {
            ene2.SetBool("State", true);
            Fire();
            
        }
        //if (Ene2.transform.position.x < -3 && Ene2.transform.position.x > -3.5)
        //{
        //    ene2.SetBool("State", true);
        //    Fire();
        //    
        //}
        //if (Ene2.transform.position.x < 0.5 && Ene2.transform.position.x > 0.3)
        //{
        //    ene2.SetBool("State", true);
        //    Fire();
        //    
        //}
        //if (Ene2.transform.position.x < -1 && Ene2.transform.position.x > -1.2)
        //{
        //    ene2.SetBool("State", true);
        //    Fire();
        //    
        //}

    }
    void Fire()
    {
        CreateBullet();
        

    }
    void CreateBullet()
    {
        Instantiate(EBullet, FirePoint.transform.position, FirePoint.transform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            
            
            rb.AddForce(Vector3.right * 100, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 100, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);
            Destroy(Ene2, 2);
        }
    }
}
