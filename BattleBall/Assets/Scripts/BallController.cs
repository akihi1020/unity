using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    const int PowerMax = 100;

    public Rigidbody _rigidbody;
    public LifeController life;
    public EnemyController enemy;
    public Hole hole;
    public Slider slider;

    bool onLeft = false;
    bool onRight = false;
    bool onShot = false;

    float dgr = 0;
    int power = 0;

    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        // デバッグ用
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            OnLeftDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            OnLeftUp();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            OnRightDown();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            OnRightUp();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            OnShotDown();
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            OnShotUp();
        }

        // スペースキー操作
        if (life.getLifeCount() > 0 && onShot) {
            if (power < PowerMax) {
                power++;
                slider.value = (float)power / 100;
            }
        }
        if (life.getLifeCount() > 0 && !onShot && power > 0) {
            Vector3 v = Camera.main.transform.position;
            v -= position;
            v *= power * -2.5f;
            v.y = 0;
            transform.GetComponent<Rigidbody>().AddForce(v);
            power = 0;
            life.decreaseLife();
        }

        // 矢印キー操作
        if (onLeft) {
            Camera.main.transform.RotateAround(position, new Vector3(0, 10, 0), -1f);
            dgr += 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || onRight) {
            Camera.main.transform.RotateAround(position, new Vector3(0, 10, 0), 1f);
            dgr -= 1f;
        }

        // カメラの新たな位置の計算と設定
        float d = (2 * Mathf.PI) * (dgr / 360);
        float x = Mathf.Sin(d);
        float y = Mathf.Cos(d);
        x *= 5f;
        y *= 5f;
        position.x += x;
        position.y += 5f;
        position.z -= y;
        Camera.main.transform.position = position;
    }

    public void OnLeftDown()
    {
        onLeft = true;
    }

    public void OnLeftUp()
    {
        onLeft = false;
    }

    public void OnRightDown()
    {
        onRight = true;
    }

    public void OnRightUp()
    {
        onRight = false;
    }

    public void OnShotDown()
    {
        onShot = true;
    }

    public void OnShotUp()
    {
        onShot = false;
    }

    public bool IsSleeping()
    {
        return _rigidbody.IsSleeping();
    }

    void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.gameObject.CompareTag("Enemy")) {
            // 敵の残り数を減らす
            enemy.decreaseEnemyCount();

            // ヒットしたオブジェクトは削除
            Destroy(otherObj.gameObject);

            // todo:残り1体になったら、最後の敵の場所をゴールにする
            if (enemy.getEnemyCount() == 0 && !hole.isActive()) {
                Vector3 position = otherObj.transform.position;
                hole.setActive(position);
            }
        }
    }
}
