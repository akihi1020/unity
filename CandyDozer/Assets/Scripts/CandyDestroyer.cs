using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyHolder candyHolder;
    public int reward;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy") {
            // 指定数だけCandyのストックを増やす
            candyHolder.AddCandy(reward);

            // オブジェクトを削除
            Destroy(other.gameObject);
        }
    }
}
