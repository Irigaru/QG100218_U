using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public int estado = 0;

    private Animator anim;
    private Rigidbody2D rb2d;
    public ParticleSystem dust;

    public int jump_Force = 500;
    public bool jumping = false;
    public GameObject enemygen;
    public GameObject enemygen2;

    private AudioSource aud;
    public AudioClip salto;
    public AudioClip muerte;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        Estado_Personaje();
        anim.SetInteger("estado", estado);
        jump();
    }

    private void Estado_Personaje()
    {//Se desemparejaron los estados del personaje y del juego
        /*if (Controller.inicio == 1)
            estado = 1;
        else if (Controller.inicio == 0)
            estado = 0;
        else if (Controller.inicio == 2)
            estado = 2;
        else if (Controller.inicio == 3)
            estado = 3;*/
        if (Input.GetKeyDown("return"))
        {
            estado = 1;
            Dustplay();
        }
        else if (Input.GetKeyDown("down") && estado == 3)
        {            
            Reinicio.reinicio();
        }
        if (Input.GetKeyDown("left ctrl"))
        {
            estado = 0;
        }
        if (Input.GetKeyDown("up"))
        {
            if (jumping == true)
            {
                estado = 2;
                aud.clip = salto;
                aud.Play();
            }
        }
       /* if (Input.GetKeyDown("down"))
        {
            estado = 4;            
        }else if(Input.GetKeyUp("down"))
        {
            if (jumping == true)
                estado = 1;
            else if (transform.position.y > -212)
                estado = 2;
        }*/
    }

    private void jump()
    {
        if (Input.GetKeyDown("up") && jumping == true)
        {
            rb2d.velocity = Vector2.up * 160.0f;
        }
    }
    // Flor = Suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flor")
        {
            jumping = true;
            Controller.inicio -= 1;
            if(Controller.inicio == 1)
            {
                estado = 1;
            }       
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("antisalto"))
        {
            jumping = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {if (estado == 4)
            {              
                Destroy(collision.gameObject);
            }
            else
            {
                estado = 3;
                Audio.aud.Stop();
                aud.clip = muerte;
                aud.Play();
                Controller.inicio = 0;
                rb2d.velocity = Vector2.up * 160.0f;
                Destroy(GameObject.FindWithTag("Flor"));
                enemygen.SendMessage("cancelspawn", true);
                enemygen2.SendMessage("cancelspawn", true);
                Duststop();
            }          
        }
    }

    void Dustplay()
    {
        dust.Play();
    }

    void Duststop()
    {
        dust.Stop();
    }
}