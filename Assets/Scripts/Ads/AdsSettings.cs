using UnityEngine;
using System.Collections;
using admob;

public class AdsSettings : MonoBehaviour {

    private bool re = false;
    // Use this for initialization
    void Start () {
        Admob.Instance().initAdmob("ca-app-pub-6425922486772410/7587105288", "ca-app-pub-6425922486772410/7587105288");//admob id with format ca-app-pub-279xxxxxxxx/xxxxxxxx
       // if (PlayerPrefs.GetInt("allow_ad") == 1)
       // {
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
            re = false;
      //  }
    //
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("allow_ad") == 0 && !re)
        {
            Admob.Instance().removeBanner();
            re = true;
        }

    }
}
