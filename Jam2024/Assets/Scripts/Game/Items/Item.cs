using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    private Light m_Light = null;

    [SerializeField]
    private float m_LightIntensityOnHovering = 2f;

    private float m_LightBaseIntensity = 0;

    private bool m_IsHovered = false;


    private void Start()
    {
        m_LightBaseIntensity = m_Light.intensity;
    }

    protected abstract void Use();

    private void OnMouseEnter()
    {
        if (!m_IsHovered && GameManager.Get().GetCanUseItems())
        {
            m_Light.intensity = m_LightIntensityOnHovering;
            m_IsHovered = true;
        }
    }

    private void OnMouseExit()
    {
        if (m_IsHovered)
        {
            m_Light.intensity = m_LightBaseIntensity;
            m_IsHovered = false;
        }
    }

    private void OnMouseUp()
    {
        if (GameManager.Get().GetCanUseItems())
        {
            Use();
        }
    }
}