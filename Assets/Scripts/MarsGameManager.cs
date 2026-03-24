using UnityEngine;

public class MarsGameManager : MonoBehaviour
{
    /// <summary>
    /// Quits the application. If running in the Unity Editor, it stops play mode.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("QuitGame called. Exiting application...");
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}