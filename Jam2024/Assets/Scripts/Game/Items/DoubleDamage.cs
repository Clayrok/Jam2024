using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : AttachableItem
{
    protected override void ActivateEffect()
    {
        GameManager.Get().GetBomb().ActivateDoubleDamage();
    }
}