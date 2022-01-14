using System;
using UnityEngine;

namespace Code
{
    public class PlayerMove : MonoBehaviour
    {
        public float MovementSpeed;
        private CharacterController _characterController;
        public float EyeHeight;
        public float CameraDistance;
        private Camera _camera;
        private float _fallSpeed = 0.0f;
        public float Yaw = 0.0f;
        public float Pitch = 0.0f;
        private Vector3 _previousMousePosition;

        private void Start()
        {
            _camera = Camera.main;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            UpdateWalk();
            UpdateLook();
            UpdateZoom();
            UpdateGravity();
            UpdateCamera();
        }

        private void UpdateCamera()
        {
            var offset = new Vector3(0.0f, EyeHeight, -CameraDistance);
            var rotatedOffset = Matrix4x4.Rotate(Quaternion.Euler(-Pitch, Yaw, 0.0f)).MultiplyPoint(offset);
            _camera.gameObject.transform.position = transform.position + rotatedOffset;
        }

        private void UpdateGravity()
        {
            if (_characterController.isGrounded)
            {
                _fallSpeed = 0.0f;
            }
            else //If it isn't on the ground
            {
                _fallSpeed += Physics.gravity.y;
            }
        }

        private void UpdateWalk()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var forwardAndBack = Input.GetAxis("Vertical");

            var move = new Vector3(horizontal, _fallSpeed, forwardAndBack) * MovementSpeed * Time.deltaTime;
            var rotatedMove = Matrix4x4.Rotate(Quaternion.Euler(0.0f, Yaw, 0.0f)).MultiplyPoint(move);

            _characterController.Move(rotatedMove);
        }

        private void UpdateLook()
        {
            var currentMousePosition = Input.mousePosition;
            var mouseX = currentMousePosition.x - _previousMousePosition.x;
            var mouseY = currentMousePosition.y - _previousMousePosition.y;

            Yaw += mouseX;
            Pitch += mouseY;

            Pitch = Mathf.Min(90.0f, Pitch);
            Pitch = Mathf.Max(-90.0f, Pitch);
            //Login

            _previousMousePosition = currentMousePosition;
            
            _camera.transform.rotation = Quaternion.Euler(-Pitch, Yaw, 0.0f);
        }

        private void UpdateZoom()
        {
            
        }
    }
}