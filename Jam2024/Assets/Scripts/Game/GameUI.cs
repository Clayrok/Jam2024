using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject m_DebugMenu = null;

    [SerializeField]
    private HealthBar m_PlayerHealthBar = null;

    [SerializeField]
    private HealthBar m_EnemyHealthBar = null;

    [Header("Turn text")]
    [SerializeField]
    private string m_Player1TurnText = "Your Turn";

    [SerializeField]
    private string m_Player2TurnText = "Enemy's Turn";

    [SerializeField]
    private TextMeshProUGUI m_TurnText = null;

    [SerializeField]
    private Animator m_TurnTextAnimator = null;

    [Header("Timer text")]
    [SerializeField]
    private TextMeshProUGUI m_TimerText = null;

    [SerializeField]
    private Animator m_TimerTextAnimator = null;


    private void Start()
    {
        GameData gameData = GameManager.Get().GetGameData();

        m_PlayerHealthBar.Initialize(gameData.GetPlayerHealth());
        m_EnemyHealthBar.Initialize(gameData.GetEnemy1Health());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            m_DebugMenu.SetActive(!m_DebugMenu.activeInHierarchy);
        }
    }

    public void OnTurnChanged(PlayerTurn _Turn)
    {
        m_TurnText.text = _Turn == PlayerTurn.Player1 ? m_Player1TurnText : m_Player2TurnText;
        m_TurnTextAnimator.SetTrigger("Show");
    }

    public void SetTimerVisibility(bool _Visibility)
    {
        m_TimerText.gameObject.SetActive(_Visibility);
    }

    public void TickTimer(int _SecondsLeft)
    {
        m_TimerText.text = _SecondsLeft.ToString();
        m_TimerTextAnimator.SetTrigger("Tick");
    }
}