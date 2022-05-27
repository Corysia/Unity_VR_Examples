using Unity.XR.CoreUtils;
using UnityEngine;

/** Prevents the user from walking thru walls.
    Add this script to your XR Origin
 */
[RequireComponent(typeof(XROrigin))]
[RequireComponent(typeof(CharacterController))]
public class RoomscaleFix : MonoBehaviour
{
    private CharacterController _character;
    private XROrigin _rig;
    
    private void Start()
    {
        _character = GetComponent<CharacterController>();
        _rig = GetComponent<XROrigin>();
    }

    private void FixedUpdate()
    {
        _character.height = _rig.CameraInOriginSpaceHeight + 0.15f; // 15cm is about the distance from your eyes to the top of your head
        
        // put the capsule where the headset is
        var capsuleCenter = transform.InverseTransformPoint(_rig.Camera.transform.position);
        _character.center = new Vector3(capsuleCenter.x, _character.height / 2 + _character.skinWidth, capsuleCenter.z);
        
        // the magic jigger for physical walking -- without this, you don't collide when you walk around in the play space
        _character.Move(new Vector3(0.001f, -0.001f, 0.001f));
        _character.Move(new Vector3(-0.001f, -0.001f, -0.001f));
    }
}