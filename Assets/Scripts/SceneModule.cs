using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class module : MonoBehaviour
{
    [Tooltip("Ketik nama SATU scene AR gabungan Anda di sini")]
    public string namaSceneAR = "SceneAR"; // Ubah sesuai nama scene AR Anda nanti

    // Tombol kembali ke home tetap sama
    public void exit()
    {
        SceneManager.LoadScene("home");
    }

    // --- LOGIKA BARU UNTUK TOMBOL HARDWARE ---

    public void motherboard()
    {
        PlayerPrefs.SetString("TargetHardware", "Motherboard"); // Tinggalkan pesan
        PlayerPrefs.Save();
        SceneManager.LoadScene(namaSceneAR); // Pindah ke 1 scene AR yang sama
    }

    public void cpu()
    {
        PlayerPrefs.SetString("TargetHardware", "CPU");
        PlayerPrefs.Save();
        SceneManager.LoadScene(namaSceneAR);
    }

    public void ram()
    {
        PlayerPrefs.SetString("TargetHardware", "RAM");
        PlayerPrefs.Save();
        SceneManager.LoadScene(namaSceneAR);
    }

    public void ssd()
    {
        PlayerPrefs.SetString("TargetHardware", "SSD");
        PlayerPrefs.Save();
        SceneManager.LoadScene(namaSceneAR);
    }

    public void hddd()
    {
        PlayerPrefs.SetString("TargetHardware", "HDD");
        PlayerPrefs.Save();
        SceneManager.LoadScene(namaSceneAR);
    }
}