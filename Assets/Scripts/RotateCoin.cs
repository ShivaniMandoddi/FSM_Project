using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.up *rotationSpeed*Time.deltaTime);
    }
}
