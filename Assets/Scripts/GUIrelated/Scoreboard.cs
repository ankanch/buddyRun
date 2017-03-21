using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour {

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("allow_ad", 1);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - Screen.width / 5 - 10, Screen.height - Screen.height / 7 - 10, Screen.width / 5, Screen.height / 7), "BACK"))
        {
            PlayerPrefs.SetInt("allow_ad", 0);
            SceneManager.LoadScene("Begin");
        }
    }
}
