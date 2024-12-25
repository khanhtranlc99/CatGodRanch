using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimalsHome : MonoBehaviour
{
    // Giới hạn di chuyển
    public Transform topLimit;
    public Transform bottomLimit;
    public Transform leftLimit;
    public Transform rightLimit;

    public float moveSpeed = 3f;       // Tốc độ di chuyển
    public float changeDirectionTime = 2f; // Thời gian để thay đổi hướng ngẫu nhiên

    private Vector3 direction;          // Hướng di chuyển
    private float timer;                // Bộ đếm thời gian
    private bool isMoving = true;       // Trạng thái di chuyển
    public GameObject icon;
    private bool isInit = false;
    public void Init(Transform topLimitParam, Transform bottomLimitParam , Transform leftLimitParam, Transform rightLimitParam)
    {
        topLimit = topLimitParam; 
        bottomLimit = bottomLimitParam;
        leftLimit = leftLimitParam;
        rightLimit = rightLimitParam;
        isInit = true;
        AnimScale();
        StartCoroutine(AutoPauseAndMove());
    }

    void Update()
    { 
        if(!isInit) 
        { 
            return;
        }
        if (isMoving)
        {
            // Di chuyển đối tượng theo hướng hiện tại
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Kiểm tra giới hạn và đảo hướng nếu chạm giới hạn
            CheckBounds();

            // Thay đổi hướng ngẫu nhiên sau mỗi khoảng thời gian
            timer += Time.deltaTime;
            if (timer >= changeDirectionTime)
            {
                SetRandomDirection();
                timer = 0f;
            }

            // Cập nhật hướng quay mặt
            FlipToDirection();
        }
    }

    void SetRandomDirection()
    {
        // Tạo hướng ngẫu nhiên
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }

    void CheckBounds()
    {
        // Kiểm tra giới hạn trái-phải
        if (transform.position.x <= leftLimit.position.x || transform.position.x >= rightLimit.position.x)
        {
            direction.x = -direction.x; // Đảo hướng x
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftLimit.position.x, rightLimit.position.x),
                transform.position.y,
                transform.position.z
            );
        }

        // Kiểm tra giới hạn trên-dưới
        if (transform.position.y <= bottomLimit.position.y || transform.position.y >= topLimit.position.y)
        {
            direction.y = -direction.y; // Đảo hướng y
            transform.position = new Vector3(
                transform.position.x,
                Mathf.Clamp(transform.position.y, bottomLimit.position.y, topLimit.position.y),
                transform.position.z
            );
        }
    }

    void FlipToDirection()
    {
        // Quay mặt theo hướng di chuyển
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
    }

    IEnumerator AutoPauseAndMove()
    {
        while (true)
        {
            // Chọn ngẫu nhiên thời gian dừng
            float pauseTime = Random.Range(1, 5);

            // Dừng di chuyển
            isMoving = false;
            AnimScale();
            yield return new WaitForSeconds(pauseTime);

            // Bắt đầu di chuyển
            isMoving = true;
            AnimRotateInMove();
            // Đợi thêm trước khi tiếp tục kiểm tra
            yield return new WaitForSeconds(changeDirectionTime);
        }
    }
    public void AnimScale()
    {
        icon.transform.DOKill();
        icon.transform.localEulerAngles = Vector3.zero;
        var ranScaleOut = Random.RandomRange(0.3f, 0.35f);
        var ranScaleIn = Random.RandomRange(0.3f, 0.35f);
        icon.transform.DOScale(new Vector3(1.1f, 1, 1), ranScaleOut).OnComplete(delegate
        {
            icon.transform.DOScale(new Vector3(1, 1, 1), ranScaleIn).OnComplete(delegate
            {
                AnimScale();
            });
        });
    }
    public void AnimRotateInMove()
    {
        icon.transform.DOKill();
        icon.transform.DOLocalRotate(new Vector3(0, 0, 10f), 0.1f).OnComplete(delegate
        {
            icon.transform.DOLocalRotate(new Vector3(0, 0, -10f), 0.1f).OnComplete(delegate
            {
                AnimRotateInMove();
            });
        });
    }
}
