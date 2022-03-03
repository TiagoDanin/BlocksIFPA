using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	[SerializeField]
	private float sensitivity;

	private float rotationX = 0;
	private float rotationY = 0;

	private float angleMin = -70;
	private float angleMax = 70;

	private float smoothRotX = 0;
	private float smoothRotY = 0;

	private float smoothCoefX = 0.5f;
	private float smoothCoefY = 0.5f;

	void FixedUpdate() {
		float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivity;
		float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivity;

		smoothRotX = Mathf.Lerp(smoothRotX, horizontalDelta, smoothCoefX);
		smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefY);

		rotationX += smoothRotX;
		rotationY += smoothRotY;

		rotationX = Mathf.Clamp(rotationX, angleMin, angleMax);
		rotationY = Mathf.Clamp(rotationY, angleMin, angleMax);

		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
}
