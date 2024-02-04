using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private Transform m_ItemSlot = null;

    private AttachableItem m_AttachedItem = null;

    private PlayerTurn m_Owner = PlayerTurn.Player1;

    private bool m_DoubleDamageActivated = false;

    private bool m_IsDiffused = false;


    public void SetOwner(PlayerTurn _Owner)
    {
        m_Owner = _Owner;
    }

    public void Explode()
    {
        if (m_IsDiffused)
        {
            return;
        }

        int damageAmount = m_DoubleDamageActivated ? 2 : 1;

        if (m_Owner == PlayerTurn.Player1)
        {
            GameManager.Get().DamagePlayer(damageAmount);
        }
        else
        {
            GameManager.Get().DamageEnemy(damageAmount);
        }
    }

    public void Diffuse()
    {
        m_IsDiffused = true;
        GameManager.Get().GetMinigamesUI().StopMinigame();
    }

    public void Activate()
    {
        m_IsDiffused = false;
        GameManager.Get().GetMinigamesUI().StartRandomMinigame();
    }

    public void AttachItem(AttachableItem _Item)
    {
        _Item.transform.SetParent(m_ItemSlot);

        _Item.transform.position = m_ItemSlot.position;
        _Item.transform.rotation = m_ItemSlot.rotation;
    }

    public void ActivateDoubleDamage()
    {
        m_DoubleDamageActivated = true;
    }
}