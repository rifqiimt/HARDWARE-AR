using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Penjelasan_SSD_mSATA : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Kategori SSD");
    }

    public void Kategori()
    {
        SceneManager.LoadScene("Kategori SSD mSATA");
    }
}
