using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameStart;
    public GameObject flickerEf;
    static GameManager instance;

    static public GameManager GetInstance() => instance;

    private void Awake()
    {
        GameManager.instance = this;
        this.flickerEf.SetActive(true);
        this.gameOver.SetActive(false);
        this.gameStart.SetActive(true);
    }

    public void OnFlickerEf()
    {
        FlickerEffect.GetInstance().isFlicker = true;
    }

    public void GameOver()
    {
        this.gameOver.SetActive(true);
    }

    public void GameStart()
    {
        this.gameStart.SetActive(false);
    }

    public void GameReplay()
    {
        SceneManager.LoadScene(0);
    }
}
