using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgShape : MonoBehaviour
{
    private void Start()
    {
        BgManager
            .GetInstance()
            .Spawn(
                BgCtrl.GetInstance().GetNameBg(),
                transform.position,
                transform.rotation,
                transform
            );
    }
}
