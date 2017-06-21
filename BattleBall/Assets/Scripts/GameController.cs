using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public LifeController life;
    public BallController ballController;
    public Hole hole;
    public LifePanel lifePanel;
    public GameObject guide;
    public GameObject gameClear;
    public GameObject gameOver;

    void Start()
    {
        gameClear.SetActive(false);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ライフパネルを更新
        lifePanel.UpdateLife(life.getLifeCount());

        // クリアして遷移
        if (hole.IsFallIn() == true) {
            guide.SetActive(false);
            gameClear.SetActive(true);
            // これ以降のUpdateは止める
            enabled = false;

            // 2秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        } else if (life.getLifeCount() <= 0 && ballController.IsSleeping()) {
            guide.SetActive(false);
            gameOver.SetActive(true);
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
