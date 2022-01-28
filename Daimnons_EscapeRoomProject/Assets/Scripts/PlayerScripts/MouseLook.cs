using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	private float _sensitivity;
	public float Sensitivity { get => _sensitivity; set => _sensitivity = value; }

	[SerializeField] GameObject _buttons;
	[SerializeField] Transform playerTransform;

	[SerializeField] [Range(0.1f, 9f)]
	private float sensitivity = 2f;

    [SerializeField] [Range(0f, 90f)]
    float yRotationLimit = 88f;

    [SerializeField] [Range(0f, 90f)]
    float xRotationLimit = 88f;

	private const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	private const string yAxis = "Mouse Y";

	private Vector2 rotation = Vector2.zero;


    private void Update()
	{
		Cursor.visible = true;
		_buttons.SetActive(true);

		if (Input.GetKey(KeyCode.LeftShift))
			LookAround();
	}


	private void LookAround()
	{
		Cursor.visible = false;
		_buttons.SetActive(false);

		rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;

        rotation.x = Mathf.Clamp(rotation.x, -xRotationLimit, xRotationLimit);
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat; //Quaternions seem to rotate more consistently than EulerAngles. Sensitivity seemed to change slightly at certain degrees using Euler. transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
    }
	
}

