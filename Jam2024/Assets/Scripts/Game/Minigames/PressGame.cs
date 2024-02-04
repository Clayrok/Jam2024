using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressGame : Minigame
{
    [SerializeField]
    private Transform m_ProgressTransform = null;

    [SerializeField]
    private float m_ButtonProgressAdded = 5f;

    [SerializeField]
    private float m_ProgressDecrease = 20f;

    private float m_CurrentProgress = 0f;


    private void OnEnable()
    {
        m_CurrentProgress = 0;
    }

    public void Add()
    {
        m_CurrentProgress = Mathf.Clamp(m_CurrentProgress + m_ButtonProgressAdded, 0f, 100f);
        UpdateProgress();

        if (m_CurrentProgress == 100f)
        {
            GameManager.Get().GetMinigamesUI().WinMinigame();
        }
    }

    private void Update()
    {
        if (m_CurrentProgress == 100f)
        {
            return;
        }

        m_CurrentProgress -= m_ProgressDecrease * Time.deltaTime;

        UpdateProgress();
    }

    private void UpdateProgress()
    {
        Vector3 progressBarScale = m_ProgressTransform.localScale;
        progressBarScale.x = Mathf.Clamp01(m_CurrentProgress / 100f);
        m_ProgressTransform.localScale = progressBarScale;
    }
}