using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickMovement : MonoBehaviour
{
    public static JoyStickMovement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<JoyStickMovement>();
                if(Instance == null)
                {
                    var instanceContainer = new GameObject("JoyStickMovement");
                    instance = instanceContainer.AddComponent<JoyStickMovement>();
                }
            }
            return Instance;
        }
    }
    private static JoyStickMovement instance;

    public GameObject smallStick;
    public GameObject bGStick;
    Vector2 stickFirstPosition;
    public Vector2 joyVec;
    Vector2 joyStickFirstPosition;
    float stickRadius;
    void Start()
    {
        stickRadius = bGStick.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        joyStickFirstPosition = bGStick.transform.position;
    }

    public void PointDown()
    {
        bGStick.transform.position = Input.mousePosition;
        smallStick.transform.position = Input.mousePosition;
        stickFirstPosition = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFirstPosition).normalized;

        float stickDistance = Vector2.Distance(DragPosition, stickFirstPosition);

        if (stickDistance < stickRadius)
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickRadius;
        }
    }
    public void Drop()
    {
        joyVec = Vector2.zero;
        bGStick.transform.position = joyStickFirstPosition;
        smallStick.transform.position = joyStickFirstPosition;
    }

   
}
