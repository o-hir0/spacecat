using UnityEngine;

public class WallClimbing : MonoBehaviour
{

    public float rayDistance = 1.0f;      // ���C�L���X�g�̋���
    public LayerMask wallLayer;          // �ǂƂ��Ĉ������C���[
    public float climbSpeed = 5.0f;      // �ǂ�o�鑬�x
    public float offsetY = -1.0f;

    private Rigidbody2D rbody;
    private bool isTouchingLeftWall = false; // �ǂɐڐG���Ă��邩
    private bool isTouchingRightWall = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���E�̕ǂ𔻒肷�郌�C�L���X�g
        CheckWallContact();

        // �ǂɐڐG���Ă�������ɉ���������
        if (isTouchingRightWall && Input.GetKey(KeyCode.UpArrow))
        {
            ClimbWall(Vector2.right); // �E�����̕ǂ�o��
        }
        else if (isTouchingLeftWall && Input.GetKey(KeyCode.UpArrow))
        {
            ClimbWall(Vector2.left); // �������̕ǂ�o��
        }
        /*if(Input.GetKey(KeyCode.UpArrow) && ((isTouchingLeftWall == false) || (isTouchingRightWall == false)) && isgrounted == false)
        {
            rbody.linearVelocityY = finishClimbingforce;
        }*/
    }

    void CheckWallContact()
    {
        // ���݂̃v���C���[�ʒu
        Vector2 origin = (Vector2)transform.position + new Vector2(0, offsetY);

        // �E�����̃��C�L���X�g
        RaycastHit2D hitRight = Physics2D.Raycast(origin, Vector2.right, rayDistance, wallLayer);
        isTouchingRightWall = hitRight.collider != null; // �E���̕ǐڐG����

        // �������̃��C�L���X�g
        RaycastHit2D hitLeft = Physics2D.Raycast(origin, Vector2.left, rayDistance, wallLayer);
        isTouchingLeftWall = hitLeft.collider != null; // �����̕ǐڐG����

        // �f�o�b�O�p�Ƀ��C��\��
        Debug.DrawRay(origin, Vector2.right * rayDistance, Color.red);
        Debug.DrawRay(origin, Vector2.left * rayDistance, Color.blue);
    }

    void ClimbWall(Vector2 wallDirection)
    {
        // �ǂ�o�鏈���i��Ƃ��ď�����̑��x��ǉ��j
        rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, climbSpeed);
        Debug.Log("�ǂ�o���Ă��܂��I����: " + wallDirection);
    }

}
