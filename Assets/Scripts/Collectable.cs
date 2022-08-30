using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollected;
    public int heightIndex;
    [SerializeField] private Collector _collector;
    private bool isDropping = false;
    [SerializeField] private PlayerController mainBlock;

    void Start()
    {
        isCollected = false;
        _collector = FindObjectOfType<Collector>();
        mainBlock = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (isCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -heightIndex, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            mainBlock.anim.SetBool("isJumping",true);
           TouchObstacle();
           mainBlock.transform.DOJump(new Vector3(mainBlock.transform.position.x, mainBlock.transform.position.y,
               mainBlock.transform.position.z + 2f), 1f, 1, .3f);
            other.GetComponent<BoxCollider>().enabled = false;
            mainBlock.anim.SetBool("isJumping",false);
        }
        else if (other.CompareTag("Lava"))
        {
            // DropBlock();
            StartCoroutine(CubeDestroyTimer());
        }
        else if (other.CompareTag("Finish1"))
        {
            TouchObstacle();
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.CompareTag("Finish2"))
        {
            TouchObstacle();
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.CompareTag("Finish3"))
        {
            TouchObstacle();
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.CompareTag("Finish4"))
        {
            TouchObstacle();
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.CompareTag("Finish5"))
        {
            TouchObstacle();
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.CompareTag("Finish10"))
        {
            TouchObstacle();
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void TouchObstacle()
    {
        _collector.height--;
        _collector.index--;
        _collector.allCubes.RemoveAt(_collector.index);
        transform.parent = null;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    private IEnumerator CubeDestroyTimer()
    {
        
        yield return new WaitForSeconds(.08f);
        _collector.height--;
        _collector.index--;
        Destroy(_collector.allCubes[_collector.index]);
    } 

    // public bool DropBlock()
    // {
    //     if (isDropping) return false;
    //     isDropping = true;
    //     _collector.height--;
    //     _collector.index--;
    //     Destroy(_collector.allCubes[_collector.index]);
    //     //Destroy(gameObject);
    //     StartCoroutine(CubeDestroyTimer());
    //     return true;
    // }

///////////////////////////////////////////////////////////////////////
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Obstacle"))
    //     {
    //         _collector.height--;
    //         transform.parent = null;
    //         gameObject.GetComponent<BoxCollider>().enabled = false;
    //         collision.gameObject.GetComponent<BoxCollider>().enabled = false;
    //     }
    // }
}