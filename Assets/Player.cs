using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float JumpVelocity = 10;  // ジャンプ力

    Rigidbody2D rb2d;

    SpriteRenderer sr;
    Animator animator;

    [SerializeField]
    private Sprite sp;

    [SerializeField]
    float interval = 1f;

    bool isActive = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //TouchManager.Began += (info) =>
        //{
        //    rb2d.velocity = Vector2.zero; // 落下速度リセットする
        //    rb2d.AddForce(transform.up * JumpVelocity, ForceMode2D.Impulse);    // 上方向に力を加える
        //};
    }

    void Update()
    {
        //マウスの左ボタンを押したら
        if(Input.GetMouseButtonDown(0) && !isActive)
        {
            rb2d.velocity = Vector2.zero; // 落下速度リセットする
            rb2d.AddForce(transform.up * JumpVelocity, ForceMode2D.Impulse);    // 上方向に力を加える
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        //コルーチンがアクティブかどうか・壁に当たったかどうか
        if (!isActive && collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");
            StartCoroutine(HitWall());

        }
    }

    IEnumerator HitWall()
    {
        isActive = true;
        animator.enabled = false;
        sr.sprite = sp;
        yield return new WaitForSeconds(interval);

        animator.enabled = true;
        isActive = false;

    }

}
