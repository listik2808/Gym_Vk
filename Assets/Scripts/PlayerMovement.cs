using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _rotationSpeed = 0.1f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _player;
    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        Vector3 direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        _controller.Move(direction * (_speed * Time.deltaTime));

        if (direction != Vector3.zero)
        {
            _player.rotation = Quaternion.Slerp(_player.rotation, Quaternion.LookRotation(direction), _rotationSpeed);
        }
    }
}
