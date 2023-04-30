using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleAbstract : MonoBehaviour
{
    public abstract void SetDamageCoefficient(int newDamage, int time);

    public abstract void returnDamageCoefficient();
}
