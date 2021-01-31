using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    private float EBulletSpeed = 600.0f;
    public GameObject Ebullet;
    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(Ebullet, 5.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = Vector3.right*-1 * EBulletSpeed*Time.deltaTime;	
	}

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.name=="Player")
        {
            Destroy(Ebullet);
        }
    }
}
