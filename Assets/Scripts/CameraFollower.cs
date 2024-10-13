using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _speed;

    private void LateUpdate()
    {
        Vector3 direction = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, direction, _speed * Time.deltaTime);
    }

}
