using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Materi : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Home");
    }
    public void Motherboard()
    {
        SceneManager.LoadScene("ATX");
    }
    public void CPU()
    {
        SceneManager.LoadScene("LGA");
    }
}
