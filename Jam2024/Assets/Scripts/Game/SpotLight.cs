using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpotLight : MonoBehaviour
{
    [SerializeField]
    private float m_Player1LookAngle = 0f;

    [SerializeField]
    private float m_Player2LookAngle = 0f;

    [SerializeField]
    private float m_RotationSpeed = 6f;

    private Quaternion m_TargetRotation = Quaternion.identity;


    private void Start()
    {
        SetTargetRotation(m_Player1LookAngle);
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

    public void OnTurnChanged(PlayerTurn _PlayerTurn)
    {
        SetTargetRotation(_PlayerTurn == PlayerTurn.Player1 ? m_Player1LookAngle : m_Player2LookAngle);
    }
}