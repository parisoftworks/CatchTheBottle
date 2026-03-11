using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.LevelScene
{
    public class PlayerManager : MonoBehaviour
    {
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
            var worldPosition = Camera.main!.ScreenToWorldPoint(new Vector3(
                touchPosition.x, 
                touchPosition.y, 
                Camera.main.nearClipPlane
                ));
            
            var clampedX = Mathf.Clamp(worldPosition.x, 
                GameplayManager.Instance.leftX, 
                GameplayManager.Instance.rightX);
            transform.position = new Vector2(clampedX, -3);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            MainManager.BottlesCaught++;
            GetComponent<AudioSource>().Play();
        }
    }
}
