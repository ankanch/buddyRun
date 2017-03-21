using UnityEngine;
using System.Collections;

public class Moving_gb_Middle : MonoBehaviour {

    private float speed = 0.049F;

    // Use this for initialization
    void Start () {
        speed = PlayerPrefs.GetFloat("wall_speed");
    }

    // Update is called once per frame
    void Update()
    {

        transform.position -= new Vector3(Time.deltaTime + speed, 0, 0);

        if (transform.position.x < -11.36f)
        {//这个数值可以是任何超过屏幕左边界的一个X坐标 我这里直接使用了一个比较大的值
            Destroy(gameObject);//这个函数用来销毁游戏对象
        }

    }
}
