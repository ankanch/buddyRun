using UnityEngine;
using System.Collections;

public class Socre : MonoBehaviour {

    //debug变量
    public bool Collision_allowed = true;   //是否开启碰撞

    //控制分数的变量
    private float currentTime = 0;
    private float interval = 0.3F;//这里可以控制分数的增加快慢与障碍物的生成快慢
    private int score = 0;

    //下面是用来控制速度的和障碍物生成的
    public float wall_speed = 0.049F;   //经过检验，初始速度在0.049F最好

    //还有控制障碍物移动时间随着时间变化而加快
    public float delta_speed = 0.0003F;  //速度递增量
    public int speed_interval = 1;    //这里是用来设置速度随着时间的递增量
    private float speed_currentTime = 0;  

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetFloat("wall_speed", wall_speed);
        PlayerPrefs.SetInt("wall_gen", 1);
        //难度选择
        wall_speed = PlayerPrefs.GetFloat("beginSpeed");
        delta_speed = PlayerPrefs.GetFloat("deltaSpeed");
        speed_interval = PlayerPrefs.GetInt("speedInterval");
        //开发选项
        if (Collision_allowed)
        {
            PlayerPrefs.SetInt("col_allowed", 1);
        }
        else
        {
            PlayerPrefs.SetInt("col_allowed", 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;   //每一帧计算一下累计时间 

        //分数
        if (currentTime > interval)
        {
            speed_currentTime += currentTime;
            currentTime = 0;
            score++;
            if (score % speed_interval == 0)
            {
                wall_speed += delta_speed;
                PlayerPrefs.SetFloat("wall_speed", wall_speed);
            }
            PlayerPrefs.SetInt("score", score);
        }

    }

    void OnGUI()
    {
        GUIStyle GS = new GUIStyle();
        GS.fontSize = Screen.height / 25;
        GS.fontStyle = FontStyle.Italic | FontStyle.Bold;
        GS.normal.background = null;
        GS.normal.textColor = new Color(255, 255, 255);

        string str = "DISTENCE: " + score + "m";
        GUI.Label(new Rect(Screen.width- Screen.width / 4.9F, 10, Screen.width/6, Screen.height / 24), str,GS);

    }
}
