using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{
    [SerializeField] Vehicle vehicle;
    [SerializeField] GameObject frontPoint;
    [SerializeField] GameObject backPoint;
    [SerializeField] GameObject destPoint;

    private const float SPEED_VELOC_RATIO = 0.1f;
    private const float TIME_TO_REACH_DEST_POINT = 20f;

    private float vehicleLength;
    private Vector3 speed;
    private Vector3 steer;
    private float lastTouchPosX;

    void Start()
    {
        this.vehicleLength = (this.frontPoint.transform.position - this.backPoint.transform.position).magnitude;
    }

    void Update()
    {
        // Calculate speed vector
        Vector3 vehicleDirection = this.frontPoint.transform.position - this.backPoint.transform.position;
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
            Vector3 steerVector = this.frontPoint.transform.position - this.backPoint.transform.position;
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

        // Set destPoint position
        this.destPoint.transform.position = this.frontPoint.transform.position + direction;

        // Move frontPoint to destPoint
        float deltaDistance = direction.magnitude / TIME_TO_REACH_DEST_POINT * Time.deltaTime;
        this.frontPoint.transform.position += direction * deltaDistance;

        // Move backPoint to frontPoint
        Vector3 moveDirectionOfBackPoint = this.frontPoint.transform.position - this.backPoint.transform.position;
        float moveDistanceOfBackPoint = moveDirectionOfBackPoint.magnitude - this.vehicleLength;
        this.backPoint.transform.position += moveDirectionOfBackPoint.normalized * moveDistanceOfBackPoint;

        // Move vehicle position to middle point of frontPoint and backPoint
        // float midX = this.backPoint.transform.position.x + (this.frontPoint.transform.position.x - this.backPoint.transform.position.x) / 2f;
        // float midZ = this.backPoint.transform.position.z + (this.frontPoint.transform.position.z - this.backPoint.transform.position.z) / 2f;
        // this.transform.position = new Vector3(midX, this.transform.position.y, midZ);
        Vector3 moveDirectionOfVehicle = (this.frontPoint.transform.position - this.backPoint.transform.position) * 0.5f;
        this.transform.position = this.backPoint.transform.position + moveDirectionOfVehicle;
    }
}
