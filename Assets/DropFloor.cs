using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class DropFloor : MonoBehaviour
{
    public float fallDelay = 1.0f; // 床が落ちるまでの時間
    public float respawnTime = 3.0f; // 床が復活するまでの時間

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private GameObject platform;

    void Start()
    {
        // 初期位置と回転を記録
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        platform = this.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // プレイヤーが乗ったら
        {
            StartCoroutine(FallAndRespawn());
        }
    }

    IEnumerator FallAndRespawn()
    {
        yield return new WaitForSeconds(fallDelay);

        // 床を落とす（Rigidbody2D を使って物理的に落とす）
        Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
     
        if (rb == null)
            rb = platform.AddComponent<Rigidbody2D>();

        rb.gravityScale = 2; // 重力を有効にする
        rb.constraints = RigidbodyConstraints2D.None; // 固定を解除

        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Z軸の回転を固定
        yield return new WaitForSeconds(respawnTime);

        // 床を元の位置に復活させる
        Destroy(rb); // Rigidbody2D を削除（重力を無効にする）
        platform.transform.position = initialPosition;
        platform.transform.rotation = initialRotation;
    }
}
