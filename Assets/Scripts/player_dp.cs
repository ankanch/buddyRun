using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class player_dp : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator antor;

    //变量hash
   // int runHash = Animator.StringToHash("RunStatus_dp");
    int keypressHash = Animator.StringToHash("KeyPressed_dp");
    int landingHash = Animator.StringToHash("Landing_dp");
    //animation状态hash
    int runStateHash = Animator.StringToHash("Base Layer.Run_dp");
    int JumpStateHash = Animator.StringToHash("Base Layer.Jump_dp");
    //其他变量
    private AudioSource audioSource;

    //游戏相关控制
    private bool music_on = true;
    private bool inverse_y = false;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        antor = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //获取相关游戏变量
        int t = PlayerPrefs.GetInt("music_on", -1);
        if (t == 1)
        {
            music_on = true;
        }
        else
        {
            music_on = false;
        }
        //反转y轴
        inverse_y = false;
        if (PlayerPrefs.GetInt("inverse_y") == 1)
        {
            inverse_y = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = antor.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.fullPathHash == JumpStateHash)
        {
            antor.SetBool(keypressHash, false);
            antor.SetBool(landingHash, true);
        }
#if UNITY_ANDROID

        if (!inverse_y)
        {
            if (Input.touchCount == 1) //单点触控：控制上面那个人移动
            {
                if ((Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary) && stateInfo.fullPathHash == runStateHash)
                {
                    Vector2 v2 = Input.GetTouch(0).position;
                    if (v2.y < Screen.height / 2)
                    {
                        sr.material.color = Color.white;
                        antor.SetBool(keypressHash, true);
                        if (music_on)
                        {
                            audioSource.Play();
                        }
                    }
                }
            }
            else if (Input.touchCount == 2) //多点触控：判断位置并控制相应人物跳跃
            {
                Vector2 v2 = Input.GetTouch(0).position;
                Vector2 v22 = Input.GetTouch(1).position;
                if ((v2.y > Screen.height / 2 && v22.y < Screen.height / 2) || (v2.y < Screen.height / 2 && v22.y > Screen.height / 2))
                {
                    PlayerPrefs.SetInt("mulittouch", 1);
                }
            }
        }
        else
        {
            if (Input.touchCount == 1) //单点触控：控制上面那个人移动
            {
                if ((Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary) && stateInfo.fullPathHash == runStateHash)
                {
                    Vector2 v2 = Input.GetTouch(0).position;
                    if (v2.y > Screen.height / 2)
                    {
                        sr.material.color = Color.white;
                        antor.SetBool(keypressHash, true);
                        if (music_on)
                        {
                            audioSource.Play();
                        }
                    }
                }
            }
            else if (Input.touchCount == 2) //多点触控：判断位置并控制相应人物跳跃
            {
                Vector2 v2 = Input.GetTouch(0).position;
                Vector2 v22 = Input.GetTouch(1).position;
                if ((v2.y > Screen.height / 2 && v22.y < Screen.height / 2) || (v2.y < Screen.height / 2 && v22.y > Screen.height / 2))
                {
                    PlayerPrefs.SetInt("mulittouch", 1);
                }
            }
        }
#elif UNITY_IPHONE
        if (!inverse_y)
        {
            if (Input.touchCount == 1) //单点触控：控制上面那个人移动
            {
                if ((Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary) && stateInfo.fullPathHash == runStateHash)
                {
                    Vector2 v2 = Input.GetTouch(0).position;
                    if (v2.y < Screen.height / 2)
                    {
                        sr.material.color = Color.white;
                        antor.SetBool(keypressHash, true);
                        if (music_on)
                        {
                            audioSource.Play();
                        }
                    }
                }
            }
            else if (Input.touchCount == 2) //多点触控：判断位置并控制相应人物跳跃
            {
                Vector2 v2 = Input.GetTouch(0).position;
                Vector2 v22 = Input.GetTouch(1).position;
                if ((v2.y > Screen.height / 2 && v22.y < Screen.height / 2) || (v2.y < Screen.height / 2 && v22.y > Screen.height / 2))
                {
                    PlayerPrefs.SetInt("mulittouch", 1);
                }
            }
        }
        else
        {
            if (Input.touchCount == 1) //单点触控：控制上面那个人移动
            {
                if ((Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary) && stateInfo.fullPathHash == runStateHash)
                {
                    Vector2 v2 = Input.GetTouch(0).position;
                    if (v2.y > Screen.height / 2)
                    {
                        sr.material.color = Color.white;
                        antor.SetBool(keypressHash, true);
                        if (music_on)
                        {
                            audioSource.Play();
                        }
                    }
                }
            }
            else if (Input.touchCount == 2) //多点触控：判断位置并控制相应人物跳跃
            {
                Vector2 v2 = Input.GetTouch(0).position;
                Vector2 v22 = Input.GetTouch(1).position;
                if ((v2.y > Screen.height / 2 && v22.y < Screen.height / 2) || (v2.y < Screen.height / 2 && v22.y > Screen.height / 2))
                {
                    PlayerPrefs.SetInt("mulittouch", 1);
                }
            }
        }
#else
        if (!inverse_y)
        {
            if (Input.GetKey(KeyCode.DownArrow) && stateInfo.fullPathHash == runStateHash) //控制down那个人移动
            {
                sr.material.color = Color.white;
                antor.SetBool(keypressHash, true);
                if (music_on)
                {
                    audioSource.Play();
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && stateInfo.fullPathHash == runStateHash) //控制down那个人移动
            {
                sr.material.color = Color.white;
                antor.SetBool(keypressHash, true);
                if (music_on)
                {
                    audioSource.Play();
                }
            }
        }
#endif
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (PlayerPrefs.GetInt("col_allowed") == 0)
        {
            return;
        }

        Debug.Log("game over");
        sr.material.color = Color.magenta;
        SceneManager.LoadScene("GameOver");
    }
}
