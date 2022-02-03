using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    public Vector2 camLimitMin, camLimitMax;
    [SerializeField]
    private float _smoothness;

    [SerializeField]
    private Vector3 _offset;

    private void FixedUpdate()
    {
        if(_target == null){
            return;
        }

        transform.position = Vector3.Lerp(new Vector3(Mathf.Clamp(transform.position.x, camLimitMin.x, camLimitMax.x),Mathf.Clamp(transform.position.y,camLimitMin.y,camLimitMax.y),transform.position.z), 
           new Vector3(Mathf.Clamp(_target.position.x+_offset.x, camLimitMin.x, camLimitMax.x),Mathf.Clamp(_target.position.y+_offset.y,camLimitMin.y,camLimitMax.y),_target.position.z+_offset.z), Time.deltaTime + _smoothness);
    }
    
}
