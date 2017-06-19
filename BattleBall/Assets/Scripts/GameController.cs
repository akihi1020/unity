using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public LifeController life;
    public BallController ballController;
    public Hole hole;

    // Update is called once per frame
    void Update()
    {
        // クリアして遷移
        if (hole.IsFallIn() == true) {
            Debug.Log("Clear");
            // これ以降のUpdateは止める
            enabled = false;

            // 2秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        } else if (life.getLifeCount() <= 0 && ballController.IsSleeping()) {
            Debug.Log("GemeOver");
            // これ以降のUpdateは止める
            enabled = false;

            // 2秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        }
    }

    void ReturnToTitle()
    {
        // タイトルシーンに遷移
        SceneManager.LoadScene("Title");
    }
}
