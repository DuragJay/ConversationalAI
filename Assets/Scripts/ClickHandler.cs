using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ClickHandler : MonoBehaviour
{
    public UnityEvent upEvent;
    public UnityEvent downEvent;
    void OnMouseDown()
    {
        print("Down");
        downEvent.Invoke();
    }
    void OnMouseUp()
    {
        print("Up");
        upEvent.Invoke();
    }

    
}
