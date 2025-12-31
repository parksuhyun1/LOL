using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    public float speed = 7f;// 스피드
    
    // Update is called once per frame
    void Update()
    {
        PlayerMove();

    }
    void PlayerMove()//플레이어 이동
    {
        float x = Input.GetAxis("Horixontal");
        float y = Input.GetAxis("Vertical");
        float xSpeed = x * speed;
        float ySpeed = y * speed;
        Vector3 vector = new Vector3(xSpeed, ySpeed, 0);
        transform.Translate(vector * Time.deltaTime);
    }
}
