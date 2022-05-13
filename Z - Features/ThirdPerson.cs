using System;
using System.Collections;
using MelonLoader;
using UnityEngine;
namespace ThirdPersonSetup
{
	internal class ThirdPerson
	{
		internal static void Initialize()
{
			MelonLogger.Msg("ThirdPerson Initialized");
	GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
	UnityEngine.Object.Destroy(gameObject.GetComponent<MeshRenderer>());
	referenceCamera = GameObject.Find("Camera (eye)");
	if (referenceCamera == null)
	{
		referenceCamera = GameObject.Find("CenterEyeAnchor");
	}
	if (referenceCamera != null)
	{
		gameObject.transform.localScale = referenceCamera.transform.localScale;
		Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
		if (gameObject.GetComponent<Collider>())
		{
			gameObject.GetComponent<Collider>().enabled = false;
		}
		gameObject.GetComponent<Renderer>().enabled = false;
		gameObject.AddComponent<Camera>();
		GameObject gameObject2 = referenceCamera;
		gameObject.transform.parent = gameObject2.transform;
		gameObject.transform.rotation = gameObject2.transform.rotation;
		gameObject.transform.position = gameObject2.transform.position;
		gameObject.transform.position -= gameObject.transform.forward * 2f;
		gameObject2.GetComponent<Camera>().enabled = false;
		gameObject.GetComponent<Camera>().fieldOfView = 75f;
		gameObject.GetComponent<Camera>().nearClipPlane /= 4f;
		TPCameraBack = gameObject;
		GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject3.GetComponent<MeshRenderer>());
		gameObject3.transform.localScale = referenceCamera.transform.localScale;
		Rigidbody rigidbody2 = gameObject3.AddComponent<Rigidbody>();
		rigidbody2.isKinematic = true;
		rigidbody2.useGravity = false;
		if (gameObject3.GetComponent<Collider>())
		{
			gameObject3.GetComponent<Collider>().enabled = false;
		}
		gameObject3.GetComponent<Renderer>().enabled = false;
		gameObject3.AddComponent<Camera>();
		gameObject3.transform.parent = gameObject2.transform;
		gameObject3.transform.rotation = gameObject2.transform.rotation;
		gameObject3.transform.Rotate(0f, 180f, 0f);
		gameObject3.transform.position = gameObject2.transform.position;
		gameObject3.transform.position += -gameObject3.transform.forward * 2f;
		gameObject2.GetComponent<Camera>().enabled = false;
		gameObject3.GetComponent<Camera>().fieldOfView = 75f;
		gameObject3.GetComponent<Camera>().nearClipPlane /= 4f;
		TPCameraFront = gameObject3;
		TPCameraBack.GetComponent<Camera>().enabled = false;
		TPCameraFront.GetComponent<Camera>().enabled = false;
		referenceCamera.GetComponent<Camera>().enabled = true;
		MelonCoroutines.Start(Loop());
	}
}


internal static IEnumerator Loop()
{
	for (; ; )
	{
		if (TPCameraBack != null && TPCameraFront != null)
		{
			if (CameraSetup == 0)
			{
				TPCameraBack.GetComponent<Camera>().enabled = false;
				TPCameraFront.GetComponent<Camera>().enabled = false;
			}
			else if (CameraSetup == 1)
			{
				TPCameraBack.GetComponent<Camera>().enabled = true;
				TPCameraFront.GetComponent<Camera>().enabled = false;
			}
			else if (CameraSetup == 2)
			{
				TPCameraBack.GetComponent<Camera>().enabled = false;
				TPCameraFront.GetComponent<Camera>().enabled = true;
			}
			if (CameraSetup != 0)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					CameraSetup = 0;
				}
				float axis = Input.GetAxis("Mouse ScrollWheel");
				if (axis > 0f)
				{
					TPCameraBack.transform.position += TPCameraBack.transform.forward * 0.1f;
					TPCameraFront.transform.position -= TPCameraBack.transform.forward * 0.1f;
					zoomOffset += 0.1f;
				}
				else if (axis < 0f)
				{
					TPCameraBack.transform.position -= TPCameraBack.transform.forward * 0.1f;
					TPCameraFront.transform.position += TPCameraBack.transform.forward * 0.1f;
					zoomOffset -= 0.1f;
				}
			}
		}
		yield return new WaitForEndOfFrame();
	}

		}
		internal static GameObject TPCameraBack;
		internal static GameObject TPCameraFront;
		internal static GameObject referenceCamera;
		internal static float zoomOffset;
		internal static float offsetX;
		internal static float offsetY;
		public static int CameraSetup;
	}
}