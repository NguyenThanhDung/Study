using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{
    [SerializeField] Vehicle vehicle;
    [SerializeField] Transform frontPoint;
    [SerializeField] Transform backPoint;
    [SerializeField] Transform destPoint;

    private const float SPEED_VELOC_RATIO = 0.1f;
    private const float TIME_TO_REACH_DEST_POINT = 20f;

    private float vehicleLength;
    private Vector3 speed;
    private Vector3 steer;
    private float lastTouchPosX;

    void Start()
    {
        this.vehicleLength = (this.frontPoint.position - this.backPoint.position).magnitude;
    }

    void Update()
    {
        // Calculate speed vector
        Vector3 vehicleDirection = this.frontPoint.position - this.backPoint.position;
        this.speed = vehicleDirection.normalized * this.vehicle.Speed * SPEED_VELOC_RATIO;

        // Calculate steering vector
        if (Input.GetMouseButtonDown(0))
        {
            this.lastTouchPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            float swipeDistance = Input.mousePosition.x - this.lastTouchPosX;
            float steeringVolume = swipeDistance / Screen.width;
            float steerVectorLength = steeringVolume * 10f;
            Vector3 steerVector = this.frontPoint.position - this.backPoint.position;
            steerVector.Normalize();
            steerVector = Quaternion.Euler(0f, 90f, 0f) * steerVector;
            this.steer = steerVector * steerVectorLength;
        }
        else
        {
            this.steer = Vector3.zero;
        }

        // Calculate direction vector
        Vector3 direction = this.speed + this.steer;
        direction = direction.normalized * speed.magnitude;

        // Calculate steeringAngle
        float steeringAngle = Vector3.SignedAngle(direction, this.frontPoint.position - this.backPoint.position, Vector3.up);
        this.vehicle.DeductSpeed(Mathf.Abs(steeringAngle));

        // Set destPoint position
        this.destPoint.position = this.frontPoint.position + direction;

        // Move frontPoint to destPoint
        float deltaDistance = direction.magnitude / TIME_TO_REACH_DEST_POINT * Time.deltaTime;
        this.frontPoint.position += direction * deltaDistance;

        // Move backPoint to frontPoint
        Vector3 moveDirectionOfBackPoint = this.frontPoint.position - this.backPoint.position;
        float moveDistanceOfBackPoint = moveDirectionOfBackPoint.magnitude - this.vehicleLength;
        this.backPoint.position += moveDirectionOfBackPoint.normalized * moveDistanceOfBackPoint;
        this.backPoint.RotateAround(this.frontPoint.position, Vector3.up, -steeringAngle * 3f * Time.deltaTime);

        // Move vehicle position to middle point of frontPoint and backPoint
        Vector3 moveDirectionOfVehicle = (this.frontPoint.position - this.backPoint.position) * 0.5f;
        this.transform.position = this.backPoint.position + moveDirectionOfVehicle;

        float angle = Vector3.SignedAngle(Vector3.forward, this.frontPoint.position - this.backPoint.position, Vector3.up);
        this.transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
