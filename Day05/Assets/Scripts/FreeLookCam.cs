using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Cameras;

public class FreeLookCam : PivotBasedCameraRig
{
    [SerializeField] private float m_MoveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
    [Range(0f, 10f)] [SerializeField] private float m_TurnSpeed = 1.5f;   // How fast the rig will rotate from user input.
    [SerializeField] private float m_TurnSmoothing = 0.0f;                // How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
    [SerializeField] private float m_TiltMax = 75f;                       // The maximum value of the x axis rotation of the pivot.
    [SerializeField] private float m_TiltMin = 45f;                       // The minimum value of the x axis rotation of the pivot.
    public bool followCursor = false;

    private float m_LookAngle;                    // The rig's y axis rotation.
    private float m_TiltAngle;                    // The pivot's x axis rotation.
    private const float k_LookDistance = 100f;    // How far in front of the pivot the character's look target is.
    private Vector3 m_PivotEulers;
    private Quaternion m_PivotTargetRot;
    private Quaternion m_TransformTargetRot;

    protected override void Awake()
    {
        base.Awake();
        // Cursor.visible = followCursor;
        m_PivotEulers = m_Pivot.rotation.eulerAngles;

        m_PivotTargetRot = m_Pivot.transform.localRotation;
        m_TransformTargetRot = transform.localRotation;
        transform.position = new Vector3(transform.position.x, transform.position.y, -1.5f);
    }


    protected void Update()
    {
        if (followCursor) {
            HandleRotationMovement();
        }
        HandleKeysPressed();
    }
    
    protected override void FollowTarget(float deltaTime)
    {
        if (m_Target == null) return;
        transform.position = Vector3.Lerp(transform.position, m_Target.position, deltaTime * m_MoveSpeed);
    }

    private void HandleKeysPressed()
    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.E)) {
            newPos += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.Q)) {
            newPos -= Vector3.up;
        }
        else if (Input.GetKey(KeyCode.W)) {
            newPos -= Vector3.back;
        }
        else if (Input.GetKey(KeyCode.S)) {
            newPos -= Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.D)) {
            newPos -= Vector3.left;
        }
        else if (Input.GetKey(KeyCode.A)) {
            newPos -= Vector3.right;
        }
        transform.position = new Vector3(Mathf.Clamp(newPos.x, -75, 75), Mathf.Clamp(newPos.y, 50, 175), Mathf.Clamp(newPos.z, -1, 250));
    }

    private void HandleRotationMovement()
    {
        if (Time.timeScale < float.Epsilon)
            return;

        var x = CrossPlatformInputManager.GetAxis("Mouse X");
        var y = CrossPlatformInputManager.GetAxis("Mouse Y");

        m_LookAngle += x * m_TurnSpeed;

        m_TransformTargetRot = Quaternion.Euler(0f, m_LookAngle, 0f);

        m_TiltAngle -= y * m_TurnSpeed;
        m_TiltAngle = Mathf.Clamp(m_TiltAngle, -m_TiltMin, m_TiltMax);

        m_PivotTargetRot = Quaternion.Euler(m_TiltAngle, m_PivotEulers.y , m_PivotEulers.z);

        if (m_TurnSmoothing > 0)
        {
            m_Pivot.localRotation = Quaternion.Slerp(m_Pivot.localRotation, m_PivotTargetRot, m_TurnSmoothing * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, m_TransformTargetRot, m_TurnSmoothing * Time.deltaTime);
        }
        else
        {
            m_Pivot.localRotation = m_PivotTargetRot;
            transform.localRotation = m_TransformTargetRot;
        }
    }
}
