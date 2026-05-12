using System.Collections;
using UnityEngine;

public class SlidingPanel : MonoBehaviour
{
    [Header("UI Reference")]
    [Tooltip("Tarik RectTransform dari Panel yang ingin dianimasikan ke sini")]
    public RectTransform panelRect;

    [Tooltip("Tarik tombol info_open ke sini agar disembunyikan saat panel terbuka")]
    public GameObject openButton;

    [Header("Slide Settings")]
    [Tooltip("Posisi X saat panel disembunyikan (Biasanya selebar panel, misal: 600)")]
    public float hiddenPosX = 600f; 
    
    [Tooltip("Posisi X saat panel tampil penuh di layar (Biasanya 0)")]
    public float visiblePosX = 0f;  
    
    [Tooltip("Kecepatan animasi meluncur")]
    public float slideSpeed = 12f;  

    private bool isPanelVisible = false;
    private Coroutine slideCoroutine;

    private void Start()
    {
        // Pastikan saat mulai, panel berada di posisi tersembunyi
        if (panelRect != null)
        {
            panelRect.anchoredPosition = new Vector2(hiddenPosX, panelRect.anchoredPosition.y);
            isPanelVisible = false;
        }
    }

    // Fungsi ini yang akan dipanggil oleh Tombol Info
    public void TogglePanel()
    {
        if (panelRect == null) return;

        // Balikkan status (jika buka jadi tutup, jika tutup jadi buka)
        isPanelVisible = !isPanelVisible;
        
        // Menampilkan atau menyembunyikan tombol info_open
        if (openButton != null)
        {
            openButton.SetActive(!isPanelVisible);
        }
        
        // Hentikan animasi sebelumnya jika tombol ditekan cepat-cepat
        if (slideCoroutine != null) 
        {
            StopCoroutine(slideCoroutine);
        }
        
        // Tentukan target posisi X
        float targetX = isPanelVisible ? visiblePosX : hiddenPosX;
        
        // Mulai animasi
        slideCoroutine = StartCoroutine(SlideToPosition(targetX));
    }

    private IEnumerator SlideToPosition(float targetX)
    {
        // Terus bergerak sampai jaraknya sangat dekat dengan target (< 0.5 pixel)
        while (Mathf.Abs(panelRect.anchoredPosition.x - targetX) > 0.5f)
        {
            // Menghitung pergerakan halus menggunakan Lerp
            float newX = Mathf.Lerp(panelRect.anchoredPosition.x, targetX, Time.deltaTime * slideSpeed);
            panelRect.anchoredPosition = new Vector2(newX, panelRect.anchoredPosition.y);
            
            yield return null; // Tunggu ke frame berikutnya
        }

        // Pastikan posisinya tepat di target pada akhir animasi
        panelRect.anchoredPosition = new Vector2(targetX, panelRect.anchoredPosition.y);
    }
}