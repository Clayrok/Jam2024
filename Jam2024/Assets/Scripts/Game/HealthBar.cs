using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Transform m_HealthPointsRoot = null;

    [SerializeField]
    private GameObject m_HealthPointsPrefab = null;


    public void Initialize(int _HealthPointsCount)
    {
        for (int i = 0; i < m_HealthPointsRoot.childCount; i++)
        {
            Destroy(m_HealthPointsRoot.GetChild(i).gameObject);
        }

        for (int i = 0; i < _HealthPointsCount; i++)
        {
            Instantiate(m_HealthPointsPrefab, m_HealthPointsRoot);
        }
    }
}