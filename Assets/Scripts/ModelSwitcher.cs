using UnityEngine;
using UnityEngine.UI; // Tambahan wajib untuk memanipulasi UI Image
using TMPro; // Tambahan wajib untuk memanipulasi teks TextMeshPro

public class ModelSwitcher : MonoBehaviour
{
    [Header("Daftar Model 3D")]
    [Tooltip("Masukkan semua model 3D varian ke dalam list ini (misal: Element 0 = SATA, Element 1 = NVMe)")]
    public GameObject[] hardwareModels;

    [Header("Referensi UI Tombol")]
    [Tooltip("Masukkan tombol varian dengan urutan yang SAMA seperti model 3D di atas")]
    public Image[] variantButtons;

    [Header("Referensi UI Judul")]
    [Tooltip("Tarik objek teks Judul (TextMeshPro) dari Canvas ke sini")]
    public TMP_Text titleText;
    [Tooltip("Masukkan daftar teks judul sesuai urutan model (misal: Element 0 = 'M.2 SATA', Element 1 = 'M.2 NVMe')")]
    public string[] hardwareTitles;

    [Header("Pengaturan Warna Tombol")]
    public Color activeColor = new Color(0.21f, 0.76f, 0.94f, 1f); // Warna Cyan PRIMO
    public Color inactiveColor = new Color(0.08f, 0.12f, 0.24f, 0.8f); // Warna Biru Gelap Kaca

    [Header("Referensi KOTAK INFO (BARU)")]
    [Tooltip("Masukkan komponen Outline (Garis Tepi) dari tiap kotak info di panel kanan sesuai urutan")]
    public Outline[] infoCardBorders;
    public Color borderMenyala = new Color(0.21f, 0.76f, 0.94f, 1f); // Warna Cyan
    public Color borderMati = new Color(1f, 1f, 1f, 0f); // Transparan (Garis hilang)

    private void Start()
    {
        // Opsional: Pastikan saat mulai, hanya model pertama (Element 0) yang menyala
        if (hardwareModels.Length > 0)
        {
            ShowModel(0);
        }
    }

    // Fungsi ini akan dipanggil oleh tombol UI (Variant Switcher)
    public void ShowModel(int indexToShow)
    {
        // 1. Matikan semua model terlebih dahulu
        for (int i = 0; i < hardwareModels.Length; i++)
        {
            if (hardwareModels[i] != null)
            {
                hardwareModels[i].SetActive(false);
            }

            // Ubah warna tombol menjadi redup (Inactive)
            if (i < variantButtons.Length && variantButtons[i] != null)
            {
                variantButtons[i].color = inactiveColor;
            }

            // MATIKAN garis tepi kotak info (menjadi transparan)
            if (i < infoCardBorders.Length && infoCardBorders[i] != null)
            {
                infoCardBorders[i].effectColor = borderMati;
            }
        }

        // 2. Nyalakan hanya model yang dipilih sesuai nomor index
        if (indexToShow >= 0 && indexToShow < hardwareModels.Length)
        {
            if (hardwareModels[indexToShow] != null)
            {
                hardwareModels[indexToShow].SetActive(true);
            }

            // Ubah warna tombol yang dipilih menjadi menyala (Active)
            if (indexToShow < variantButtons.Length && variantButtons[indexToShow] != null)
            {
                variantButtons[indexToShow].color = activeColor;
            }

            // 3. Ubah teks judul komponen sesuai pilihan
            if (titleText != null && indexToShow < hardwareTitles.Length)
            {
                titleText.text = hardwareTitles[indexToShow];
            }

            // NYALAKAN garis tepi kotak info yang dipilih
            if (indexToShow < infoCardBorders.Length && infoCardBorders[indexToShow] != null)
            {
                infoCardBorders[indexToShow].effectColor = borderMenyala;
            }
        }
    }
}