using UnityEngine;

public class Death : MonoBehaviour
{
    /// <summary>
    /// после смерти игра перезапускается по нажатию на эскейп
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(Application.loadedLevel);
            Time.timeScale = 1;
        }
    }
}
