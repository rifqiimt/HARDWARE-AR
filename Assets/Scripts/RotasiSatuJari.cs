using UnityEngine;

public class RotasiSatuJari : MonoBehaviour
{
    // Mengatur seberapa cepat objek berputar
    public float kecepatanPutar = 0.2f;

    void Update()
    {
        // Memastikan hanya ada 1 jari yang menyentuh layar HP
        if (Input.touchCount == 1)
        {
            Touch jari = Input.GetTouch(0);

            // Membaca saat jari mulai digeser di layar
            if (jari.phase == TouchPhase.Moved)
            {
                // Menghitung arah putaran atas-bawah dan kiri-kanan
                float putarAtasBawah = jari.deltaPosition.y * kecepatanPutar;
                float putarKiriKanan = -jari.deltaPosition.x * kecepatanPutar;

                // Menerapkan putaran ke objek secara bebas di dunia 3D
                transform.Rotate(putarAtasBawah, putarKiriKanan, 0, Space.World);
            }
        }
    }
}