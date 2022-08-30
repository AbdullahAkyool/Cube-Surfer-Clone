using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, .5f, transform.position.z), 2f).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);

    }
}
