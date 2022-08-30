using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private StackThings _stackThings;
    public float moveSpeed;
    public float swipeSpeed;
    private Camera cam;
    void Start()
    {
        _stackThings = FindObjectOfType<StackThings>();
        cam = Camera.main;
    }
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject firstCube = _stackThings.Cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition =
                Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);

        }
    }
}
