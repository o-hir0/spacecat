using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class DropFloor : MonoBehaviour
{
    public float fallDelay = 1.0f; // ����������܂ł̎���
    public float respawnTime = 3.0f; // ������������܂ł̎���

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private GameObject platform;

    void Start()
    {
        // �����ʒu�Ɖ�]���L�^
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        platform = this.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �v���C���[���������
        {
            StartCoroutine(FallAndRespawn());
        }
    }

    IEnumerator FallAndRespawn()
    {
        yield return new WaitForSeconds(fallDelay);

        // ���𗎂Ƃ��iRigidbody2D ���g���ĕ����I�ɗ��Ƃ��j
        Rigidbody2D rb = platform.GetComponent<Rigidbody2D>();
     
        if (rb == null)
            rb = platform.AddComponent<Rigidbody2D>();

        rb.gravityScale = 2; // �d�͂�L���ɂ���
        rb.constraints = RigidbodyConstraints2D.None; // �Œ������

        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Z���̉�]���Œ�
        yield return new WaitForSeconds(respawnTime);

        // �������̈ʒu�ɕ���������
        Destroy(rb); // Rigidbody2D ���폜�i�d�͂𖳌��ɂ���j
        platform.transform.position = initialPosition;
        platform.transform.rotation = initialRotation;
    }
}
