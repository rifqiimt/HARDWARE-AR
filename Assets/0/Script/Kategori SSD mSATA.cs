using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kategori_SSD_mSATA : MonoBehaviour
{
    public void kiri()
    {
        SceneManager.LoadScene("Penjelasan SSD mSATA 2280");
    }

    public void tengah()
    {
        SceneManager.LoadScene("Penjelasan SSD mSATA 2260");
    }

    public void kanan()
    {
        SceneManager.LoadScene("Penjelasan SSD mSATA 2242");
    }

    public void Back()
    {
        SceneManager.LoadScene("Penjelasan SSD mSATA");
    }
}
