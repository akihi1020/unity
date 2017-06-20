using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController: MonoBehaviour
{
    const int MaxLifeCount = 4;

    int lifeCount = MaxLifeCount;

    public int getLifeCount()
    {
        return lifeCount;
    }

    public void decreaseLife()
    {
        lifeCount--;
    }

    public void increaseLife()
    {
        lifeCount--;
    }
}
