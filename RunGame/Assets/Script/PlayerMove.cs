using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f;

    private Rigidbody2D rb;
    private float lastPositionX; // �O���X���W
    private float timeSinceLastMove; // �O��̈ړ�����̌o�ߎ���
    public float gameOverTimeThreshold = 1.5f; // �Q�[���I�[�o�[�ɂ��鎞�Ԃ�臒l

    // Start���\�b�h�ŏ�����
    private void Start()
    {
        lastPositionX = transform.position.x;
        timeSinceLastMove = 0f;
    }

    // Awake(�R���|�[�l���g�̎擾)
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate(�ړ��p�̊֐�)
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
        // ���݂�X���W�ƑO���X���W���������ǂ������`�F�b�N
        if (transform.position.x == lastPositionX)
        {
            // �����ʒu�̏ꍇ�A�o�ߎ��Ԃ𑝂₷
            timeSinceLastMove += Time.fixedDeltaTime;
            // ��莞�Ԍo�߂����ꍇ�̓Q�[���I�[�o�[�V�[���ɑJ�ڂ���
            if (timeSinceLastMove >= gameOverTimeThreshold)
            {
                Debug.Log("Game Over: Player didn't move for too long.");
                // �Q�[���I�[�o�[�V�[���ɑJ�ڂ���
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            // X���W���ς�����ꍇ�A�o�ߎ��Ԃ����Z�b�g
            timeSinceLastMove = 0f;
            // ���݂�X���W���X�V
            lastPositionX = transform.position.x;
        }
    }
}
