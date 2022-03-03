using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour {
	[SerializeField]
	private float speedMove;

	private Rigidbody rigidBody;
	private float horizontalAxis;
	private float verticalAxis;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	void Update() {
		CheckKeyboard();
	}

	void FixedUpdate() {
		MoveAction();
	}

	void CheckKeyboard() {
		horizontalAxis = Input.GetAxis("Horizontal");
		verticalAxis = Input.GetAxis("Vertical");
	}

	void MoveAction() {
		rigidBody.velocity = new Vector3(horizontalAxis * speedMove, rigidBody.velocity.y, verticalAxis * speedMove);
	}
}
