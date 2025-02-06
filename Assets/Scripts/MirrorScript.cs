using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    private bool _isInSite;
    private float _rotateAmmount = 25;
    private Quaternion _savedRotation;
    void Start()
    {
        _isInSite = false;
        _savedRotation = transform.rotation;
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            _isInSite = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            _isInSite = false;
        }
    }

    public void RestartPosition()
    {
        transform.rotation = _savedRotation;
    }

    void Update()
    {
        
            if (Input.GetKey(KeyCode.E))
            {
                if (_isInSite)
                {
                    transform.rotation *= Quaternion.Euler(0, _rotateAmmount*Time.deltaTime,0);
                }
            }
            if (Input.GetKey(KeyCode.Q))
            {
                if (_isInSite)
                {
                    transform.rotation *= Quaternion.Euler(0,-_rotateAmmount*Time.deltaTime,0);
                }
            }
    }
}
