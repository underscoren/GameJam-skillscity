using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private Vector2 _moveTarget;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _camOffset;

    void Start() {
        if(!_camera) _camera = Camera.main;
        _moveTarget = transform.position;
    }

    void Update() {
        if(Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            
            _moveTarget = _camera.ScreenToWorldPoint(
                new Vector3(pos.x, pos.y, _camOffset)
            );

            //Debug.Log(_moveTarget);
        }

        Vector3 currentPos = transform.position;

        float t = 1 - Mathf.Pow(_speed, Time.deltaTime); // better framerate-independent lerp (SimonDev)
        transform.position = Vector3.Lerp(currentPos, _moveTarget, t);
    }
}
