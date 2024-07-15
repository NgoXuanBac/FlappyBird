using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager.GetInstance().score++;
        AudioManager.GetInstance().PlayPoint();
        transform.gameObject.SetActive(false);
    }
}
