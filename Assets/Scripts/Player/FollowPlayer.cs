using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _shadowTransform;


    private void Update()
    {
        transform.position = new Vector3 (_shadowTransform.position.x, transform.position.y, _shadowTransform.position.z);
    }


}
