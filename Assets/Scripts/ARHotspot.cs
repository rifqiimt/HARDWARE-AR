using UnityEngine;

public class ARHotspot : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Masukkan objek Panel/Teks informasi yang ingin dimunculkan/disembunyikan")]
    public GameObject infoPanel;

    [Header("Settings")]
    [Tooltip("Centang jika ingin teks selalu menghadap ke kamera HP")]
    public bool faceCamera = true;

    private Camera mainCam;

    private void Start()
    {
        // Cari kamera AR secara otomatis
        mainCam = Camera.main;

        // Pastikan saat mulai, teks informasinya disembunyikan dulu
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        // Membuat canvas selalu menghadap ke arah kamera pengguna
        if (faceCamera && mainCam != null)
        {
            transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward,
                             mainCam.transform.rotation * Vector3.up);
        }
    }

    // Fungsi ini dipanggil saat tombol/titik pointer diklik
    public void ToggleInformation()
    {
        if (infoPanel != null)
        {
            // Jika sedang tertutup, buka. Jika sedang terbuka, tutup.
            bool isCurrentlyActive = infoPanel.activeSelf;
            infoPanel.SetActive(!isCurrentlyActive);
        }
    }
}