using UnityEngine;
using System.Collections;

public class CreateObstacle_dp : MonoBehaviour {

    //下面定义了几个不同的预制体参数
    public GameObject obstacleSmall;
    public GameObject obstacleMiddle;
    public GameObject obstacleLarge;
    public GameObject obstacleLay;

    private float currentTime = 0;
    private float interval = 1;
    private Vector3 v3;
    System.Random rm = new System.Random();

    //下面2个变量用来控制生成随机数的上下限
    private int lrange = 1;
    private int urange = 20;

    // Use this for initialization
    void Start()
    {
        v3.x = 14F;
        v3.y = -1.04F;
        v3.z = 0;

        //获得难度
        lrange = PlayerPrefs.GetInt("lrange");
        urange = PlayerPrefs.GetInt("urange");
        interval = PlayerPrefs.GetFloat("interval");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;//每一帧计算一下累计时间
        if (currentTime > interval)
        {//时间超过时间间隔 触发事件
            currentTime = 0;//重置计数器

            int gbgen = rm.Next(lrange, urange);
            if (gbgen%4==0)
            {
                Instantiate(obstacleSmall, v3, Quaternion.identity);
            }
            else if (gbgen%2==0)
            {
                Instantiate(obstacleMiddle, v3, Quaternion.identity);
            }
            else if (gbgen%5==0)
            {
                Instantiate(obstacleLarge, v3, Quaternion.identity);
            }
            else if (gbgen == 0)
            {
                v3.y = -3F;
                Instantiate(obstacleLay, v3, Quaternion.identity);
                v3.y = -1.04F;
            }

        }

    }
}
