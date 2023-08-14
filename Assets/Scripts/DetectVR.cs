using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

// Source: https://gist.github.com/demonixis/fc2f9154cd9d87e5f1c6a7a1de2dbb70
public class DetectVR : MonoBehaviour
{
	#region Serialized Fields
	[Tooltip("The XR Origin or VR Rig in the scene.")]
	[SerializeField] private GameObject xrOrigin;
	[Tooltip("The Desktop Camera.  This could be a First Person Controller, Third Person Controller, or other camera.")]
	[SerializeField] private Camera cam;
	#endregion

	#region Private Methods
	// Start is called before the first frame update
	private void Start()
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
			EnableDesktopCamera();
			return;
		}
		Debug.Log($"Loaded XR Device: {xrLoader.name}");
		
		var xrDisplay = xrLoader.GetLoadedSubsystem<XRDisplaySubsystem>();
		Debug.Log($"XRDisplay: {xrDisplay != null}");

		if (xrDisplay != null && xrDisplay.TryGetDisplayRefreshRate(out var refreshRate))
		{
			Debug.Log($"Refresh Rate: {refreshRate}hz");
			Time.fixedDeltaTime = 1f / refreshRate;
		} else {
			EnableDesktopCamera();
			return;
		}

		var xrInput = xrLoader.GetLoadedSubsystem<XRInputSubsystem>();
		Debug.Log($"XRInput: {xrInput != null}");

		if (xrInput != null)
		{
			xrInput.TrySetTrackingOriginMode(TrackingOriginModeFlags.Device);
			xrInput.TryRecenter();
		}

		var xrMesh = xrLoader.GetLoadedSubsystem<XRMeshSubsystem>();
		if (xrMesh == null)
		{
			Debug.Log($"XRMesh is null.");
			EnableDesktopCamera();
			return;
		}
		EnableVRCamera();
	}

	private void EnableDesktopCamera()
	{
		Debug.Log($"Enabling Desktop Camera");
		cam.transform.position = xrOrigin.transform.position; // Set the Desktop Camera's position to the XR Origin's position.
		xrOrigin.gameObject.SetActive(false);  // Disable the XR Origin.
		cam.gameObject.SetActive(true); // Enable the Desktop Camera.
	}

	private void EnableVRCamera()
	{
		Debug.Log($"Enabling VR Camera");
		xrOrigin.transform.position = cam.transform.position; // Set the XR Origin's position to the Desktop Camera's position.
		xrOrigin.gameObject.SetActive(true); // Enable the XR Origin.
		cam.gameObject.SetActive(false); // Disable the Desktop Camera.
	}
	#endregion
}