using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class lucky_cheat : MonoBehaviour {

    private int lucky_times = 0;
    private bool cheat_mode_opened = false;

    // Use this for initialization
    void Start () {
        lucky_times = 0;
        if (PlayerPrefs.GetInt("allow_ad", -1) != 1)
        {
            cheat_mode_opened = false;
        }
        else
        {
            cheat_mode_opened = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        float xpos = Screen.width / 2 - Screen.width / 8;
        float ypos = Screen.height - Screen.height / 1.45F;
        float width = Screen.width / 4;
        float height = Screen.height / 6;

        if (!cheat_mode_opened)
        {
            if (lucky_times < 5)
            {
                if (GUI.Button(new Rect(xpos, ypos, width, height), "I'm feel lucky!"))
                {
                    lucky_times++;
                }
            }
            else if (lucky_times >= 5 && lucky_times < 10)
            {
                if (GUI.Button(new Rect(xpos, ypos, width, height), "Seems you do feel lucky."))
                {
                    lucky_times++;
                }
            }
            else if (lucky_times >= 10 && lucky_times < 12)
            {
                if (GUI.Button(new Rect(xpos, ypos, width, height), "I'm going to help you."))
                {
                    lucky_times++;
                }
            }
            else if (lucky_times >= 12 && lucky_times < 14)
            {
                if (GUI.Button(new Rect(xpos, ypos, width, height), "Guess What?"))
                {
                    lucky_times++;
                }
            }
            else if (lucky_times >= 14 && lucky_times < 15)
            {
                if (GUI.Button(new Rect(xpos, ypos, width, height), "close ads"))
                {
                    lucky_times++;
                }
            }
            else if (lucky_times == 15)
            {
                if (GUI.Button(new Rect(xpos, ypos, width, height), "1 more time for close"))
                {
                    PlayerPrefs.SetInt("allow_ad", 1);
                    SceneManager.LoadScene("settings");
                }
            }
        }
        else
        {
            if (GUI.Button(new Rect(xpos, ypos, width, height), "Tap to open ads."))
            {
                PlayerPrefs.SetInt("allow_ad", 0);
                SceneManager.LoadScene("settings");
            }
        }
    }
}
