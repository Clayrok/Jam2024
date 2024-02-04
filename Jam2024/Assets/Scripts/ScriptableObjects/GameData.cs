using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField]
    private int m_PlayerHealth = 3;

    [SerializeField]
    private int m_Enemy1Health = 4;


    public int GetPlayerHealth()
    {
        return m_PlayerHealth;
    }

    public int GetEnemy1Health()
    {
        return m_Enemy1Health;
    }
}