using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelaaja : MonoBehaviour
{
    public float speed = 10f; 

    void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        transform.position = new Vector3(Camera.main.ViewportToWorldPoint(pos).x, transform.position.y, transform.position.z);
    }
}
