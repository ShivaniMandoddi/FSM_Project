using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    //bool IsDead = false;
    //public GameObject enemy;
    //public float playerSpeed;
    //public float rotationSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //transform.Rotate(0f, Input.GetAxis("Mouse Y")*rotationSpeed,0f);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Coin")
        {
            Debug.Log("COin collected");
            Destroy(other.gameObject);
        }
    }
}
