using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour {

	[SerializeField] private float _rotationSensitivity = 1000f;
	private bool _dragging;

    [SerializeField] private GameObject MenuOverlay;

    private void Awake() {

    }

	void ToggleOverlay() {
		MenuOverlay.SetActive(true);
    }

    void Update()
    {
		if (Input.GetMouseButton(0)) {

			if (_dragging) {
				float degree = Input.GetAxis("Mouse X");
				transform.Rotate(0f, -degree * _rotationSensitivity * Time.deltaTime, 0f);
			} else {

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out RaycastHit hit)) {
					
					if (hit.collider.GetComponent<Character>() is Character character) {

						if (!_dragging) _dragging = true;
					}
				}
			}

		} else _dragging = false;

	}

	public void ExitGame() {
        Application.Quit();
    }

}
