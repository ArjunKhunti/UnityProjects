using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDrag : MonoBehaviour
{
    Vector3 screenPoints;
    Vector3 offset;

    void OnMouseDown()
    {
        screenPoints = Camera.main.WorldToScreenPoint(transform.position);

        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, screenPoints.z));

        Debug.Log("Hey There");
    }

    void OnMouseDrag()
    {
        Vector3 CursorScreenPoints = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoints.z   );
        Vector3 cursorPoints = Camera.main.ScreenToWorldPoint(CursorScreenPoints) + offset;

        transform.position = cursorPoints;
    }
}