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
        LockCursor(true);
        _cameraRotation = camera.transform.localRotation;
    }


    void Update()
    {
        float _moveX = Input.GetAxis("Horizontal") * _inSettingsMouseSpeed * RotationSpeed;
        float _moveY = Input.GetAxis("Vertical") * _inSettingsMouseSpeed * RotationSpeed;

        Vector3 _move = new Vector3(_moveX, 0, _moveY);
        controller.Move(_move * Time.deltaTime * MovementSpeed);

        // float _rotateHorizontal = Input.GetAxis("Mouse X");
	    // float _rotateVertical = Input.GetAxis("Mouse Y");

        // camera.transform.Rotate(Vector3.up * _rotateHorizontal);
        // camera.transform.localRotation = Quaternion.Euler(_rotateVertical, 0f, 0f);
    }

    private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
