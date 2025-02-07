using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiatnashkiElementScript : MonoBehaviour
{
    private int _defaultPosition = 1; // 1,2,3,4,1...
    public List<int> RightPositions = new List<int>();
    public void RotateObject()
    {
        if (_defaultPosition == 4)
        {
            _defaultPosition = 1;
        }
        else
        {
            _defaultPosition += 1;
        }
    }
    
    public bool IsInRightPosition()
    {
        return RightPositions.Contains(_defaultPosition);
    }
}
