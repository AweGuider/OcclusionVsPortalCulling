using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Awe.OcclusionVsPortalCulling
{
	public class ToggleCulling : MonoBehaviour
	{
		[SerializeField] private Camera _camera;

		[Tooltip("If you want call Init() on OnValidate(), check it")]
		[SerializeField] private bool _initOnValidate;

		private void Init()
		{
			if (TryGetComponent(out Camera camera))
            {
                _camera = camera;
            }
            else
            {
                Debug.LogError("No Camera component found on this GameObject or its children");
            }
		}

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
			{
				// No Culling
				_camera.useOcclusionCulling = false;
			}
			else if (Input.GetKeyDown(KeyCode.O))
			{
				// Occlusion Culling
				_camera.useOcclusionCulling = true;

			}
			else if (Input.GetKeyDown(KeyCode.P))
			{
				// Portal Culling
			}
        }

        #region Awake, OnEnable, Start, OnDisable, OnDestroy, OnValidate
        void Awake()
		{
			
		}
		void OnEnable()
		{
			
		}
		void Start()
		{
			Init();
		}
		void OnDisable()
		{
			
		}
		void OnDestroy()
		{
			
		}
		void OnValidate()
		{
			if (_initOnValidate) Init();
		}
		#endregion
	}
}
