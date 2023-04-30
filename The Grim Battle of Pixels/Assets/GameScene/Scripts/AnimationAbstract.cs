using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationAbstract: MonoBehaviour
{
    public abstract float getTime();

    public abstract bool getFlagAbility();

    public abstract void SetTimeBusterCoefficient(float newCoef, int time);

    public abstract void SetStan(bool flag);
}
