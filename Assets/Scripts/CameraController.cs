using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _bodyPlayer;
    [SerializeField] private float _sensiviti = 3f;
    [SerializeField] private float _smoothTime = 0.1f;

    private float _rotationX;
    private float _rotationY;
    private float _rotationCurrentX;
    private float _rotationCurrentY;
    private float _currentVelositiX;
    private float _currentVelositiY;

    void Update()
    {
        MouseTurns();
    }

    private void MouseTurns()
    {
        _rotationX += Input.GetAxis("Mouse X") * _sensiviti;
        _rotationY += Input.GetAxis("Mouse Y") * _sensiviti;
        _rotationY = Mathf.Clamp(_rotationY, -90, 90);

        _rotationCurrentX = Mathf.SmoothDamp(_rotationCurrentX, _rotationX, ref _currentVelositiX, _smoothTime);
        _rotationCurrentY = Mathf.SmoothDamp(_rotationCurrentY, _rotationY, ref _currentVelositiY, _smoothTime);

        _camera.transform.rotation = Quaternion.Euler(-_rotationCurrentY, _rotationCurrentX, 0f);
        _bodyPlayer.transform.rotation = Quaternion.Euler(0f, _rotationCurrentX, 0f);
    }
}
