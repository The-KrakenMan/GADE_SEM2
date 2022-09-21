using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float speed = .1f;

    private float horizontalInput;
    private float verticalInput;
    private float brakeforce;
    private float SteeringAngle;

    private bool braking;

    private string HORIZONTAL = "Horizontal";
    private string VERTICAL = "Vertical";

    [SerializeField] private float motorStrength;
    [SerializeField] private float brakeStrength;
    [SerializeField] private float MaxSteeringAngle;

    [SerializeField] private WheelCollider Left_Front_Collider;
    [SerializeField] private WheelCollider Right_Front_Collider;
    [SerializeField] private WheelCollider Left_Back_Collider;
    [SerializeField] private WheelCollider Right_Back_Collider;

    [SerializeField] private Transform Left_Front_Transform;
    [SerializeField] private Transform Right_Front_Transform;
    [SerializeField] private Transform Left_Back_Transform;
    [SerializeField] private Transform Right_Back_Transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
    }

    /*void Movement()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(zDirection, 0.0f, xDirection);

        transform.position += moveDirection;
    }*/

    private void FixedUpdate()
    {
        GetInput();
        Steering();
        UpdatingWheels();
        MotorHandel();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        braking = Input.GetKey(KeyCode.Space);
    }

    private void Steering()
    {
        SteeringAngle = MaxSteeringAngle * horizontalInput;
        Left_Front_Collider.steerAngle = SteeringAngle;
        Right_Front_Collider.steerAngle = SteeringAngle;
    }

    private void UpdatingWheels()
    {
        UpdateSingleWheel(Left_Front_Collider, Left_Front_Transform);
        UpdateSingleWheel(Right_Front_Collider, Right_Front_Transform);
        UpdateSingleWheel(Left_Back_Collider, Left_Back_Transform);
        UpdateSingleWheel(Right_Back_Collider, Right_Back_Transform);
    }

    private void MotorHandel()
    {
        Left_Front_Collider.motorTorque = verticalInput * motorStrength;
        Right_Front_Collider.motorTorque = verticalInput * motorStrength;
        brakeforce = braking ? brakeStrength : 0f;

        if (braking == true)
        {
            StartBraking();
        }
    }

    private void StartBraking()
    {
        Left_Front_Collider.brakeTorque = brakeforce;
        Right_Front_Collider.brakeTorque = brakeforce;
        Left_Back_Collider.brakeTorque = brakeforce;
        Right_Back_Collider.brakeTorque = brakeforce;
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
