using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour {
	[SerializeField]
	private LayerMask layerMaskBlock;

	[SerializeField]
	private Transform pointCheck;

	[SerializeField]
	private Material successMaterial;

	[SerializeField]
	private Material waitingMaterial;
	private MeshRenderer meshRenderer;

	[SerializeField]
	private ControllerGamer gameController;
	private bool isSuccessBlock = false;

	void Start() {
		meshRenderer = GetComponent<MeshRenderer>();
	}

	void FixedUpdate() {
		if(Physics.OverlapSphere(pointCheck.position, 0.01f, layerMaskBlock).Length == 1) {
			if (!isSuccessBlock) {
				meshRenderer.material = successMaterial;
				gameController.IncrementBlocksEnabled();
				isSuccessBlock = true;
			}
		} else if (isSuccessBlock) {
			meshRenderer.material = waitingMaterial;
			gameController.DisincrementBlocksEnabled();
			isSuccessBlock = false;
		}
	}
}
