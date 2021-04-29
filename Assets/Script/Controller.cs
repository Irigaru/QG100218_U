using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    [SerializeField]
    public float parallaxspeed = 0.2f;
    public static int inicio;
    public GameObject texto1;
    public GameObject texto2;
    public GameObject pause;

    public float scaleTime = 6f;
    public float scaleInc = 0.25f;

    public RawImage background;
    public RawImage platform;

    private Animator anim;
    public GameObject enemygen;
    public GameObject enemygen2;

    void Start()
    {
        texto1.SetActive(true);
        texto2.SetActive(true);
        pause.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Inicio_Pause();

        if (inicio == 1 || inicio == 2)
        {
            texto1.SetActive(false);
            texto2.SetActive(false);
            Paralax();
        }
    }

    private void Paralax()
    {
        float finalspeed = parallaxspeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalspeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalspeed * 2, 0f, 1f, 1f);
    }

    private void Inicio_Pause()
    {
        if (Input.GetKeyDown("return") && inicio == -1)
        {            
            inicio = 1;
            Audio.aud.Play();
            pause.SetActive(false);
            enemygen.SendMessage("startspawn");
            enemygen2.SendMessage("startspawn");
            InvokeRepeating("GameTimeScale", scaleTime, scaleTime);
        }

      else if (Input.GetKeyDown("left ctrl"))
        {
            inicio = 0;
            pause.SetActive(true);
        }
        else if (Input.GetKeyDown("up"))
        {
            inicio = 2;
            pause.SetActive(false);
        }
        else if (Input.GetKeyDown("return") && inicio == 0)
        {
            inicio = 1;
            pause.SetActive(false);       
        }
        else if (Input.GetKeyDown("down") && inicio == 0)
        {
            SendMessage("ResetTimeScale");
        }
    }

    public void GameTimeScale()
    {
        Time.timeScale += scaleInc;
        Debug.Log("Ritmo aumentado: " + Time.timeScale.ToString());
    }

    public void ResetTimeScale()
    {
        CancelInvoke("GameTimeScale");
        Time.timeScale = 1f;
        Debug.Log("Ritmo reestablecido: " + Time.timeScale.ToString());
    }

}
