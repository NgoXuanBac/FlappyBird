using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbCtrl : MonoBehaviour
{
    static private FbCtrl instance;

    static public FbCtrl GetInstance() => instance;

    public FbStatus fbStatus;
    public FbShape fbShape;
    public FbMove fbMove;

    private void Awake()
    {
        FbCtrl.instance = this;
        this.fbStatus = GetComponent<FbStatus>();
        this.fbShape = GetComponent<FbShape>();
    }
}
