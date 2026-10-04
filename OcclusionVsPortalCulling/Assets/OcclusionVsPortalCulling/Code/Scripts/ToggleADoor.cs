using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Awe.OcclusionVsPortalCulling
{
    [RequireComponent(typeof(OcclusionPortal))]
	public class ToggleADoor : MonoBehaviour
	{
        [SerializeField] private int _doorIndex;

		[SerializeField] private bool _isOpen;
		[SerializeField] private OcclusionPortal _portal;

        private void Init()
        {
            _portal = GetComponent<OcclusionPortal>();

        }

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && _doorIndex == 1)
            {
                ToggleDoor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && _doorIndex == 2)
            {
                ToggleDoor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && _doorIndex == 3)
            {
                ToggleDoor();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && _doorIndex == 4)
            {
                ToggleDoor();
            }
        }

        [ContextMenu("Toggle Door")]
		public void ToggleDoorContext()
        {
            ToggleDoor();
        }

        private void ToggleDoor()
        {
            _isOpen = !_isOpen;
            _portal.open = _isOpen;

            if (_isOpen)
            {
                // Open door
                transform.localRotation = Quaternion.Euler(0, transform.localRotation.y - 90, 0);
            }
            else
            {
                // Close door
                transform.localRotation = Quaternion.Euler(0, transform.localRotation.y + 90, 0);
            }
        }

        private void OnValidate()
        {
            Init();
            _portal.open = _isOpen;

        }
    }
}
