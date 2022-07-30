using UnityEngine;
using UnityEngine.InputSystem;

namespace Scenes.ControllerButtonPress.Scripts
{
    [RequireComponent(typeof(XxlGrabInteractable))]
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] public InputActionAsset inputActions;
        private InputAction _colorButton;
        private int _color;
        private XxlGrabInteractable _grabInteractable;
        private bool _isHeld;
        private InputActionMap _inputActionMap;

        // Start is called before the first frame update
        private void Start()
        {
            _grabInteractable = GetComponent<XxlGrabInteractable>();
            _inputActionMap = inputActions.FindActionMap("Default");
            _colorButton = _inputActionMap.FindAction("ColorChangeRight");
            _colorButton.performed += ColorChange;
            _colorButton.Enable();
        }

        private void Update()
        {
            if (_grabInteractable.IsHeld() == _isHeld)
                return;
            _isHeld = _grabInteractable.IsHeld();
            if (_isHeld)
            {
                Debug.Log("Held");
                if (_grabInteractable.WhichHand() == XxlGrabInteractable.HoldingHand.Left)
                {
                    Debug.Log("Left Hand");
                    _colorButton = _inputActionMap.FindAction("ColorChangeLeft");
                }
                else
                {
                    Debug.Log("Right Hand");
                    _colorButton = _inputActionMap.FindAction("ColorChangeRight");
                }
                if (_colorButton != null)
                {
                    _colorButton.performed += ColorChange;
                    Debug.Log("Delegate Assigned");
                    _colorButton.Enable();
                }
                else
                {
                    Debug.LogError("Failed to find action");
                }

                Debug.Log("Button Enabled");
            }
            else 
            {
                Debug.Log("Dropped");
                if (_colorButton != null)
                {
                    _colorButton.Disable();
                    Debug.Log("Button disabled");
                    _colorButton.performed -= ColorChange;
                    Debug.Log("Delegate Removed");
                }
            }
        }

        private void ColorChange(InputAction.CallbackContext ctx)
        {
            Debug.Log("Color Change");
            var rend = GetComponent<Renderer>();
            if (++_color > 2) _color = 0;
            var material = rend.material;
            material.color = _color switch
            {
                0 => Color.black,
                1 => Color.blue,
                2 => Color.green,
                _ => material.color
            };
        }
    }
}