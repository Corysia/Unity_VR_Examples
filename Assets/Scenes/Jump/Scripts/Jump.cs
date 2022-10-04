using UnityEngine;
using UnityEngine.InputSystem;

namespace Scenes.Jump.Scripts
{
    [RequireComponent(typeof(Rigidbody))]

    public class Jump : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 500.0f;
        [SerializeField] public InputActionAsset inputActions;
        private InputAction _jumpAction;
        private InputActionMap _inputActionMap;
        private Rigidbody _body;

        private bool IsGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f),
            Vector3.down, 2.0f);

        void Start()
        {
            _body = GetComponent<Rigidbody>();
            _inputActionMap = inputActions.FindActionMap("Default");
            _jumpAction = _inputActionMap.FindAction("Jump");
            _jumpAction.Enable();
            _jumpAction.performed += OnJump;
        }

        private void OnJump(InputAction.CallbackContext obj)
        {
            if (!IsGrounded)
                return;
            _body.AddForce(Vector3.up * jumpForce);
        }
    }
}