using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CarManager : MonoBehaviour
{
    //private float horizontalInput, verticalInput;
    //private float currentSteerAngle, currentbreakForce;
    //private bool isBreaking;



    // Settings
    //[SerializeField] private float motorForce, breakForce, maxSteerAngle;



    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;



    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    public InputActionProperty AccelerationAction, BrakingAction;
    public InputActionProperty LeftRotationAction, RightRotationAction;
    private void FixedUpdate()
    {
        CarMovementManager();
        CarSteeringManager();
        //GetInput();
        //HandleMotor();
        //HandleSteering();
        UpdateWheels();
    }
    private void CarMovementManager()
    {
        float AccelerationValue = AccelerationAction.action.ReadValue<float>();
        float BrakingValue = BrakingAction.action.ReadValue<float>();
        frontLeftWheelCollider.motorTorque = (AccelerationValue - BrakingValue) * 500;
        frontRightWheelCollider.motorTorque = (AccelerationValue - BrakingValue) * 500;
        rearLeftWheelCollider.motorTorque = (AccelerationValue - BrakingValue) * 500;
        rearRightWheelCollider.motorTorque = (AccelerationValue - BrakingValue) * 500;
    }
    private void CarSteeringManager()
    {
        Quaternion LeftRotationValue = LeftRotationAction.action.ReadValue<Quaternion>();
        Quaternion RightRotationValue = RightRotationAction.action.ReadValue<Quaternion>();
        float SteeringAngle = (  LeftRotationValue.w) + (   RightRotationValue.w);
        Debug.Log(SteeringAngle);

        if(1.2 < SteeringAngle && SteeringAngle < 1.6f)
        {
            frontLeftWheelCollider.steerAngle = -30;
            frontRightWheelCollider.steerAngle = -30;
        }else if (1.6f < SteeringAngle && SteeringAngle < 2.0f)
        {
            frontLeftWheelCollider.steerAngle = 0;
            frontRightWheelCollider.steerAngle = 0;
        }
        else if (SteeringAngle < 1.2f)
        {
            frontLeftWheelCollider.steerAngle = 30;
            frontRightWheelCollider.steerAngle = 30;
        }
    }

    //private void GetInput()
    //{
    //    // Steering Input
    //    horizontalInput = Input.GetAxis("Horizontal");



    //    // Acceleration Input
    //    verticalInput = Input.GetAxis("Vertical");



    //    // Breaking Input
    //    isBreaking = Input.GetKey(KeyCode.Space);
    //}



    //private void HandleMotor()
    //{
    //    frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
    //    frontRightWheelCollider.motorTorque = verticalInput * motorForce;
    //    currentbreakForce = isBreaking ? breakForce : 0f;
    //    ApplyBreaking();
    //}



    //private void ApplyBreaking()
    //{
    //    frontRightWheelCollider.brakeTorque = currentbreakForce;
    //    frontLeftWheelCollider.brakeTorque = currentbreakForce;
    //    rearLeftWheelCollider.brakeTorque = currentbreakForce;
    //    rearRightWheelCollider.brakeTorque = currentbreakForce;
    //}



    //private void HandleSteering()
    //{
    //    currentSteerAngle = maxSteerAngle * horizontalInput;
    //frontLeftWheelCollider.steerAngle = currentSteerAngle;
    //    frontRightWheelCollider.steerAngle = currentSteerAngle;
    //}



    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
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
