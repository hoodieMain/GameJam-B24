using Game.MinigameFramework.Scripts.Framework.Input;
using Game.MinigameFramework.Scripts.Tags;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Examples {
    [RequireComponent(typeof(Rigidbody))]
    public class FumperFallsPawn : Pawn {
        [SerializeField] private float speed = 8f;
        [SerializeField] private float gravity = -50f;

        private Vector2 _moveInput = Vector2.zero;
        private float _lookInput = 0f;

        private Rigidbody _rigidbody;
        public Transform _turret;
        private Quaternion aimDirec = Quaternion.identity; 

        // Disable Unity's default gravity when this component is added
        private void Reset() {
            GetComponent<Rigidbody>().useGravity = true;
        }

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update() {
            // Gravity
            _rigidbody.velocity += gravity * Time.deltaTime * Vector3.up;
            // Movement
            //_rigidbody.angularVelocity += new Vector3(_moveInput.y * speed, 0, -_moveInput.x * speed);
            // Aim 
            aimDirec.Set(0f, 90f, 0f, 1);
            _turret.Rotate(0f, 90f, 0f);
        }

        // Handle input
        protected override void OnActionPressed(InputAction.CallbackContext context) {
            // Move
            if (context.action.name == "Move") _moveInput = context.ReadValue<Vector2>();
            // Aim 
            if (context.action.name == "Look") _lookInput = context.ReadValue<float>();

        }
    }
}