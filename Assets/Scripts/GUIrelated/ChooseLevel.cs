using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        float buttonpos_x = Screen.width / 2 - (Screen.width / 4) / 2;
        float buttonWidth = Screen.width / 4;
        float buttonHeight = Screen.height / 6F;
        if (GUI.Button(new Rect(buttonpos_x, Screen.height - Screen.height / 1.35F, buttonWidth, buttonHeight), "ESAY"))
        {
            //控制障碍物速度
            PlayerPrefs.SetFloat("beginSpeed", 0.049F);
            PlayerPrefs.SetFloat("deltaSpeed", 0.0003F);
            PlayerPrefs.SetInt("speedInterval", 1);
            //控制障碍物生成密度
            PlayerPrefs.SetInt("lrange",1);
            PlayerPrefs.SetInt("urange",20);
            PlayerPrefs.SetFloat("interval",1F);
            //反转y轴
            PlayerPrefs.SetInt("inverse_y", 0);
            //储存gamelevel
            PlayerPrefs.SetInt("game_level", 0);

            SceneManager.LoadScene("MainGameLevel");
        }
        if (GUI.Button(new Rect(buttonpos_x, Screen.height - Screen.height / 1.8F, buttonWidth, buttonHeight), "NORMAL"))
        {
            PlayerPrefs.SetFloat("beginSpeed", 0.069F);
            PlayerPrefs.SetFloat("deltaSpeed", 0.0004F);
            PlayerPrefs.SetInt("speedInterval", 1);
            PlayerPrefs.SetInt("lrange", 1);
            PlayerPrefs.SetInt("urange", 12);
            PlayerPrefs.SetFloat("interval", 0.8F);
            PlayerPrefs.SetInt("inverse_y", 0);
            PlayerPrefs.SetInt("game_level", 1);

            SceneManager.LoadScene("MainGameLevel");
        }
        if (GUI.Button(new Rect(buttonpos_x, Screen.height - Screen.height / 2.65F, buttonWidth, buttonHeight), "HARD"))
        {
            PlayerPrefs.SetFloat("beginSpeed", 0.088F);
            PlayerPrefs.SetFloat("deltaSpeed", 0.00045F);
            PlayerPrefs.SetInt("speedInterval", 1);
            PlayerPrefs.SetInt("lrange", 1);
            PlayerPrefs.SetInt("urange", 6);
            PlayerPrefs.SetFloat("interval", 0.7F);
            PlayerPrefs.SetInt("inverse_y", 0);
            PlayerPrefs.SetInt("game_level", 2);

            SceneManager.LoadScene("MainGameLevel");
        }
        if (GUI.Button(new Rect(buttonpos_x, Screen.height - Screen.height / 5F, buttonWidth, buttonHeight), "DIFFICULT"))
        {
            PlayerPrefs.SetFloat("beginSpeed", 0.089F);
            PlayerPrefs.SetFloat("deltaSpeed", 0.0005F);
            PlayerPrefs.SetInt("speedInterval", 1);
            PlayerPrefs.SetInt("lrange", 1);
            PlayerPrefs.SetInt("urange", 6);
            PlayerPrefs.SetFloat("interval", 0.65F);
            PlayerPrefs.SetInt("inverse_y", 1);
            PlayerPrefs.SetInt("game_level", 3);

            SceneManager.LoadScene("MainGameLevel");
        }
        if (GUI.Button(new Rect(Screen.width - (Screen.width / 5) -20, Screen.height - Screen.height / 7, Screen.width / 5, Screen.height / 8), "BACK TO MENU"))
        {
            SceneManager.LoadScene("Begin");
        }
    }
}
