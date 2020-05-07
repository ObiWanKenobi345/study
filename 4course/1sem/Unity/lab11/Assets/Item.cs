using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int force = 100;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetKey(KeyCode.Mouse0))
        {
            if(hit.collider.gameObject == this.gameObject)
            {
                GetComponent<Renderer>().material.color = GetRandomMaterialColor();

                var direction = new Vector3(
                    transform.position.x + Random.Range(-10.0f, 10.0f),
                    transform.position.y, 
                    transform.position.z + Random.Range(-10.0f, 10.0f)
                );

                rb.AddForce(direction * force);
            }
        }
    }

    Color GetRandomMaterialColor() {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    
}
