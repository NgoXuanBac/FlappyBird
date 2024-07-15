using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbShape : MonoBehaviour
{
    string[] bird = { "BirdRed", "BirdBlue", "BirdYellow" };
    int randomIndex = 0;
    public GameObject birdShape;

    private void Awake()
    {
        this.randomIndex = Random.Range(0, this.bird.Length);
    }

    private void Start()
    {
        this.birdShape = BirdManager
            .GetInstance()
            .Spawn(bird[randomIndex], transform.position, transform.rotation, transform);
    }
}
