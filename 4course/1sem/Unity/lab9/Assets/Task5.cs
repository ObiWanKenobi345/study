using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();        

        if (Input.GetMouseButtonDown(0)) {
            GameObject spf = GameObject.CreatePrimitive (PrimitiveType.Sphere);
            spf.transform.position = new Vector3 (Random.Range (render.bounds.min.x, render.bounds.max.x),
            gameObject.transform.position.y + 5, 
            Random.Range (render.bounds.min.z, render.bounds.max.z));
            spf.AddComponent<Rigidbody> ();
        }
    }
}
