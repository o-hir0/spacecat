using UnityEngine;

public class WallClimbing : MonoBehaviour
{

    public float rayDistance = 1.0f;      // レイキャストの距離
    public LayerMask wallLayer;          // 壁として扱うレイヤー
    public float climbSpeed = 5.0f;      // 壁を登る速度
    public float offsetY = -1.0f;

    private Rigidbody2D rbody;
    private bool isTouchingLeftWall = false; // 壁に接触しているか
    private bool isTouchingRightWall = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 左右の壁を判定するレイキャスト
        CheckWallContact();

        // 壁に接触している方向に応じた動作
        if (isTouchingRightWall && Input.GetKey(KeyCode.UpArrow))
        {
            ClimbWall(Vector2.right); // 右方向の壁を登る
        }
        else if (isTouchingLeftWall && Input.GetKey(KeyCode.UpArrow))
        {
            ClimbWall(Vector2.left); // 左方向の壁を登る
        }
        /*if(Input.GetKey(KeyCode.UpArrow) && ((isTouchingLeftWall == false) || (isTouchingRightWall == false)) && isgrounted == false)
        {
            rbody.linearVelocityY = finishClimbingforce;
        }*/
    }

    void CheckWallContact()
    {
        // 現在のプレイヤー位置
        Vector2 origin = (Vector2)transform.position + new Vector2(0, offsetY);

        // 右方向のレイキャスト
        RaycastHit2D hitRight = Physics2D.Raycast(origin, Vector2.right, rayDistance, wallLayer);
        isTouchingRightWall = hitRight.collider != null; // 右側の壁接触判定

        // 左方向のレイキャスト
        RaycastHit2D hitLeft = Physics2D.Raycast(origin, Vector2.left, rayDistance, wallLayer);
        isTouchingLeftWall = hitLeft.collider != null; // 左側の壁接触判定

        // デバッグ用にレイを表示
        Debug.DrawRay(origin, Vector2.right * rayDistance, Color.red);
        Debug.DrawRay(origin, Vector2.left * rayDistance, Color.blue);
    }

    void ClimbWall(Vector2 wallDirection)
    {
        // 壁を登る処理（例として上方向の速度を追加）
        rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, climbSpeed);
        Debug.Log("壁を登っています！方向: " + wallDirection);
    }

}
