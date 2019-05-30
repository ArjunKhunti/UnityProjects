using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTransformation : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public GameObject prefab;
    Vector3 screenPoints;
    GameObject selectedObject;
    Vector3 offset;
    public int rotationSpeed = 10;
    
    int temp = 0;
    void Update()
    { 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = hit.collider.gameObject;
            }
        }
        
        if (selectedObject != null)
        {
            screenPoints = Camera.main.WorldToScreenPoint(selectedObject.transform.position);

            offset = selectedObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, screenPoints.z));
        }
        
        //Rotating GameObject into Horizontal Direction
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.up* rotationSpeed);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.down * rotationSpeed);
        }

        if(Input.GetKeyDown("m"))
        {
            transform.localScale = new Vector3(Random.Range(0.2f, 5.0f), Random.Range(0.2f, 5.0f), Random.Range(0.2f, 5.0f));
        }
    }

   
    public void OnMouseDrag()
    {
        
        if (selectedObject != null)
        {
            Vector3 CursorScreenPoints = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoints.z);
            Vector3 cursorPoints = Camera.main.ScreenToWorldPoint(CursorScreenPoints) + offset;

            selectedObject.transform.position = cursorPoints;
        }
    }
}
