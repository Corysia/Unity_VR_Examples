using Unity.XR.CoreUtils;
using UnityEngine;

namespace Scenes.Jump.Scripts
{
    /** Prevents the user from walking thru walls.
    Add this script to your XR Origin
    TODO: this doesn't quite work as expected when doing a Headset Reset (long press of the Oculus button)
 */
    [RequireComponent(typeof(XROrigin))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class RoomscaleCC : MonoBehaviour
    {
        private CapsuleCollider _collider;
        private XROrigin _rig;
    
        private void Start()
        {
            _collider = GetComponent<CapsuleCollider>();
            _rig = GetComponent<XROrigin>();
        }

        private void FixedUpdate()
        {
            // allow crouching
            // Reference: Valem (https://youtu.be/5NRTT8Tbmoc)
            _collider.height = _rig.CameraInOriginSpaceHeight + 0.15f; // 15cm is about the distance from your eyes to the top of your head
        
            // put the capsule where the headset is
            var capsuleCenter = transform.InverseTransformPoint(_rig.Camera.transform.position);
            _collider.center = new Vector3(capsuleCenter.x, _collider.height / 2, capsuleCenter.z);
        
            // the magic jigger for physical walking -- without this, you don't collide when you walk around in the play space
            // Source: Moardak (Moardak#2809)
            _collider.transform.Translate(new Vector3(0.001f, -0.001f, 0.001f));
            _collider.transform.Translate(new Vector3(-0.001f, -0.001f, -0.001f));
        }
    }
}