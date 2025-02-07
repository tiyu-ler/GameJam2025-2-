using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float InteractionDistance = 3f;
    public LayerMask InteractableLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, InteractionDistance, InteractableLayer))
        {
            if (hit.collider.CompareTag("Wires"))
            {
                try
                {
                    PiatnashkiElementScript elementScript = hit.collider.GetComponent<PiatnashkiElementScript>();
                    if (elementScript != null)
                    {
                        elementScript.RotateObject();
                    }
                } catch {Debug.Log("Error");}
                
            }
        }
    }
}

