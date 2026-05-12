using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Wajib untuk mengganti warna Button (Image)
using TMPro; // Wajib jika menggunakan TextMeshPro untuk teksnya

[RequireComponent(typeof(Animator))]
public class ARAnimator : MonoBehaviour
{
    private Animator anim;
    private bool isBongkar = false; // Status saat ini

    [Header("Nama Animasi")]
    public string namaAnimasiBongkar = "Anim_BongkarSATA";
    public string namaAnimasiTutup = "Anim_TutupSATA";

    [Header("Pengaturan UI Tombol")]
    [Tooltip("Masukkan komponen Image dari Button lu")]
    public Image tombolBackground;
    [Tooltip("Masukkan komponen Text (TMP) yang ada di dalam Button lu")]
    public TextMeshProUGUI tombolTeks;

    void Start()
    {
        anim = GetComponent<Animator>();
        UpdateVisualTombol(); // Set visual awal tombol saat mulai
    }

    // Fungsi ini yang akan dipanggil saat Button diklik di Unity
    public void ToggleAnimasi()
    {
        // Balikkan status: kalau true jadi false, kalau false jadi true
        isBongkar = !isBongkar;

        if (isBongkar)
        {
            // Mainkan animasi bongkar
            anim.Play(namaAnimasiBongkar);
            
            // Logika untuk memunculkan hotspot internal bisa ditaruh di sini
            // (seperti StartCoroutine memunculkan hotspot yang lu buat sebelumnya)
        }
        else
        {
            // Mainkan animasi tutup
            anim.Play(namaAnimasiTutup);
            
            // Logika menyembunyikan hotspot internal ditaruh di sini
        }

        // Update tampilan warna dan teks tombol
        UpdateVisualTombol();
    }

    // Fungsi khusus untuk ngubah warna dan tulisan
    private void UpdateVisualTombol()
    {
        if (tombolBackground != null && tombolTeks != null)
        {
            if (isBongkar)
            {
                // State: Sedang terbongkar -> Tombol berubah jadi "TUTUP" (Warna Hijau)
                tombolTeks.text = "TUTUP (RESEAL)";
                tombolBackground.color = new Color32(16, 185, 129, 255); // Hijau Emerald
            }
            else
            {
                // State: Tertutup -> Tombol berubah jadi "BONGKAR" (Warna Merah)
                tombolTeks.text = "BONGKAR (INSPECT)";
                tombolBackground.color = new Color32(220, 38, 38, 255); // Merah
            }
        }
    }
}