using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour
{
    public Hole hole;

    void OnGUI()
    {
        string label = " ";

        // ボールがホールに入ったらラベルを表示
        if (hole.IsFallIn()) {
            label = "Fall in hoke!";
        }
        GUI.Label(new Rect(0, 0, 100, 30), label);
    }
}
