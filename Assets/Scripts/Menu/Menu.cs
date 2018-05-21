using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool play = false;
    public bool settings = false;
    public bool authors = false;
    public bool quit = false;
    public bool ok = false;
    public bool settingsBack = false;
    public bool profileBack = false;
    public bool authorBack = false;
    //Графические настройки
    public bool low = false;
    public bool middle = false;
    public bool high = false;
    //Камеры
    public Camera cMenu;
    public Camera cSettings;
    public Camera cAuthors;

    void Start()
    {
        DontDestroyOnLoad(this);
        cMenu.enabled = true;
        cSettings.enabled = false;
        cAuthors.enabled = false;
    }
    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseUp()
    {
        if (play == true)
        {
            Application.LoadLevel(2);
        }
        if (settings == true)
        {
            cMenu.enabled = false;
            cSettings.enabled = true;
            cAuthors.enabled = false;
        }
        if (authors == true)
        {
            cMenu.enabled = false;
            cSettings.enabled = false;
            cAuthors.enabled = true;
        }
        if (quit == true)
        {
            Application.Quit();
        }
        //  Кнопки назад
        if (settingsBack == true)
        {
            cMenu.enabled = true;
            cSettings.enabled = false;
            cAuthors.enabled = false;
        }
        if (authorBack == true)
        {
            cMenu.enabled = true;
            cSettings.enabled = false;
            cAuthors.enabled = false;
        }
        if (profileBack == true)
        {
            Application.LoadLevel(0);
        }
        //Переключение графики
        if (low == true)
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
        }
        if (middle == true)
        {
            QualitySettings.currentLevel = QualityLevel.Simple;
        }
        if (high == true)
        {
            QualitySettings.currentLevel = QualityLevel.Good;
        }
    }
}
