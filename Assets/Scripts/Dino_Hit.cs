using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
// using Unity.Cinemachine; // ปลดคอมเมนต์บรรทัดนี้ถ้าใช้ Cinemachine 3.x
// using Cinemachine;       // ปลดคอมเมนต์บรรทัดนี้ถ้าใช้ Cinemachine 2.x

public class DinoHit : MonoBehaviour
{
    [Header("Settings")]
    public float hitForce = 15f;
    
    [Header("Feedback Effect")]
    [Tooltip("ลาก Prefab ตัวเลข +100 ที่ทำเป็น World Space Canvas มาใส่ช่องนี้")]
    public GameObject pointsFeedbackPrefab; 

    [Header("Color Change Effect")]
    [Tooltip("ลาก MeshRenderer ที่เป็นโมเดลไดโนเสาร์มาใส่ช่องนี้ เพื่อเปลี่ยนสีตอนโดนตี")]
    public Renderer dinoRenderer;
    
    // [Header("Camera Shake (Cinemachine)")]
    // [Tooltip("ลาก CinemachineImpulseSource มาใส่ (ถ้าลง Cinemachine แล้ว ฝากปลดคอมเมนต์โค้ดด้วยครับ)")]
    // public CinemachineImpulseSource cameraShake;

    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody rb;
    private XRGrabInteractable interactable;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        
        // ดึง Component การหยิบจับมาเช็ก
        interactable = GetComponent<XRGrabInteractable>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        // --- 1. เช็กว่าเราไม่ได้กำลัง "หยิบ" ไดโนเสาร์ตัวนี้อยู่ ---
        if (interactable != null && interactable.isSelected)
        {
            return; 
        }

        // --- 2. เช็กว่าโดน "ไม้เบสบอล" ตีไหม (เช็กชื่อ Object ที่มาชน) ---
        if (collision.gameObject.name.Contains("Bat"))
        {
            // [A] ส่งคะแนนไปที่ GameManager
            if (MarsGameManager.Instance != null)
            {
                MarsGameManager.Instance.AddScore(100); 
            }

            // [B] สร้างตัวเลข +100 เด้งขึ้นมาตรงจุดที่โดนตี
            if (pointsFeedbackPrefab != null)
            {
                // สร้าง Object แต้มเด้ง และยกสูงขึ้นมานิดนึง (+Vector3.up * 0.5f)
                Instantiate(pointsFeedbackPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }

            // [C] เล่นแอนิเมชันโดนตี
            if (animator != null) 
            {
                animator.SetTrigger("GetHit");
            }

            // [D] เล่นเสียงร้อง (สุ่ม Pitch ให้เสียงมีสูงต่ำ ไม่น่าเบื่อ)
            if (audioSource != null && audioSource.clip != null)
            {
                // เล่นแบบ OneShot เพื่อให้เสียงไม่ตัดกันเองเวลาหวดรัวๆ
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.PlayOneShot(audioSource.clip);
            }

            // [F] สุ่มเปลี่ยนสีไดโนเสาร์
            if (dinoRenderer != null)
            {
                // สุ่มสีให้สีสดใส (Hue 0-1, Saturation 0.5-1, Value 0.8-1)
                dinoRenderer.material.color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.8f, 1f);
            }

            // [G] ทำให้กล้องสั่น (แบบใช้ Cinemachine)
            // หมายเหตุ: ต้องเอาเครื่องหมาย // ออกเมื่อติดตั้ง Cinemachine แล้ว
            // if (cameraShake != null)
            // {
            //     cameraShake.GenerateImpulseWithForce(0.5f); // สั่นเล็กน้อย
            // }

            // [E] ใส่แรงกระแทกทางฟิสิกส์ให้ตัวปลิว
            if (rb != null)
            {
                // คำนวณทิศทางแรง (จากจุดที่ไม้ตี ไปหาตัวไดโนเสาร์)
                Vector3 forceDirection = transform.position - collision.transform.position;
                forceDirection.y = 0.5f; // ให้ปลิวโด่งขึ้นฟ้าเล็กน้อย
                
                rb.AddForce(forceDirection.normalized * hitForce, ForceMode.Impulse);
            }
        }
    }
}