using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeShape : MonoBehaviour
{
    private void Start()
    {
        PipeManager
            .GetInstance()
            .Spawn(
                PipeCtrl.GetInstance().GetNamePipe(),
                transform.position,
                transform.rotation,
                transform
            );
    }
}
