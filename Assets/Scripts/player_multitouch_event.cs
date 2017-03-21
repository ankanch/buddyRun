using UnityEngine;
using System.Collections;

public class player_multitouch_event : MonoBehaviour {

    private SpriteRenderer sr;
    private Animator antor;

    //变量hash
    int keypressHash = Animator.StringToHash("KeyPressed");
    int landingHash = Animator.StringToHash("Landing");
    //animation状态hash
    int JumpStateHash = Animator.StringToHash("Base Layer.Jump");
    //其他变量

    private AudioSource audioSource;
    //游戏相关控制
    private bool music_on = true;

    //多点触控消息相应
    private bool mulittouch = false;

    // Use this for initialization
    void Start () {
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

    }
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = antor.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.fullPathHash == JumpStateHash)
        {
            antor.SetBool(keypressHash, false);
            antor.SetBool(landingHash, true);
        }
        if (PlayerPrefs.GetInt("mulittouch") == 1)
        {
            mulittouch = true;
        }
        else
        {
            mulittouch = false;
        }
        if (mulittouch)
        {
            sr.material.color = Color.white;
            antor.SetBool(keypressHash, true);
            if (music_on)
            {
                audioSource.Play();
            }

            PlayerPrefs.SetInt("mulittouch", 0);
            mulittouch = false;
        }

    }
}
