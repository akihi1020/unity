using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    bool fallIn;

    // ボールのTagを指定
    public string activeTag;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // ボールが入っているかを返す
    public bool IsFallIn()
    {
        return fallIn;
    }

    void OnTriggerStay(Collider other)
    {
        // コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかを計算
        Vector3 direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        // 指定のタグが近寄った場合力を加える
        if (other.gameObject.tag == activeTag) {
            // 中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.98f;
            r.AddForce(direction * r.mass * 8.0f);
            if (r.velocity.magnitude < 0.05f) {
                fallIn = true;
            }
        }
    }

    public void setActive(Vector3 position)
    {
        gameObject.transform.position = position;
        gameObject.SetActive(true);
    }

    public bool isActive()
    {
        return gameObject.activeSelf;
    }
}
