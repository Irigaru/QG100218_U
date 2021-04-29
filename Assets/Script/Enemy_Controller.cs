using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float velocidad, startVel;
    private Rigidbody2D rd2d;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();      
    }

    private void FixedUpdate()
    {
        if (Controller.inicio == 1)
            velocidad = startVel;
        else if (Controller.inicio == 0 || Controller.inicio == 3)
        {
            velocidad = 0.0f;
        }
        else if (Controller.inicio == 1)
            velocidad = startVel;

        rd2d.velocity = Vector2.left * velocidad;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Destroy(gameObject);
        }
    }
}
