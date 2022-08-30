using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameObject mainBlock;
    public List<GameObject> allCubes;
    // public Vector3 spawnPoint;
    // public GameObject spawnCubeObject;
    public int height,index;
    [SerializeField] private DiamondController _diamondController;
    void Start()
    {
        mainBlock = GameObject.FindGameObjectWithTag("MainBlock");
        _diamondController = FindObjectOfType<DiamondController>();
    }
    void Update()
    {
        //mainBlock.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable") && other.gameObject.GetComponent<Collectable>().isCollected==false)
        {
            height+=1;
            allCubes.Add(other.gameObject);
            index++;
            //spawnPoint = new Vector3(spawnPoint.x, spawnPoint.y + height, spawnPoint.z);
            //Instantiate(spawnCubeObject,spawnPoint, Quaternion.identity);
            other.gameObject.GetComponent<Collectable>().isCollected = true;
            other.gameObject.GetComponent<Collectable>().heightIndex = height;
            other.transform.parent = mainBlock.transform; 
        }
        else if (other.CompareTag("Diamond"))
        {
            _diamondController.CreateDiamondSpriteInUI(other.transform.position);   
            Destroy(other.gameObject);
        }
        
    }
}
