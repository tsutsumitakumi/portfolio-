using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f;

    private Rigidbody2D rb;
    private float lastPositionX; // 前回のX座標
    private float timeSinceLastMove; // 前回の移動からの経過時間
    public float gameOverTimeThreshold = 1.5f; // ゲームオーバーにする時間の閾値

    // Startメソッドで初期化
    private void Start()
    {
        lastPositionX = transform.position.x;
        timeSinceLastMove = 0f;
    }

    // Awake(コンポーネントの取得)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate(移動用の関数)
    private void FixedUpdate()
    {
        MovePlayer();
        CheckForGameOver();
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void CheckForGameOver()
    {
        // 現在のX座標と前回のX座標が同じかどうかをチェック
        if (transform.position.x == lastPositionX)
        {
            // 同じ位置の場合、経過時間を増やす
            timeSinceLastMove += Time.fixedDeltaTime;
            // 一定時間経過した場合はゲームオーバーシーンに遷移する
            if (timeSinceLastMove >= gameOverTimeThreshold)
            {
                Debug.Log("Game Over: Player didn't move for too long.");
                // ゲームオーバーシーンに遷移する
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            // X座標が変わった場合、経過時間をリセット
            timeSinceLastMove = 0f;
            // 現在のX座標を更新
            lastPositionX = transform.position.x;
        }
    }
}
