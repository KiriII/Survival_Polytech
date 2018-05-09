using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed = 0.2f;
    public float high = 5;
    public float zoomSpeed = 1;
    public int minZoom = 3;
    public int maxZoom = 10;
    public Transform target;
    public float smoothing = 3f;

    RaycastHit hit;
    Vector3 offset;
    float speedMult;

    void Start()
    {
        offset = transform.position - target.position;
        speedMult = speed / 100;
    }


    void Update()
    {

        HighPosition();
        

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            WeightPosition();
        }
        else
        {
            Vector3 targetCamPos = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }

    void HighPosition()
    {
        Vector3 directionRay = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, directionRay, out hit, 50))
        {
            if (hit.collider.tag == "terrain")
            {
                if (hit.distance < high)
                {
                    transform.position += new Vector3(0, high - hit.distance, 0) * Time.deltaTime;
                }
                if (hit.distance > high)
                {
                    transform.position -= new Vector3(0, hit.distance - high, 0) * Time.deltaTime;
                }
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y > minZoom)
        {
            transform.position -= new Vector3(0, zoomSpeed * Time.deltaTime, 0);
            speed -= speedMult;
            offset = transform.position - target.position;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.y < maxZoom)
        {
            transform.position += new Vector3(0, zoomSpeed * Time.deltaTime, 0);
            speed += speedMult;
            offset = transform.position - target.position;
        }
    }

    void WeightPosition()
    {
        if (Input.mousePosition.x < 20)
        {
            transform.position -= new Vector3(speed, 0, 0);
            if (transform.position.x < target.position.x - 10.0)
            {
                transform.position += new Vector3(speed, 0, 0);
            }
        }
        if (Input.mousePosition.x > Screen.width - 20)
        {
            transform.position += new Vector3(speed, 0, 0);
            if (transform.position.x > target.position.x + 10.0)
            {
                transform.position -= new Vector3(speed, 0, 0);
            }
        }
        if (Input.mousePosition.y < 20)
        {
            transform.position -= new Vector3(0, 0, speed);
            if (transform.position.z < target.position.z - 10.0)
            {
                transform.position += new Vector3(0, 0, speed);
            }
        }
        if (Input.mousePosition.y > Screen.height - 20)
        {
            transform.position += new Vector3(0, 0, speed);
            if (transform.position.z > target.position.z + 10.0)
            {
                transform.position -= new Vector3(0, 0, speed);
            }
        }
    }
}
