using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    public float speed = 7f;// 스피드

    public float HP; //체력
    public float MaxHP = 200; //최대체력
    public float MinHP = 0; //체력이 0

    public float BasicAttack = 10f; //평타
    public float AttackPower;//스킬 공격력
    public float Defence;//방어력
    public float MagicResistence;//마법 저항

    //Passive 변수들
    float Passive_currentTimer = 0;
    float healTimer = 0;
    float lastHP;

    private void Awake()
    {
        HP = MaxHP;
    }
    // Update is called once per frame
    void Update()
    {

        PlayerMove();
        Passive();
        Skill_Q();
        Skill_W();
        Skill_E();
        Skill_R();
    }
    void PlayerMove()//플레이어 이동
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float xSpeed = x * speed;
        float zSpeed = z * speed;
        Vector3 vector = new Vector3(xSpeed, 0, zSpeed);
        transform.Translate(vector * Time.deltaTime);
    }

    void Passive()
    {
        int dontTakeDamageTime = 8; //8초
        int healingTime = 5; //5초 마다 회복

        if (lastHP == HP) //현재의 hp와 기존의 hp가 일치하지 않는다면, 피해를 입지않는다면
        {
            Debug.Log("피해 입지 않음");
            Passive_currentTimer += Time.deltaTime;

            if (Passive_currentTimer > dontTakeDamageTime)//8초 동안 데미지를 입지 않는다면
            {
                Debug.Log("8초동안 피해를 입지 않음");
                if (healTimer >= healingTime) //처음 한 번과 5초마다 한번씩 회복
                {
                    Debug.Log("회복 시작");
                    float HealHP = MaxHP * (2 / 100.0f); //최대 체력의 2%      
                    HP = Mathf.Min(HP + HealHP, MaxHP); //현재의 HP를 최대HP로 만듬
                    Debug.Log("현재 체력은 " + HP);
                    healTimer = 0;
                }
                healTimer += Time.deltaTime; //8초가 지난 후에 시간 갱신
            }
            lastHP = HP; //지난 프레임의 HP에 현재 HP를 저장
        }
        else //피해를 입는다면
        {
            Debug.Log("피해 발생 ! 타이머들 초기화");
            lastHP = HP; //바뀐 HP를 저장
            healTimer = 5;
            Passive_currentTimer = 0;
        }
    }
    void Skill_Q()
    {
        if (Input.GetKey(KeyCode.Q))
        {

        }
    }

    void Skill_W()
    {
        if (Input.GetKey(KeyCode.Q))
        {

        }
    }
    void Skill_E()
    {
        if (Input.GetKey(KeyCode.Q))
        {

        }
    }
    void Skill_R()
    {
        if (Input.GetKey(KeyCode.Q))
        {

        }
    }

}
