using UnityEngine;

public class DebugSpawner : MonoBehaviour
{
    [Tooltip("Tarik objek 3D lu (misal: Group Motherboard) ke sini")]
    public GameObject arObject;

    void Update()
    {
        // Kalau pencet tombol Spasi di keyboard komputer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (arObject != null)
            {
                // 1. Nyalain bapaknya
                arObject.SetActive(true);
                
                // 2. Paksa nyalain anak pertamanya (misal: ATX.obj) biar wujudnya muncul!
                if (arObject.transform.childCount > 0)
                {
                    arObject.transform.GetChild(0).gameObject.SetActive(true);
                }

                // 3. Taruh agak jauh: 1.5 meter di depan kamera, turunin dikit ke bawah
                arObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f + new Vector3(0, -0.3f, 0);
                
                // 4. Bikin objeknya otomatis muter ngadep ke kamera lu
                arObject.transform.LookAt(Camera.main.transform);
                // Putar balik 180 derajat kalau misalnya kebalik (opsional)
                // arObject.transform.Rotate(0, 180, 0);

                Debug.Log("Objek AR DIPAKSA MUNCUL DAN ANAKNYA DINYALAIN!");
            }
        }
    }
}