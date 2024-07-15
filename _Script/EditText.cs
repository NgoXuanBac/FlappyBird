using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditText : MonoBehaviour
{
    protected Text scoreText;

    void Awake()
    {
        this.scoreText = GetComponent<Text>();
    }

    void Update()
    {
        this.scoreText.text = ScoreManager.GetInstance().score.ToString();
    }
}
