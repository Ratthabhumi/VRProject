using UnityEngine;
using TMPro; // สำคัญ! ต้องมีอันนี้เพื่อใช้ TextMeshPro

public class FloatingPoints : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 1f;    // ความเร็วในการลอยขึ้น
    public float fadeSpeed = 2f;    // ความเร็วในการจางหาย (ยิ่งเยอะยิ่งจางเร็ว)
    public float lifeTime = 1.5f;   // ระยะเวลาที่มันจะอยู่ก่อนจะโดนลบ (วินาที)

    private TextMeshProUGUI textMeshPro;
    private Color textColor;
    private Transform mainCameraTransform;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        
        if (textMeshPro == null)
        {
            Debug.LogError("หา TextMeshPro ไม่เจอใน Object นี้!");
            Destroy(gameObject); // ลบทิ้งถ้าหาของไม่เจอ
            return;
        }

        textColor = textMeshPro.color;

        // หากล้องหลักเพื่อทำ Billboard
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }

        // สั่งลบ Object นี้ทิ้งอัตโนมัติเมื่อหมดเวลา
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 1. ทำให้ Billboard (หันตามกล้อง)
        if (mainCameraTransform != null)
        {
            Vector3 targetPosition = mainCameraTransform.position;
            transform.LookAt(targetPosition);
            transform.Rotate(0, 180, 0); 
        }

        // 2. ทำให้ลอยขึ้นด้านบน
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // 3. ทำให้ค่อยๆ จางไป (เปลี่ยนค่า Alpha ของสี)
        textColor.a -= fadeSpeed * Time.deltaTime;
        textMeshPro.color = textColor;

        // ถ้าจางจนมองไม่เห็นแล้ว ก็ลบทิ้งเลย
        if (textColor.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}