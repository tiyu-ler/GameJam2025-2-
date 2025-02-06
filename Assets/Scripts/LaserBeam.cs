using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{
    public LayerMask LayerMask;
    public LayerMask ErrorMask;
    public LayerMask FinishMask;
    public GameObject StartPoint;
    public GameObject Screen;
    public Material Green;
    private bool _isSolved;
    public float DefaultLength = 5000;
    public int NumberOfReflection = 10;
    private LineRenderer _lineRenderer;
    private RaycastHit _raycastHit;
    private Ray _ray;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        ReflectLaser();
    }

    void ReflectLaser()
    {
        if (!_isSolved)
        {
            _ray = new Ray(transform.position, transform.forward);
            _lineRenderer.positionCount = 1;
            // _lineRenderer.SetPosition(0, transform.position);
            Vector3 lastPosition = transform.position;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, lastPosition);

            _ray = new Ray(lastPosition, Vector3.Reflect(_ray.direction, _raycastHit.normal));

            for (int i = 0; i < NumberOfReflection; i++)
            {
                if (Physics.Raycast(_ray.origin, _ray.direction, out _raycastHit, DefaultLength, LayerMask))
                {
                    _lineRenderer.positionCount += 1;
                    lastPosition = _raycastHit.point;
                    _lineRenderer.SetPosition(_lineRenderer.positionCount-1, _raycastHit.point);

                    _ray = new Ray(_raycastHit.point, Vector3.Reflect(_ray.direction, _raycastHit.normal));
                }
                else
                {
                    if (Physics.Raycast(_ray.origin, _ray.direction, out _raycastHit, DefaultLength, ErrorMask))
                    {
                        _lineRenderer.positionCount += 1; // Increase count before setting position
                        lastPosition += _ray.direction * DefaultLength;
                        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, lastPosition);
                        ResetPuzzle();
                    }
                    else
                    {
                        if (Physics.Raycast(_ray.origin, _ray.direction, out _raycastHit, DefaultLength, FinishMask))
                        {
                            Finish();
                        }
                        else
                        {
                            // _lineRenderer.SetPosition(1, transform.position + (transform.forward * DefaultLength));
                            _lineRenderer.positionCount += 1; // Increase count before setting position
                            lastPosition += _ray.direction * DefaultLength;
                            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, lastPosition);
                            break;
                        }
                    }
                }
            }
        }
    }

    private void Finish()
    {
        Screen.GetComponent<Renderer>().material = Green;
        _isSolved = true;
        Destroy(StartPoint);
    }

    private void ResetPuzzle()
    {

    }
}
