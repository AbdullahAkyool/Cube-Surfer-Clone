using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Vector3 firstPos, endPos;
    //public float speed;
    //private Rigidbody rb;
    public Animator anim;
    //private Camera cam;

    
    private float playerCurrentPosX;
    private float mouseStartPosX;
    private float mouseCurrentPosX;
    public Vector2 bounds;
    public float dragMultiplier;
    
    public TMP_Text finishScoreText;
    
    [SerializeField] private Collector _collector;
    [SerializeField] private DiamondController _diamondController;
    
    private void Start()
    {
        _collector = FindObjectOfType<Collector>();
        //rb = GetComponent<Rigidbody>();
        anim = FindObjectOfType<Animator>();
        //cam=Camera.main;
    }

    void Update()
    {
        // transform.Translate(Vector3.forward * speed/10);
        // rb.AddForce(transform.forward*5);
        //  rb.velocity = Vector3.forward*15f;
        // if (Input.GetMouseButtonDown(0))
        // {
        //     firstPos = Input.mousePosition;
        // }
        // else if (Input.GetMouseButton(0))
        // {
        //     endPos = Input.mousePosition; 
        //     float distanceX = endPos.x - firstPos.x;
        //     transform.Translate(distanceX*speed/10*Time.deltaTime,0,0);
        // }
        //
        // if (Input.GetMouseButtonUp(0))
        // {
        //     firstPos = Vector3.zero;
        //     endPos = Vector3.zero;
        // }
        
        Movement();
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerCurrentPosX = transform.localPosition.x;
            mouseStartPosX = Input.mousePosition.x / Screen.width;
        }

        if (Input.GetMouseButton(0))
        {
            mouseCurrentPosX = Input.mousePosition.x / Screen.width;
        }
        transform.localPosition =
            Vector3.MoveTowards(transform.localPosition, Vector3.up*(_collector.height)+ Vector3.right * Mathf.Clamp((playerCurrentPosX + (mouseCurrentPosX - mouseStartPosX) * dragMultiplier), bounds.x, bounds.y), 80*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle") || other.CompareTag("Lava"))
        {
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish1"))
        {
            finishScoreText.enabled = true;
            finishScoreText.text = (_diamondController.diamondCount * 1).ToString();
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish2"))
        {
            finishScoreText.enabled = true;
            finishScoreText.text = (_diamondController.diamondCount * 2).ToString();
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish3"))
        {
            finishScoreText.enabled = true;
            finishScoreText.text = (_diamondController.diamondCount * 3).ToString();
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish4"))
        {
            finishScoreText.enabled = true;
            finishScoreText.text = (_diamondController.diamondCount * 4).ToString();
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish5"))
        {
            finishScoreText.enabled = true;
            finishScoreText.text = (_diamondController.diamondCount * 5).ToString();
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Finish10"))
        {
            finishScoreText.enabled = true;
            finishScoreText.text = (_diamondController.diamondCount * 10).ToString();
            Time.timeScale = 0;
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("TurnRotate"))
    //     {
    //         transform.Rotate(0,90,0);
    //         // cam.transform.Rotate(0, 90, 0);
    //
    //     }
    // }
}
