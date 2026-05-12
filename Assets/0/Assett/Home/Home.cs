using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Telah Keluar");
    }

    public void Panduan()
    {
        SceneManager.LoadScene("Panduan");
    }

    public void Kuis()
    {
        SceneManager.LoadScene("Persistent");
    }

    public void Materi()
    {
        SceneManager.LoadScene("Materi");
    }
    
    public void Tentang()
    {
        SceneManager.LoadScene("Tentang");
    }
}
