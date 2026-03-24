using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TaeGreeting : MonoBehaviour
{
    [Tooltip("The audio clip to play when the Player enters the trigger.")]
    public AudioClip greetingClip;
    
    private AudioSource audioSource;
    private bool hasGreeted = false; // ตัวแปรเช็กว่าทักไปหรือยัง

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        // ตั้งค่า AudioSource เบื้องต้น
        audioSource.playOnAwake = false;
        audioSource.loop = false; // กันเหนียว ไม่ให้มันวนลูปเอง
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1. เช็ก Tag "Player"
        // 2. เช็กว่าเสียง "ต้องไม่กำลังเล่นอยู่" (กันเสียงซ้อนรัวๆ)
        // 3. (Optional) ถ้าอยากให้ทักแค่ครั้งเดียวต่อการเดินเข้า 1 รอบ ให้เช็ก hasGreeted ด้วย
        if (other.CompareTag("Player") && !audioSource.isPlaying && !hasGreeted)
        {
            if (greetingClip != null)
            {
                audioSource.PlayOneShot(greetingClip);
                hasGreeted = true; // ล็อคไว้ว่าทักแล้ว
            }
            else
            {
                Debug.LogWarning("TaeGreeting: No AudioClip assigned!", this);
            }
        }
    }

}