using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiatnashkiScript : MonoBehaviour
{
    public List<PiatnashkiElementScript> objects = new List<PiatnashkiElementScript>();
    private bool IsReady;
    public void CheckRotation()
    {
        IsReady = true;
        foreach (PiatnashkiElementScript i in objects)
        {
            if (!i.IsInRightPosition())
            {
                IsReady = false;
            }
        }
        if (IsReady)
        {
            Debug.Log("1");
            StopAndWin();
        }
    }

    public void StopAndWin()
    {
        foreach (PiatnashkiElementScript i in objects)
        {
            i.canBeRotated = false;
        }
    }
}
