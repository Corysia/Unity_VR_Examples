using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

// Source: https://gist.github.com/demonixis/fc2f9154cd9d87e5f1c6a7a1de2dbb70
public class DetectVR : MonoBehaviour
{
	[Tooltip("The XR Origin or VR Rig in the scene.")]
	public GameObject xrOrigin;
	[Tooltip("The Desktop Camera.  This could be a First Person Controller, Third Person Controller, or other camera.")]
	public Camera cam;

	// Start is called before the first frame update
	public void Start()
	{
		var xrSettings = XRGeneralSettings.Instance;
		if (xrSettings == null)
		{
			Debug.Log($"XRGeneralSettings is null.");
			return;
		}

		var xrManager = xrSettings.Manager;
		if (xrManager == null)
		{
			Debug.Log($"XRManagerSettings is null.");
			return;
		}

		var xrLoader = xrManager.activeLoader;
		if (xrLoader == null)
		{
			// If the XR Loader is null, we don't have a VR camera.
			Debug.Log($"XRLoader is null.");
			xrOrigin.gameObject.SetActive(false);  // Disable the XR Origin.
			cam.gameObject.SetActive(true); // Enable the Desktop Camera.
			return;
		}
		Debug.Log($"Loaded XR Device: {xrLoader.name}");
		// If we've reached this point, we have a VR camera.
		xrOrigin.gameObject.SetActive(true); // Enable the XR Origin.
		cam.gameObject.SetActive(false); // Disable the Desktop Camera.
		
		var xrDisplay = xrLoader.GetLoadedSubsystem<XRDisplaySubsystem>();
		Debug.Log($"XRDisplay: {xrDisplay != null}");

		if (xrDisplay != null)
		{
			if (xrDisplay.TryGetDisplayRefreshRate(out var refreshRate))
			{
				Debug.Log($"Refresh Rate: {refreshRate}hz");
			}
		}

		var xrInput = xrLoader.GetLoadedSubsystem<XRInputSubsystem>();
		Debug.Log($"XRInput: {xrInput != null}");

		if (xrInput != null)
		{
			xrInput.TrySetTrackingOriginMode(TrackingOriginModeFlags.Device);
			xrInput.TryRecenter();
		}

		var xrMesh = xrLoader.GetLoadedSubsystem<XRMeshSubsystem>();
		Debug.Log($"XRMesh: {xrMesh != null}");
	}
}