using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private StackThings _stackThings;
    void Start()
    {
        _stackThings = FindObjectOfType<StackThings>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (!_stackThings.Cubes.Contains(other.gameObject))
            {
                other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                _stackThings.StackCube(other.gameObject, _stackThings.Cubes.Count - 1);
            }
        }
    }
}
