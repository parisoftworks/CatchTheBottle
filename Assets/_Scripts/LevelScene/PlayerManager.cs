using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.LevelScene
{
    public class PlayerManager : MonoBehaviour
    {
        // Initialize variables
        private Vector2 _touchPosition;

        private void Update()
        {
            if (Touchscreen.current != null)
                PerformPlayerMove();
        }

        private void PerformPlayerMove()
        {
            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.isPressed)
            {
                _touchPosition = touch.position.ReadValue();
                HandleTouch(_touchPosition);
            }

            if (touch.press.wasPressedThisFrame)
                _touchPosition = touch.position.ReadValue();
        }

        private void HandleTouch(Vector2 touchPosition)
        {
            // Convert touch position to world position
            var worldPosition = Camera.main!.ScreenToWorldPoint(new Vector3(
                touchPosition.x, 
                touchPosition.y, 
                Camera.main.nearClipPlane
                ));
            
            // Use position
            transform.position = worldPosition.x switch
            {
                <= 1.5f and >= -1.5f => new Vector2(worldPosition.x, -3f),
                < -1.5f => new Vector2(-1.5f, -3f),
                > 1.5f => new Vector2(1.5f, -3f),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            MainManager.BottlesCaught++;
            GetComponent<AudioSource>().Play();
        }
    }
}
