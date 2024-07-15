using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCtrl : MonoBehaviour
{
    static private PipeCtrl instance;

    static public PipeCtrl GetInstance() => instance;

    string[] pipe = { "PipeRed", "PipeGreen" };
    int randomIndex = 0;

    public string GetNamePipe() => this.pipe[this.randomIndex];

    private void Awake()
    {
        PipeCtrl.instance = this;
        this.randomIndex = Random.Range(0, this.pipe.Length);
    }
}
