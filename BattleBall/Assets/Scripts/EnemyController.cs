using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyCount;
    public Hole hole;

    public int getEnemyCount()
    {
        return enemyCount;
    }

    public void decreaseEnemyCount()
    {
        enemyCount--;
    }

    void OnGUI()
    {
        // 残り敵数を●の数で表示
        string label = "";
        for (int i = 0; i < enemyCount; i++) {
            label = label + "●";
        }

        GUI.Label(new Rect(0, 30, 100, 60), label);
    }
}
