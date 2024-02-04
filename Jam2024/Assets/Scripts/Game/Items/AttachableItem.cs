using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttachableItem : Item
{
    protected override void Use()
    {
        GameManager.Get().GetBomb().AttachItem(this);
    }

    protected abstract void ActivateEffect();
}