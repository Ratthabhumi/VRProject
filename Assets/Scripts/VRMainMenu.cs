using UnityEngine;

public class VRMainMenu : MonoBehaviour
{
    [Header("ลากแผ่น Canvas เมนูมาใส่ช่องนี้")]
    public GameObject menuCanvas;

    // ฟังก์ชันนี้ไว้ผูกกับปุ่ม Start
    public void StartGame()
    {
        // ปิดป้ายเมนูทิ้งไป เพื่อเริ่มตีไดโนเสาร์
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false); 
            Debug.Log("เกมเริ่มแล้ว! ลุย!");
        }

        // แจ้ง Manager เพื่อเริ่มนับเวลาและเริ่มนับคะแนน
        if (MarsGameManager.Instance != null)
        {
            MarsGameManager.Instance.StartGame();
        }
    }

    public void ExitGame()
    {
        Debug.Log("กำลังออกจากเกม..."); 
        
        // ถ้าเล่นอยู่ในโปรแกรม Unity ให้หยุด Play
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // ถ้าเล่นในแว่น VR (Build แล้ว) ให้ปิดแอป
        Application.Quit();
        #endif
    }
}