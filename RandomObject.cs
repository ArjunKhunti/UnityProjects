using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshRenderer))]
public class RandomObject : MonoBehaviour
{
    public GameObject[] prefab = new GameObject[5];
    RaycastHit hit;
    Ray ray;
    Vector3 screenPoints;
    Vector3 offset;
    int temp = 0;
    //LayerMask clickableLayer;
    
    private int rotationSpeed = 20;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && temp < 5)
            {
                // Instantiate new prefab with every left click
                GameObject obj = Instantiate(prefab[Random.Range(0,4)], new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
                screenPoints = Camera.main.WorldToScreenPoint(transform.position);

                temp++;
            }

            if(temp >=5 && Input.GetMouseButtonDown(0))
            {
                OnMouseDown();
                OnMouseDrag();
            }
        }
            if (Input.GetAxis("Mouse ScrollWheel") > 0) {
        transform.Rotate(Vector3.left * 0.5f, Space.Self);
    }
    if (Input.GetAxis("Mouse ScrollWheel") < 0) {
        transform.Rotate(Vector3.right * 0.5f, Space.Self);
    }

    }
    
    void OnMouseDown()
    {
        GameObject selectedObject = hit.collider.gameObject;


 
       if(selectedObject != null)
        { 
            screenPoints = Camera.main.WorldToScreenPoint(transform.position);

            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, screenPoints.z));

            Debug.Log("Hey There");

            OnMouseDrag();

        }
    }
    
    void OnMouseDrag()
    {
        Vector3 CursorScreenPoints = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoints.z);
        Vector3 cursorPoints = Camera.main.ScreenToWorldPoint(CursorScreenPoints) + offset;

        transform.position = cursorPoints;
    }

   

}
