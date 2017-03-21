using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeginGUI : MonoBehaviour {

    private GUISkin buttonskin;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("allow_ad", 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        float button_width = Screen.width / 5;
        float button_height = Screen.height / 7;
        float rightbutton_x = Screen.width - Screen.width / 5;

        buttonskin = GUI.skin;
        buttonskin.button.fontSize = Screen.height / 25;
        buttonskin.button.fontStyle = FontStyle.Italic;
        GUI.skin = buttonskin;

        if (GUI.Button(new Rect(Screen.width / 2 - (Screen.width / 4)/2, Screen.height - Screen.height / 6-40, Screen.width / 4, Screen.height/6), "Start"))
        {
            SceneManager.LoadScene("choose_level");
        }
        if (GUI.Button(new Rect(rightbutton_x, Screen.height - Screen.height / 8-25, button_width, button_height), "Settings"))
        {
            SceneManager.LoadScene("settings");
        }
        if (GUI.Button(new Rect(rightbutton_x, Screen.height - Screen.height / 3.5F - 25, button_width, button_height), "SCOREBOARD"))
        {
            SceneManager.LoadScene("Scoreboard");
        }
        if (GUI.Button(new Rect(0, Screen.height - Screen.height / 8 - 25, button_width, button_height), "Exit"))
        {
            Application.Quit();
        }
    }
}
