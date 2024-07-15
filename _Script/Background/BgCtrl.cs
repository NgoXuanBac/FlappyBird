using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgCtrl : MonoBehaviour
{
    static private BgCtrl instance;
    static public BgCtrl GetInstance() => instance;

    string[] bg = { "BgNight", "BgDay" };
    int randomIndex = 0;

    public string GetNameBg() => this.bg[this.randomIndex];

    private void Awake()
    {
        BgCtrl.instance = this;
        this.randomIndex = Random.Range(0, this.bg.Length);
    }
}
