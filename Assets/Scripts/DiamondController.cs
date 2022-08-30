using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    public Camera cam;
    public int diamondCount = 0;
    public TMP_Text diamondCountText;
    [SerializeField] private GameObject spriteParent;
    public GameObject diamondSprite;
 
    public void AddDiamondCount(Transform diamond)
    {
        diamond.DOMove(diamondCountText.transform.position, .5f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            diamondCount += 50;
            diamondCountText.text = diamondCount.ToString();
            Destroy(diamond.gameObject);
        });
        
    }
    public void CreateDiamondSpriteInUI(Vector3 spritePos)
    {
        Vector3 screenPos = cam.WorldToScreenPoint(spritePos);
        var temp = Instantiate(diamondSprite, screenPos, Quaternion.identity,spriteParent.transform);
        AddDiamondCount(temp.transform);
    }
}
