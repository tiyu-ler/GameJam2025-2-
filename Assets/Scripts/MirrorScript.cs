using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    private bool _isInSite;
    private float _rotateAmmount = 25;
    // private Q rotation;
    void Start()
    {
        _isInSite = false;
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

    void Update()
    {
        
            if (Input.GetKey(KeyCode.Q))
            {
                if (_isInSite)
                {
                    transform.rotation *= Quaternion.Euler(0, _rotateAmmount*Time.deltaTime,0);
                }
            }
            if (Input.GetKey(KeyCode.E))
            {
                if (_isInSite)
                {
                    transform.rotation *= Quaternion.Euler(0,-_rotateAmmount*Time.deltaTime,0);
                }
            }
    }
}
