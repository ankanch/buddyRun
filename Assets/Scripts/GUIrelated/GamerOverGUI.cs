 using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GamerOverGUI : MonoBehaviour {

    private AudioSource audioSource;
    private bool music_on = true;

    public AudioClip dead_lessthan30;
    public AudioClip dead_morethan30;

    private int score;

    private int sbsum = 0;
    public struct sbdata
    {
        public int score;
        public int level;
        public string time;
    }
    private sbdata[] sbd = new sbdata[7];

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("allow_ad", 1);
        //得到得分
        score = PlayerPrefs.GetInt("score");
        audioSource = GetComponent<AudioSource>();
        //设置一些初始数据
        int t = PlayerPrefs.GetInt("background_music_on");
        if (t == 1)
        {
            music_on = true;
        }
        else
        {
            music_on = false;
        }
        //获得排行榜数据
        sbsum = PlayerPrefs.GetInt("scoreboard_sum", -1);
        string time = System.DateTime.Now.Year.ToString() + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Day + "  " +
            System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString();
        if (sbsum != -1)
        {
            string str_score = "score_";
            string str_level = "level_";
            string str_time = "time_";
            for (int i = 0; i < sbsum; i++)
            {
                sbd[i].score = PlayerPrefs.GetInt(str_score + i.ToString());
                sbd[i].level  = PlayerPrefs.GetInt(str_level + i.ToString());
                sbd[i].time = PlayerPrefs.GetString(str_time + i.ToString());
            }
            //判断当前分数，然后进行排序，插入原来值中
            sbdata sbbuf;
            sbbuf.score = score;
            sbbuf.level = PlayerPrefs.GetInt("game_level");
            sbbuf.time = time;
            if(sbsum<6)
            {
                sbd[sbsum] = sbbuf;
            }
            else
            {
                sbd[6] = sbbuf;
            }
            Sort(sbd);
            if(sbsum ==6)
            {
                for (int i = 0; i < 6; i++)
                {
                    PlayerPrefs.SetInt(str_score + i.ToString(), sbd[i].score);
                    PlayerPrefs.SetInt(str_level + i.ToString(), sbd[i].level);
                    PlayerPrefs.SetString(str_time + i.ToString(), sbd[i].time);
                }
                PlayerPrefs.SetInt("scoreboard_sum", 6);
            }
            else
            {
                sbsum++;
                for (int i = 0; i <sbsum ; i++)
                {
                    PlayerPrefs.SetInt(str_score + i.ToString(), sbd[i].score);
                    PlayerPrefs.SetInt(str_level + i.ToString(), sbd[i].level);
                    PlayerPrefs.SetString(str_time + i.ToString(), sbd[i].time);
                }
                PlayerPrefs.SetInt("scoreboard_sum", sbsum);
            }
        }
        else
        {
            PlayerPrefs.SetInt("score_0", score);
            PlayerPrefs.SetInt("level_0", PlayerPrefs.GetInt("game_level"));
            PlayerPrefs.SetString("time_0", time);
            PlayerPrefs.SetInt("scoreboard_sum", 1);
        }
        if(music_on && score<=30)
        {
            audioSource.PlayOneShot(dead_lessthan30);
        }
        else if(music_on && score>30)
        {
            audioSource.PlayOneShot(dead_morethan30);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUIStyle bb = new GUIStyle();
        bb.normal.background = null;    //这是设置背景填充的
        bb.normal.textColor = new Color(255, 255, 255);   //设置字体颜色的
        bb.fontSize = Screen.height / 10;

        float midbutton_width = Screen.width / 4;
        float sidebutton_width = Screen.width / 5;
        float mostbutton_height = Screen.height / 8;
        float midbutton_x = Screen.width / 2 - (Screen.width / 4) / 2;

        GUI.Label(new Rect(Screen.width / 3, 50, 400, Screen.height / 6), "Your score:" + score, bb);
        if (GUI.Button(new Rect(midbutton_x, Screen.height - Screen.height / 2.8F, midbutton_width, Screen.height / 6), "Try Again"))
        {
            PlayerPrefs.SetInt("allow_ad", 0);
            SceneManager.LoadScene("MainGameLevel");
        }
        if (GUI.Button(new Rect(midbutton_x, Screen.height - Screen.height / 7, midbutton_width, mostbutton_height), "Change Level"))
        {
            PlayerPrefs.SetInt("allow_ad", 0);
            SceneManager.LoadScene("choose_level");
        }
        if (GUI.Button(new Rect(Screen.width- Screen.width / 5, Screen.height - Screen.height / 8 - 25, sidebutton_width, mostbutton_height), "Return Menu"))
        {
            PlayerPrefs.SetInt("allow_ad", 0);
            SceneManager.LoadScene("Begin");
        }
        if (GUI.Button(new Rect(0, Screen.height - Screen.height / 8 - 25, sidebutton_width, mostbutton_height), "ExitGame"))
        {
            Application.Quit();
        }
    }

    //排序函数
    public void Sort(sbdata[] list)
    {
        sbdata sbbuf;
        for(int i=0;i<list.Length;i++)
        {
            for(int j=i;j<list.Length;j++)
            {
                if(list[j].score >= list[i].score)
                {
                    sbbuf = list[i];
                    list[i] = list[j];
                    list[j] = sbbuf;
                }
            }
        }
    }
}
