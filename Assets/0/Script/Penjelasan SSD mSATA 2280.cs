using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Penjelasan_SSD_mSATA_2280 : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Kategori SSD mSATA");
    }

    public void ARCamera()
    {
        SceneManager.LoadScene("MSATA 2280");
    }
}
