using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField]
    private float m_BaseAngle = 11f;

    [SerializeField]
    private float m_TableAngle = 28f;

    [SerializeField]
    private float m_RotationSpeed = 1f;

    private Quaternion m_TargetRotation = Quaternion.identity;


    private void Start()
    {
        LookUp();
        transform.rotation = m_TargetRotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetRotation, m_RotationSpeed * Time.deltaTime);
    }

    private void SetTargetRotation(float _Angle)
    {
        m_TargetRotation = Quaternion.AngleAxis(_Angle, Vector3.right);
    }

    public void LookUp()
    {
        SetTargetRotation(m_BaseAngle);
    }

    public void LookAtTheTable()
    {
        SetTargetRotation(m_TableAngle);
    }
}