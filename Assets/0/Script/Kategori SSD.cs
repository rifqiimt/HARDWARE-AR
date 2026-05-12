using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kategori_SSD : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Kategori");
    }

    public void Inci()
    {
        SceneManager.LoadScene("Inci");
    }

    public void mSATA()
    {
        SceneManager.LoadScene("Penjelasan SSD mSATA");
    }

    public void M()
    {
        SceneManager.LoadScene("M");
    }
}
