using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LGA : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Materi");
    }

    public void PGA()
    {
        SceneManager.LoadScene("PGA");
    }

    public void MiniATX()
    {
        SceneManager.LoadScene("MiniATX");
    }


}
