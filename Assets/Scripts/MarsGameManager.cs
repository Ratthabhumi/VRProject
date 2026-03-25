using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MarsGameManager : MonoBehaviour
{
    public static MarsGameManager Instance; 

    [Header("UI Panels")]
    public GameObject startMenuCanvas; 
    public GameObject gameOverPanel; 

    [Header("UI Score & Time")]
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI timeText;  
    public TextMeshProUGUI finalScoreText; 
    
    [Header("Game Settings")]
    public float gameTime = 180f; // ตั้งเป็น 3 นาทีตามรูปของพี่
    private float initialTime; 
    
    [Header("Audio Effects")]
    public AudioClip scoreSound; 
    private AudioSource audioSource;

    private int currentScore = 0;
    private bool isPlaying = false; 

    void Awake()
    {
        if (Instance == null) Instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        
        initialTime = gameTime; 

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        // มั่นใจว่าเริ่มมาหน้าเมนูต้องเปิดอยู่
        if (startMenuCanvas != null) startMenuCanvas.SetActive(true);
    }

    void Update()
    {
        if (isPlaying)
        {
            gameTime -= Time.deltaTime; 
            if (gameTime <= 0)
            {
                gameTime = 0;
                GameOver(); 
            }
            UpdateTimeUI(); 
        }
    }

    public void StartGame()
    {
        // ปิดทุกป้าย แล้วเริ่มเล่น
        if (startMenuCanvas != null) startMenuCanvas.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        currentScore = 0;
        gameTime = initialTime; 
        isPlaying = true;
        UpdateScoreUI();
    }

    // --- ฟังก์ชันใหม่: กด Exit เพื่อกลับหน้าเมนูหลัก ---
    public void BackToMenu()
    {
        isPlaying = false; // หยุดนับเวลา
        gameTime = initialTime; // รีเซ็ตเวลา
        currentScore = 0; // รีเซ็ตคะแนน
        
        UpdateScoreUI();
        UpdateTimeUI();

        // ปิดหน้าจบเกม (ถ้าเปิดอยู่) และเปิดหน้าเมนูหลักขึ้นมาใหม่
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (startMenuCanvas != null) startMenuCanvas.SetActive(true);
        
        Debug.Log("กลับสู่หน้าเมนูหลักเรียบร้อย");
    }

    public void AddScore(int points)
    {
        if (isPlaying) 
        {
            currentScore += points;
            UpdateScoreUI();
            if (scoreSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(scoreSound);
            }
        }
    }

    void UpdateScoreUI() => scoreText.text = "Score: " + currentScore;
    void UpdateTimeUI() => timeText.text = "Time: " + Mathf.Ceil(gameTime).ToString() + "s";

    void GameOver()
    {
        isPlaying = false;
        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        if (finalScoreText != null) finalScoreText.text = "Your Score: " + currentScore;
    }

    // ฟังก์ชัน Restart แบบโหลด Scene ใหม่ (ใช้กรณีอยากล้างค่าทุกอย่างในโลก 3D จริงๆ)
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ฟังก์ชันสำหรับปุ่มปิดเกม (Quit Game)
    public void ExitGame()
    {
        Debug.Log("กำลังออกจากเกม...");
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}