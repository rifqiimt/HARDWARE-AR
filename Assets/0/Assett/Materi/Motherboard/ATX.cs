using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ATX : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Materi");
    }

    public void MicroATX()
    {
        SceneManager.LoadScene("MicroATX");
    }

    public void MiniATX()
    {
        SceneManager.LoadScene("MiniATX");
    }


}
