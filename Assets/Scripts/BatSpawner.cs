using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [Tooltip("ลาก Prefab ของไม้เบสบอล (Bat) มาใส่ช่องนี้")]
    public GameObject batPrefab;

    [Tooltip("จำนวนไม้เบสบอลทั้งหมดที่ต้องการสร้าง")]
    public int spawnCount = 5;

    [Tooltip("ระยะห่างระหว่างไม้เบสบอลแต่ละอัน (แกน X, Y, Z) เช่น ใส่ X=1 ไว้ให้เรียงเป็นแถว")]
    public Vector3 spawnOffset = new Vector3(1f, 0f, 0f);

    [Header("Color Settings")]
    [Tooltip("เปิดฟังก์ชันเพิ่มความหลากหลายของสีให้ไม้")]
    public bool addColorVariation = true;
    
    [Tooltip("ระดับความเพี้ยนของสี (0.1 สุ่มนิดเดียว, 0.5 สุ่มเยอะ)")]
    public float colorVariationAmount = 0.2f;

    void Start()
    {
        if (batPrefab == null)
        {
            Debug.LogError("ยังไม่ได้ลาก Bat Prefab มาใส่ใน BatSpawner ครับ!");
            return;
        }

        SpawnBats();
    }

    void SpawnBats()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // คำนวณตำแหน่งจากระยะห่างที่ตั้งไว้ 
            // ตัวแรกจะอยู่ตำแหน่งเดียวกับ Spawner (i=0) ตัวต่อๆ ไปก็จะขยับออกไปเรื่อยๆ (i=1, 2, 3...)
            Vector3 spawnPosition = transform.position + (spawnOffset * i);

            // สร้างไม้เบสบอลตามตำแหน่ง และอิงมุมหัน (Rotation) ตามตัว Spawner
            GameObject spawnedBat = Instantiate(batPrefab, spawnPosition, transform.rotation);

            // ปรับสีแบบสุ่มเพียงเล็กน้อยให้แต่ละอันไม่เหมือนกันเป๊ะๆ (Variation)
            // (ต้องมั่นใจว่าไม้เบสบอลมี MeshRenderer ให้เปลี่ยนสีด้วยนะ)
            if (addColorVariation)
            {
                Renderer batRenderer = spawnedBat.GetComponentInChildren<Renderer>();
                if (batRenderer != null)
                {
                    // ดูสีต้นฉบับก่อน
                    Color originalColor = batRenderer.material.color;
                    
                    // ปรับสี บวก/ลบ ความต่างแบบสุ่มนิดหน่อย 
                    Color variedColor = new Color(
                        originalColor.r + Random.Range(-colorVariationAmount, colorVariationAmount),
                        originalColor.g + Random.Range(-colorVariationAmount, colorVariationAmount),
                        originalColor.b + Random.Range(-colorVariationAmount, colorVariationAmount),
                        originalColor.a
                    );
                    
                    // อัปเดตสีกลับเข้าไป
                    batRenderer.material.color = variedColor;
                }
            }
        }
    }

    // ฟังก์ชันนี้ช่วยแสดงเส้นวงกลมในหน้าฉาก (Scene) เวลาคลิกที่ตัว Spawner 
    // จะได้เล็งและกะระยะห่างได้ง่ายขึ้นก่อนกด Play เล่นเกมจริงๆ
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 expectedPosition = transform.position + (spawnOffset * i);
            Gizmos.DrawWireSphere(expectedPosition, 0.15f); 
        }
    }
}
