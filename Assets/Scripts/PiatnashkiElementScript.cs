using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiatnashkiElementScript : MonoBehaviour
{
    private int _defaultPosition = 1; // 1,2,3,4,1...
    public List<int> RightPositions = new List<int>();
    public PiatnashkiScript PiatnashkiScript;
    public bool canBeRotated;
    public GameObject outline;

    public void OutlineEnable()
    {

    }
    public void OutlineDisable()
    {

    }

    void Start()
    {
        canBeRotated = true;
    }
    public void RotateObject()
    {
        if (canBeRotated)
        {
            if (_defaultPosition == 4)
            {
                _defaultPosition = 1;
            }
            else
            {
                _defaultPosition += 1;
            }
            transform.localEulerAngles += new Vector3(0,90,0);
            PiatnashkiScript.CheckRotation();
        }
    }
    
    public bool IsInRightPosition()
    {
        return RightPositions.Contains(_defaultPosition);
    }
}
