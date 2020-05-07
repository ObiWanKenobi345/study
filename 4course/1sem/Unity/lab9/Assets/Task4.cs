using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4 : MonoBehaviour
{
    public float speed = 5;
    public GameObject player;
    private Rigidbody rb;
    private Renderer rend;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, Time.deltaTime);  
        

        if (Input.anyKeyDown)
        {            
            rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);            
        }

    }
}
