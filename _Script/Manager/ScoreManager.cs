using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreCanvas;
    public int score = 0;
    static ScoreManager instance;

    static public ScoreManager GetInstance() => instance;

    private void Awake()
    {
        this.scoreCanvas.SetActive(false);
        ScoreManager.instance = this;
        // Time.timeScale = 1;
    }

    public void StartScore()
    {
        this.scoreCanvas.SetActive(true);
    }
}
