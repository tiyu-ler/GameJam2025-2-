using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;
    public Camera camera;

    private float _inSettingsMouseSpeed;
    private CharacterController controller;
    private Quaternion _cameraRotation;
    void Start()
    {
        _inSettingsMouseSpeed = PlayerPrefs.GetFloat("MouseSpeed", 0.5f);
        controller = GetComponent<CharacterController>();
        // LockCursor(true);
        Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
        _cameraRotation = camera.transform.localRotation;
    }

    void Update()
    {
        Vector3 _moveX = Input.GetAxis("Horizontal") * Vector3.right * MovementSpeed * Time.deltaTime;
        Vector3 _moveY = Input.GetAxis("Vertical") * Vector3.forward * MovementSpeed * Time.deltaTime;

        Vector3 _move = transform.TransformDirection(_moveX+_moveY);
        controller.Move(_move);

        float _rotateHorizontal = Input.GetAxis("Mouse X") * _inSettingsMouseSpeed * RotationSpeed;
	    float _rotateVertical = Input.GetAxis("Mouse Y") * _inSettingsMouseSpeed * RotationSpeed;

        transform.rotation *= Quaternion.Euler (0f, _rotateHorizontal, 0f);
		_cameraRotation *= Quaternion.Euler (-_rotateVertical, 0f, 0f);
        camera.transform.localRotation = _cameraRotation;
    }

    // private void LockCursor(bool isLocked)
	// {
	// 	if (isLocked) 
	// 	{
	// 		Cursor.visible = false;
	// 		Cursor.lockState = CursorLockMode.Locked;
	// 	} else {
	// 		Cursor.visible = true;
	// 		Cursor.lockState = CursorLockMode.None;
	// 	}
	// }
}
