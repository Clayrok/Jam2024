using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurn
{
    Player1 = 0,
    Player2 = 1
}

public class GameManager : MonoBehaviour
{
    private static GameManager s_Instance = null;

    [Header("Refs")]
    [SerializeField]
    private GameData m_GameData;

    [SerializeField]
    private GameUI m_GameUI = null;

    [SerializeField]
    private MinigamesUI m_MinigamesUI = null;

    [SerializeField]
    private GameCamera m_Camera = null;

    [SerializeField]
    private Bomb m_Bomb = null;

    [SerializeField]
    private Animator m_BombAnimator = null;

    [SerializeField]
    private SpotLight m_SpotLight = null;

    [Header("Settings")]
    [SerializeField]
    private int m_TurnDurationSeconds = 5;

    [SerializeField]
    private float m_InterTurnDurationSeconds = 1.5f;

    [SerializeField]
    private float m_BombMoveSpeed = 10f;

    [SerializeField]
    private int m_PlayerHealth = 3;

    [SerializeField]
    private int m_EnemyHealth = 3;

    public PlayerTurn m_PlayerTurn { get; private set; } = PlayerTurn.Player1;

    private IEnumerator m_StartTimerCoroutine = null;

    private bool m_CanUseItems = false;


    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        m_PlayerHealth = m_GameData.GetPlayerHealth();
        m_EnemyHealth = m_GameData.GetEnemy1Health();

        SetTurn(PlayerTurn.Player1);
    }

    [ContextMenu("End Turn")]
    public void EndTurn()
    {
        m_MinigamesUI.StopMinigame();

        m_Camera.LookUp();
        m_CanUseItems = false;
        StartCoroutine(StartInterTurnCoroutine());
    }

    private void StartNewTurn()
    {
        if (m_PlayerTurn == PlayerTurn.Player1)
        {
            SetTurn(PlayerTurn.Player2);
        }
        else if (m_PlayerTurn == PlayerTurn.Player2)
        {
            SetTurn(PlayerTurn.Player1);
        }
    }

    public void SetTurn(PlayerTurn _PlayerTurn)
    {
        m_PlayerTurn = _PlayerTurn;

        StartCoroutine(StartTurnCoroutine());
    }

    private void StartTimer()
    {
        if (m_StartTimerCoroutine != null)
        {
            StopTimer();
        }

        m_StartTimerCoroutine = StartTimerCoroutine();
        StartCoroutine(m_StartTimerCoroutine);
    }

    private IEnumerator StartTurnCoroutine()
    {
        m_BombAnimator.SetInteger("Player", (int)m_PlayerTurn);
        m_SpotLight.OnTurnChanged(m_PlayerTurn);

        yield return new WaitForSeconds(0.25f);

        if (m_PlayerTurn == PlayerTurn.Player1)
        {
            m_Camera.LookAtTheTable();
            m_CanUseItems = true;
        }

        yield return new WaitForSeconds(0.5f);

        m_Bomb.Activate();

        m_GameUI.OnTurnChanged(m_PlayerTurn);

        StartTimer();
    }

    private IEnumerator StartTimerCoroutine()
    {
        int timeLeft = m_TurnDurationSeconds;

        m_GameUI.SetTimerVisibility(true);

        do
        {
            m_GameUI.TickTimer(timeLeft);

            yield return new WaitForSeconds(1.0f);
            timeLeft--;
        } while (timeLeft > 0);

        m_GameUI.SetTimerVisibility(false);
        EndTurn();
    }

    private IEnumerator StartInterTurnCoroutine()
    {
        m_BombAnimator.SetInteger("Player", -1);

        yield return new WaitForSeconds(1.0f);

        StartNewTurn();
    }

    private void StopTimer()
    {
        if (m_StartTimerCoroutine != null)
        {
            StopCoroutine(m_StartTimerCoroutine);
            m_StartTimerCoroutine = null;

            m_GameUI.SetTimerVisibility(false);
        }
    }

    public void DamagePlayer(int _DamageAmount)
    {
        m_PlayerHealth -= _DamageAmount;

        if (m_PlayerHealth <= 0)
        {
            Lose();
        }
    }

    public void DamageEnemy(int _DamageAmount)
    {
        m_EnemyHealth -= _DamageAmount;

        if (m_EnemyHealth <= 0)
        {
            Win();
        }
    }

    private void Win()
    {

    }

    private void Lose()
    {

    }

    public Bomb GetBomb()
    {
        return m_Bomb;
    }

    public bool GetCanUseItems()
    {
        return m_CanUseItems;
    }

    public MinigamesUI GetMinigamesUI()
    {
        return m_MinigamesUI;
    }

    public GameData GetGameData()
    {
        return m_GameData;
    }

    public static GameManager Get()
    {
        if(s_Instance == null)
        {
            s_Instance = FindObjectOfType<GameManager>();
        }

        return s_Instance;
    }
}