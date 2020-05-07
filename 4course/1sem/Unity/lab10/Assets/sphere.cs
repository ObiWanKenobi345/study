using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public float speed = 4;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        rb.AddForce(movement * speed);
        

    }

    void OnCollisionEnter(Collision collision) {
        var gameObject = collision.gameObject;
        var name = gameObject.name;

        if (name.Contains("gCube")) {
            Destroy(gameObject);
        } else if (name.Contains("bCube")) {
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y + 10.0f,
                gameObject.transform.position.z
            );
        } else if (name.Contains("rCube")) {
            Destroy(GetComponent<MeshRenderer>());
        }
    }
}
