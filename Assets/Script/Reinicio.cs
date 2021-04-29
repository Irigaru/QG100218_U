using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{

    public static void reinicio()
    {
            SceneManager.LoadScene("Principal");
    }
}
