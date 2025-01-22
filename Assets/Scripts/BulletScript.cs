using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    private float shootforce = 30f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector3.forward * shootforce ,ForceMode.Impulse);
    }
    //private void Update()
    //{
        
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Collidable")
        {
            Destroy(gameObject);
        }
    }
}
