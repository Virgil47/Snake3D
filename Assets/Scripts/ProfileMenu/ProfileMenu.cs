using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ProfileMenu : MonoBehaviour
{
    public InputField inputName;
    public bool ok = false;
    public bool back = false;
    public string playerName;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnMouseUp()
    {
        if (ok == true)
        {
            if (inputName.text != null)
            {
                playerName = inputName.text;
            }
            else
            {
                playerName = "noname";
            }
            
            ProfileSettingsLoader.SetName(playerName);
            Application.LoadLevel(1);
        }
        if (back == true)
        {
            Application.LoadLevel(0);
        }
    }
}
