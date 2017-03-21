using UnityEngine;
using System.Collections;

public class TextScoreboard : MonoBehaviour {


    private int sbsum = 0;
    public struct sbdata
    {
        public int score;
        public int level;
        public string time;
    }
    private sbdata[] sbd = new sbdata[6];
    private string[] level_str = { "EASY\t", "NORMAL   ", "HARD\t", "DIFFICULT" };

    // Use this for initialization
    void Start () {
        //得到socreboard记录
        sbsum = PlayerPrefs.GetInt("scoreboard_sum", -1);
        if (sbsum != -1)
        {
            string str_score = "score_";
            string str_level = "level_";
            string str_time = "time_";
            for (int i = 0; i < sbsum; i++)
            {
                sbd[i].score = PlayerPrefs.GetInt(str_score + i.ToString());
                sbd[i].level = PlayerPrefs.GetInt(str_level + i.ToString());
                sbd[i].time = PlayerPrefs.GetString(str_time + i.ToString());
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUIStyle GS = new GUIStyle();
        GS.fontSize = Screen.height/20;
        GS.fontStyle = FontStyle.Italic|FontStyle.Bold;
        GS.normal.background = null;
        GS.normal.textColor = new Color(255, 255, 255);    
        if (sbsum == -1)
        {
            GUI.Label(new Rect(Screen.width / 2- Screen.width / 16, Screen.height / 2, Screen.width / 8, Screen.height / 5), "NO DATA FOUND", GS);
        }
        else
        {
            string scoredata="",buf,CLRF="\r\n";
            buf = "RANK\t         DATE\t\tLEVEL\t\tSCORE"+CLRF + CLRF;
            scoredata += buf;
            for (int i=0;i<sbsum;i++)
            {
                buf = "    "+(i+1).ToString() + "\t" + sbd[i].time + "\t\t" + level_str[sbd[i].level] + "\t" + sbd[i].score + CLRF;
                scoredata += buf;
            }
            GUI.Label(new Rect(Screen.width / 2 - Screen.width /2.5F , Screen.height / 2- Screen.height / 5, Screen.width / 7, Screen.height / 1.5F), scoredata, GS);
        }
    }
}
