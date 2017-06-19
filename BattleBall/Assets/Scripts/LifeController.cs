using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController: MonoBehaviour
{
    const int MaxLifeCount = 3;

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

    void OnGUI()
    {
        // 残りショット数を+の数で表示
        string label = "";
        for (int i = 0; i < lifeCount; i++) {
            label = label + "+";
        }

        GUI.Label(new Rect(0, 15, 100, 30), label);
    }
}
