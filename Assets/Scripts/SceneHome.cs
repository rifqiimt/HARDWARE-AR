using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public void mulai()
    {
        SceneManager.LoadScene("module");
    }

    public void kuis()
    {
        SceneManager.LoadScene("quiz");
    }

    public void panduan()
    {
        SceneManager.LoadScene("panduan");
    }
    
    public void tentang()
    {
        SceneManager.LoadScene("tentang");
    }
}
