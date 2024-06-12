using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Awe.OcclusionVsPortalCulling
{
	public class SpectatorCamera : MonoBehaviour
	{
        [SerializeField] private float cameraSpeed = 10.0f;
        [SerializeField] private float rotationSpeed = 100.0f;

        private bool qPressed;
        private bool cursorVisible;

        void Start()
        {
            cursorVisible = false;
            SetCursor(cursorVisible);

            // Lock and hide the cursor at the start
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Camera rotation
            transform.Rotate(Vector3.up, mouseX);
            transform.Rotate(Vector3.left, mouseY);

            // Preventing gimbal lock
            Vector3 euler = transform.eulerAngles;
            euler.z = 0;
            transform.eulerAngles = euler;

            // Camera translation
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0;

            if (Input.GetKey(KeyCode.E)) y = 1;
            else if (Input.GetKey(KeyCode.Q)) y = -1;

            Vector3 move = transform.right * x + transform.up * y + transform.forward * z;
            transform.position += cameraSpeed * Time.deltaTime * move;

            // Toggle cursor visibility and lock state with escape key
            if (Input.GetKeyDown(KeyCode.Q) && !qPressed)
            {
                qPressed = true;
                cursorVisible = !cursorVisible;

                SetCursor(cursorVisible);
            }

            if (qPressed)
            {
                qPressed = false;
            }
        }

        private void SetCursor(bool cursorVisible)
        {
            if (cursorVisible)
            {

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

    }
}
