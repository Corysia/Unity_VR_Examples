using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
	public GameObject xrOrigin;
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
			Debug.Log($"XRLoader is null.");
			xrOrigin.gameObject.SetActive(false);
			cam.gameObject.SetActive(true);
			return;
		}
		Debug.Log($"Loaded XR Device: {xrLoader.name}");

		xrOrigin.gameObject.SetActive(true);
		cam.gameObject.SetActive(false);
		
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