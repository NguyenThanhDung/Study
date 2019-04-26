using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SteeringMethod
{
    Hold,
    TouchBorder
}

public class VelocityController : MonoBehaviour
{
    [SerializeField] Vehicle vehicle;
    [SerializeField] Vector3 defaultFrontPointPosition;
    [SerializeField] Vector3 defaultBackPointPosition;
    [SerializeField] Transform frontPoint;
    [SerializeField] Transform backPoint;
    [SerializeField] Transform destPoint;
    [SerializeField] float speedVelocityRatio;
    [SerializeField] float timeToReachDestPoint;
    [SerializeField] SteeringMethod steeringMethod;
    [SerializeField] float steeringSensitivity;

    private float vehicleLength;
    private Vector3 speed;
    private Vector3 steer;
    private float lastTouchPosX;

    void Start()
    {
        this.vehicleLength = (this.frontPoint.position - this.backPoint.position).magnitude;
        Initialize();
    }

    void Update()
    {
        // Calculate speed vector
        Vector3 vehicleDirection = this.frontPoint.position - this.backPoint.position;
        this.speed = vehicleDirection.normalized * this.vehicle.Speed * speedVelocityRatio;

        // Calculate steering vector
        this.steer = GetSteeringVector(this.steeringMethod);

        // Calculate direction vector
        Vector3 direction = this.speed + this.steer;
        direction = direction.normalized * this.speed.magnitude;

        // Calculate steeringAngle
        float steeringAngle = Vector3.SignedAngle(direction, this.frontPoint.position - this.backPoint.position, Vector3.up);
        this.vehicle.DeductSpeed(Mathf.Abs(steeringAngle));

        // Set destPoint position
        this.destPoint.position = this.frontPoint.position + direction;

        // Move frontPoint to destPoint
        float deltaDistance = direction.magnitude / timeToReachDestPoint * Time.deltaTime;
        this.frontPoint.position += direction * deltaDistance;

        // Move backPoint to frontPoint
        Vector3 moveDirectionOfBackPoint = this.frontPoint.position - this.backPoint.position;
        float moveDistanceOfBackPoint = moveDirectionOfBackPoint.magnitude - this.vehicleLength;
        this.backPoint.position += moveDirectionOfBackPoint.normalized * moveDistanceOfBackPoint;
        this.backPoint.RotateAround(this.frontPoint.position, Vector3.up, -steeringAngle * 5f * Time.deltaTime);

        // Move vehicle position to middle point of frontPoint and backPoint
        Vector3 backToMiddleVector = (this.frontPoint.position - this.backPoint.position) * 0.5f;
        Vector3 middlePoint = this.backPoint.position + backToMiddleVector;
        Vector3 translateVector = middlePoint - this.transform.position;
        this.transform.Translate(translateVector);

        // Rotate vehicle follow the direction of frontPoint and backPoint
        float angle = Vector3.SignedAngle(Vector3.forward, this.frontPoint.position - this.backPoint.position, Vector3.up);
        this.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    private void Initialize()
    {
        this.frontPoint.position = this.defaultFrontPointPosition;
        this.backPoint.position = this.defaultBackPointPosition;
        this.destPoint.position = this.defaultFrontPointPosition;
        this.speed = Vector3.zero;
        this.steer = Vector3.zero;
    }

    private Vector3 GetSteeringVector(SteeringMethod steeringMethod)
    {
        if (steeringMethod == SteeringMethod.Hold)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.lastTouchPosX = Input.mousePosition.x;
                return this.steer;
            }
            else if (Input.GetMouseButton(0))
            {
                float swipeDistance = Input.mousePosition.x - this.lastTouchPosX;
                float steeringVolume = swipeDistance / Screen.width;
                float steerVectorLength = steeringVolume * this.steeringSensitivity;
                Vector3 steerVector = this.frontPoint.position - this.backPoint.position;
                steerVector.Normalize();
                steerVector = Quaternion.Euler(0f, 90f, 0f) * steerVector;
                return steerVector * steerVectorLength;
            }
            else
            {
                return Vector3.zero;
            }
        }
        else
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                float steeringVolume = 0f;
                if (Input.GetMouseButton(0))
                {
                    float mouseX = Input.mousePosition.x;
                    float screenMid = Screen.width / 2f;
                    steeringVolume = (mouseX > screenMid) ? 0.3f : -0.3f;
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    steeringVolume = -0.3f;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    steeringVolume = 0.3f;
                }
                float steerVectorLength = steeringVolume * this.steeringSensitivity;
                Vector3 steerVector = this.frontPoint.position - this.backPoint.position;
                steerVector.Normalize();
                steerVector = Quaternion.Euler(0f, 90f, 0f) * steerVector;
                return steerVector * steerVectorLength;
            }
            return Vector3.zero;
        }
    }
}
