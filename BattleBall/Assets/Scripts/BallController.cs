using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public LifeController life;

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

        // スペースキー操作
        if (life.getLifeCount() > 0 && Input.GetKeyDown(KeyCode.Space)) {
            power = 0;
        }
        if (life.getLifeCount() > 0 && Input.GetKey(KeyCode.Space)) {
            power++;
        }
        if (life.getLifeCount() > 0 && Input.GetKeyUp(KeyCode.Space)) {
            Vector3 v = Camera.main.transform.position;
            v -= position;
            v *= power * -2.5f;
            v.y = 0;
            transform.GetComponent<Rigidbody>().AddForce(v);
            life.decreaseLife();
        }

        // 矢印キー操作
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Camera.main.transform.RotateAround(position, new Vector3(0, 10, 0), -0.5f);
            dgr += 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Camera.main.transform.RotateAround(position, new Vector3(0, 10, 0), 0.5f);
            dgr -= 0.5f;
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

    public bool IsSleeping()
    {
        return _rigidbody.IsSleeping();
    }
}
