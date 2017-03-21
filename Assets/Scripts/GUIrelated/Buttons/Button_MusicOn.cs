using UnityEngine;
using System.Collections;

public class Button_MusicOn : MonoBehaviour {

    private bool music_on = true;


    // Use this for initialization
    void Start () {
        int i = PlayerPrefs.GetInt("music_on");
        if(i==1)
        {
            music_on = true;
        }
        else
        {
            music_on = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        float xpos = Screen.width / 2 - Screen.width / 8;
        float ypos = Screen.height - Screen.height / 1.95F ;
        float width = Screen.width / 4;
        float height = Screen.height / 6;
        if (music_on)
        {
            if (GUI.Button(new Rect(xpos, ypos,width, height), "MUSIC : ON"))
            {
                music_on = false;
                PlayerPrefs.SetInt("music_on", 0);
            }
        }
        else
        {
            if (GUI.Button(new Rect(xpos, ypos, width, height), "MUSIC : OFF"))
            {
                music_on = true;
                PlayerPrefs.SetInt("music_on", 1);
            }
        }
    }
}
