using UnityEngine;

public class DinoSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [Tooltip("Prefab ของไดโนเสาร์ที่จะให้ Spawn")]
    public GameObject dinoPrefab;
    
    [Tooltip("จำนวนไดโนเสาร์ที่จะ Spawn ทั้งหมด")]
    public int spawnCount = 10;
    
    [Tooltip("ใช้กำหนดขอบเขตในการ Spawn (X, Y, Z) โดยจะ Spawn แบบสุ่มในกล่องนี้")]
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);

    void Start()
    {
        if (dinoPrefab == null)
        {
            Debug.LogError("ยังไม่ได้ลาก Dino Prefab มาใส่ใน DinoSpawner ครับ!");
            return;
        }

        SpawnDinosaurs();
    }

    void SpawnDinosaurs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // สุ่มตำแหน่งภายใน spawnAreaSize (ยึดจากตำแหน่งของ Spawner เป็นตรงกลาง)
            Vector3 randomPos = new Vector3(
                transform.position.x + Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0f, // บังคับให้อยู่ติดพื้น (Y = 0)
                transform.position.z + Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            // สุ่มการหมุนเฉพาะแกน Y ให้หันหน้าไปคนละทิศทาง
            Quaternion randomRot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            // สร้างไดโนเสาร์
            Instantiate(dinoPrefab, randomPos, randomRot);
        }
    }

    // ฟังก์ชันนี้ช่วยวาดกล่องสีเขียวๆ ในหน้า Scene เพื่อให้เรากะขนาดพื้นที่ Spawn ได้ง่ายขึ้น
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position, spawnAreaSize);
    }
}
