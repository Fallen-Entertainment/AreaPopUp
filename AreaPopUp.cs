// By SafeWayGames
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaPopUp : MonoBehaviour
{
    public Text regionName;
    private float fadeTime;
    private bool fadingin;

    void Start()
    {
        regionName.CrossFadeAlpha(0, 0f, false);
        fadeTime = 0;
        fadingin = false;

    }
    void Update()
    {
        //add at runtime
        regionName = GameObject.FindGameObjectWithTag("RegionTag").GetComponent<Text>();

        if (fadingin)
        {
            Fadein();
        }
        else if(regionName.color.a !=0)
        {
            regionName.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    void Fadein()
    {
        regionName.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if (regionName.color.a == 1 && fadeTime > 1.5f)
        {
            fadingin = false;
            fadeTime = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Region")
        {
            fadingin = true;
            regionName.text = other.name;
        }
    }
}
    
