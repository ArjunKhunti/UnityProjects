using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
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
        /*
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && temp == 0)
            {
                // Instantiate new prefab with every left click
                GameObject obj = Instantiate(prefab, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
                screenPoints = Camera.main.WorldToScreenPoint(transform.position);

                temp++;
            }
        }

        */
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                selectedObject = hit.collider.gameObject;
                Debug.Log("In Mouse Down");

            }
        }
        
        if (selectedObject != null)
        {
            screenPoints = Camera.main.WorldToScreenPoint(selectedObject.transform.position);

            offset = selectedObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, screenPoints.z));

            Debug.Log("Object Selected");
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            //float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;


            transform.Rotate(Vector3.up* rotationSpeed);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.down * rotationSpeed);
        }
    }

    /*
    public void OnMouseDown()
    {
    }
    */
    public void OnMouseDrag()
    {
        
        if (selectedObject != null)
        {
            Vector3 CursorScreenPoints = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoints.z);
            Vector3 cursorPoints = Camera.main.ScreenToWorldPoint(CursorScreenPoints) + offset;

            selectedObject.transform.position = cursorPoints;
        }
    }

    private void OnMouseOver()
    {
        
    }
}
