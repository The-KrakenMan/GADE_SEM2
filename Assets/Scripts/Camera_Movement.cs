using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    [SerializeField] private Space offsetpositionSpace = Space.Self;
    [SerializeField] private bool LookingTarget = true;

    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    public void Check()
    {
        if (target == null)
        {
            Debug.LogWarning("No target found", this);
            return;
        }

        if (offsetpositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offset);

        }

        else
        {
            transform.position = target.position + offset;
        }

        if (LookingTarget)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
