using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kategori : MonoBehaviour
{
    public void SSD()
    {
        SceneManager.LoadScene("Kategori SSD");
    }

    public void Back()
    {
        SceneManager.LoadScene("Utama");
    }

    public void RAM()
    {
        SceneManager.LoadScene("RAM");
    }
}
