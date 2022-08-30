using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StackThings : MonoBehaviour
{
    public List<GameObject> Cubes;
    public float movementDelay =.25f;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveListElements();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MoveOrigin();
        }
    }

    public void StackCube(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = Cubes[index].transform.localPosition;
        newPos.y += 1;
        other.transform.localPosition = newPos;
        Cubes.Add(other);
        //StartCoroutine(StackEffect());
    }

    // IEnumerator StackEffect()
    // {
    //     for (int i = Cubes.Count; i > 0; i--)
    //     {
    //         Vector3 scale = new Vector3(1, 1, 1);
    //         scale *= 1.5f;
    //
    //         Cubes[i].transform.DOScale(scale, .1f).onComplete(() => DefaultScale());
    //             
    //
    //         yield return new WaitForSeconds(.05f);
    //     }
    // }
    //
    // void DefaultScale()
    // {
    //     Cubes[i].transform.DOScale(new Vector3(1, 1, 1), .01f));
    // }

    private void MoveListElements()
    {
        for (int i = 1; i < Cubes.Count; i++)
        {
            Vector3 pos = Cubes[i].transform.localPosition;
            pos.x = Cubes[i - 1].transform.localPosition.x;
            Cubes[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < Cubes.Count; i++)
        {
            Vector3 pos = Cubes[i].transform.localPosition;
            pos.x = Cubes[0].transform.localPosition.x;
            Cubes[i].transform.DOLocalMove(pos,.50f);
        }
    }
}
