using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	[SerializeField] private Camera[] cameras;

	[SerializeField]
	[Range(0, 1)]
	private float seperationPercent = 0;
	[SerializeField]
	private float speed = 1;

	[SerializeField]
	private bool isSpinning = false;

	private float rotTimeOffset = 0;

	private float DistanceSeperation {
		get {
			return seperationPercent / cameras.Length;
		}
	}
	private float RotationSeperation {
		get {
			return (seperationPercent / cameras.Length) * 360;
		}
	}

	void Start() {
		
	}

	void Update() {

		rotTimeOffset = (rotTimeOffset + (Time.deltaTime * speed));

		for (int i = 0; i < cameras.Length; i++) {
			int index = i + 1;

			Vector3 angle = Quaternion.AngleAxis(Mathf.LerpUnclamped(0, 360, rotTimeOffset % 1) + (RotationSeperation * index), Vector3.forward) * Vector3.right;
			float distance = Mathf.LerpUnclamped(0, DistanceSeperation, GetOffset(rotTimeOffset + (DistanceSeperation * index)));

			if (isSpinning) cameras[i].transform.position = new Vector3(transform.position.x, transform.position.y, -10) + (angle * distance);
			else cameras[i].transform.position = new Vector3(transform.position.x, transform.position.y, -10) + (Vector3.right * distance);
		}
	}

	private float GetOffset(float input) {
		return Mathf.Sin(input);
	}

}
