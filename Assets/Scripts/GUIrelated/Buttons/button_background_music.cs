using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class button_background_music : MonoBehaviour {

    private bool background_music_on = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int i = PlayerPrefs.GetInt("background_music_on");
        if (i == 1)
        {
            background_music_on = true;
        }
        else
        {
            background_music_on = false;
        }

    }

    void OnGUI()
    {
        float xpos = Screen.width / 2 - Screen.width / 8;
        float ypos = Screen.height - Screen.height / 3F ;
        float width = Screen.width / 4;
        float height = Screen.height / 6;

        if (background_music_on)
        {
            if (GUI.Button(new Rect(xpos, ypos, width, height), "GamerOverMusic ON"))
            {
                background_music_on = false;
                PlayerPrefs.SetInt("background_music_on", 0);
                SceneManager.LoadScene("settings");
                
            }
        }
        else
        {
            if (GUI.Button(new Rect(xpos, ypos, width, height), "GamerOverMusic OFF"))
            {
                background_music_on = true;
                PlayerPrefs.SetInt("background_music_on", 1);
                SceneManager.LoadScene("settings");
                
            }
        }
    }
}
