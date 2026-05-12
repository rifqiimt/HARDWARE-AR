using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ditambahkan untuk memuat scene

// Namanya kita ubah total menjadi HardwareCategoryData agar Unity 6 tidak error
[System.Serializable]
public class HardwareCategoryData
{
    [Tooltip("Harus sama persis dengan yang ada di script module.cs (Misal: SSD)")]
    public string kataKunci;        
    public GameObject grupModel3D;  // Masukkan folder 3D model ke sini
    public GameObject grupTombolUI; // Masukkan folder Tombol UI tipe ke sini
    
    [Tooltip("Masukkan Panel Informasi khusus hardware ini ke sini")]
    public GameObject grupInfoPanel; 

    // --- VARIABEL TERSEMBUNYI UNTUK MENYIMPAN POSISI AWAL ---
    [HideInInspector] public Vector3 posisiAwal;
    [HideInInspector] public Quaternion rotasiAwal;
    [HideInInspector] public Vector3 skalaAwal;
}

// PERHATIKAN: Nama class di bawah ini SEKARANG SAMA PERSIS dengan nama file Anda (SceneAR)
public class SceneAR : MonoBehaviour
{
    [Header("Pengaturan Grup Hardware")]
    public HardwareCategoryData[] daftarHardware;

    private void Start()
    {
        // 1. Baca pesan yang dikirim dari tombol di scene Module (Default: SSD)
        string pesanMasuk = PlayerPrefs.GetString("TargetHardware", "SSD");

        // 2. Cek semua grup 3D dan UI
        foreach (HardwareCategoryData grup in daftarHardware)
        {
            // Simpan posisi, rotasi, dan skala asli dari setiap grup 3D saat pertama kali dimuat
            if (grup.grupModel3D != null)
            {
                grup.posisiAwal = grup.grupModel3D.transform.localPosition;
                grup.rotasiAwal = grup.grupModel3D.transform.localRotation;
                grup.skalaAwal = grup.grupModel3D.transform.localScale;
            }

            // Jika kata kunci cocok, NYALAKAN grup tersebut
            if (grup.kataKunci == pesanMasuk)
            {
                if (grup.grupModel3D != null) grup.grupModel3D.SetActive(true);
                if (grup.grupTombolUI != null) grup.grupTombolUI.SetActive(true);
                if (grup.grupInfoPanel != null) grup.grupInfoPanel.SetActive(true); // Nyalakan Panel Info
            }
            // Jika tidak cocok, MATIKAN (Sembunyikan) grup tersebut
            else
            {
                if (grup.grupModel3D != null) grup.grupModel3D.SetActive(false);
                if (grup.grupTombolUI != null) grup.grupTombolUI.SetActive(false);
                if (grup.grupInfoPanel != null) grup.grupInfoPanel.SetActive(false); // Matikan Panel Info
            }
        }
    }

    // --- TAMBAHAN: FUNGSI UNTUK MERESET POSISI OBJEK AR ---
    public void ResetPosisiObjek()
    {
        foreach (HardwareCategoryData grup in daftarHardware)
        {
            if (grup.grupModel3D != null)
            {
                // Kembalikan posisi, rotasi, dan skala ke nilai aslinya
                grup.grupModel3D.transform.localPosition = grup.posisiAwal;
                grup.grupModel3D.transform.localRotation = grup.rotasiAwal;
                grup.grupModel3D.transform.localScale = grup.skalaAwal;
            }
        }
        Debug.Log("Posisi objek AR telah di-reset!");
    }

    // --- FUNGSI KEMBALI KE HOME ---
    public void exit()
    {
        SceneManager.LoadScene("module");
    }
}