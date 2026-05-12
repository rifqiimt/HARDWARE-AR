using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicroATX : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Materi");
    }

    public void ATX()
    {
        SceneManager.LoadScene("ATX");
    }

    public void MiniATX()
    {
        SceneManager.LoadScene("MiniATX");
    }


}
