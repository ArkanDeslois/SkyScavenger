using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform TargetPlayer;

    public float SmoothFollow;

    public Vector3 offset;

    void Update()
    {
        Vector3 DesirePosition = TargetPlayer.position + offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, DesirePosition, SmoothFollow * Time.deltaTime);
        this.transform.position = SmoothPosition;
    }
}
