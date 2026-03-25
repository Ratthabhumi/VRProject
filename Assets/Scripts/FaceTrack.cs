using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mainCameraTransform;

    void Start()
    {
        // หากล้องหลักของ XR automatically
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogError("หา Main Camera ไม่เจอ! เช็กในซีนด้วยครับ");
        }
    }

    void LateUpdate()
    {
        // ใช้ LateUpdate เพื่อให้แน่ใจว่ากล้องขยับเสร็จแล้ว ค่อยสั่งให้ป้ายหันตาม
        if (mainCameraTransform != null)
        {
            // คำนวณทิศทางจากป้ายไปหากล้อง
            Vector3 targetPosition = mainCameraTransform.position;
            
            // สั่งให้ object หันหน้าเข้าหาเป้าหมาย
            transform.LookAt(targetPosition);
            
            // เพื่อไม่ให้ป้ายกลับหัวกลับหางเวลาหันกล้องเร็วๆ เราต้องกลับทิศทาง Y 180 องศา
            transform.Rotate(0, 180, 0); 
        }
    }
}