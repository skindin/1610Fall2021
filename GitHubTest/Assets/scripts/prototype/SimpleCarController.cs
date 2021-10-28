using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
	Rigidbody rigBod;

    public void Start()
    {
		//GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
    }

    public void GetInput()
	{
		m_horizontalInput = Input.GetAxisRaw("Horizontal");
		m_verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
		frontDriverW.steerAngle = m_steeringAngle;
		frontPassengerW.steerAngle = m_steeringAngle;
	}

	private void Accelerate()
	{
		frontDriverW.motorTorque = m_verticalInput * motorForce;
		frontPassengerW.motorTorque = m_verticalInput * motorForce;
	}

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos = _transform.position;
		Quaternion _quat = _transform.rotation;

		_collider.GetWorldPose(out _pos, out _quat);
		_pos = _collider.transform.position - _pos;

		_transform.localPosition = _pos;
		_transform.rotation = _quat;
	}

	public float correctionSpeed;

    private void Update()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.forward), correctionSpeed * Time.deltaTime);
		}
    }

    private void FixedUpdate()
	{
		GetInput();
		Steer();
		Accelerate();
        UpdateWheelPoses();
    }

	private float m_horizontalInput;
	private float m_verticalInput;
	private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
	public float motorForce = 50;
}
