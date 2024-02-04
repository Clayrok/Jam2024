using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesUI : MonoBehaviour
{
    [SerializeField]
    private List<Minigame> m_MinigamesList = new List<Minigame>();

    private Minigame m_CurrentMinigame = null;


    public void StartMinigame<T>() where T : Minigame
    {
        foreach (Minigame minigame in m_MinigamesList)
        {
            if (minigame.GetType() == typeof(T))
            {
                m_CurrentMinigame = minigame;
                m_CurrentMinigame.gameObject.SetActive(true);
                return;
            }
        }

        StartRandomMinigame();
    }

    public void StartRandomMinigame()
    {
        Random.InitState((int)Time.time);
        int randomMinigameIndex = Random.Range(0, m_MinigamesList.Count - 1);
        
        m_CurrentMinigame = m_MinigamesList[randomMinigameIndex];
        m_CurrentMinigame.gameObject.SetActive(true);
    }

    public void StopMinigame()
    {
        m_CurrentMinigame.gameObject.SetActive(false);
    }

    public void WinMinigame()
    {
        GameManager.Get().GetBomb().Diffuse();
    }
}