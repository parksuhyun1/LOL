using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngineInternal;

public class PlayerControllor : MonoBehaviour
{
    public float speed = 7f;// 스피드

    public float HP; //체력
    public float MaxHP = 2000; //최대체력
    public float MinHP = 0; //체력이 0

    public float BasicAttack = 10f; //평타
    public float AttackPower;//스킬 공격력
    public float Defence;//방어력
    public float MagicResistence;//마법 저항

    //PlayerMove 변수
    Vector3 destination;

    //Passive 변수
    float Passive_currentTimer = 0;
    float healTimer = 0;
    float lastHP;

    //Q 변수
    bool Q_CoolTime = false;
    float Q_CoolTimer = 0;
    float SpeedTimer = 0;
    float SilenceTimer = 0;

    private void Awake()
    {
        HP = MaxHP;
        destination = new Vector3();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Passive();
        Skill_BasicAttack();
        Skill_Q();
        Skill_W();
        Skill_E();
        Skill_R();
    }

    private void FixedUpdate()
    {
        Ray_Raycast();
    }
    void PlayerMove()//플레이어 이동
    {
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        //float xSpeed = x * speed;
        //float zSpeed = z * speed;
        //Vector3 vector = new Vector3(xSpeed, 0, zSpeed);
        //transform.Translate(vector * Time.deltaTime);
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//마우스의 픽셀값을 ray에 저장
            RaycastHit hit = new RaycastHit(); //광선을 월드에 쏨
            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
            }
        }
    }

    void Ray_Raycast()
    {
      
         if((transform.position - destination).magnitude > 0.1)
            //transform.position - destination을 하면 결과 값이 vector로 나오기 때문에
            //.magnitude를 하면 숫자의 길이를 가져오기때문에 0,1과 비교를 할 수 있음
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            //Vector3.MoveTowards(자기위치, 가야할 위치, 일정한 속도)
        }
    }
    void Passive()
    {
        int dontTakeDamageTime = 8; //8초
        int healingTime = 5; //5초 마다 회복

        if (lastHP == HP) //현재의 hp와 기존의 hp가 일치하지 않는다면, 피해를 입지 않는다면
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
    void Skill_BasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
    bool Q_Active1 = false;// 스킬 지속
    bool Q_Active2 = false;
    void Skill_Q()
    {
        if (Input.GetKey(KeyCode.Q) && Q_CoolTime == false)//Q가 눌렸고 Q_CoolTime이 false라면
        {
            Debug.Log("Q 스킬 사용");
            Q_CoolTime = true; //Q_Cooltime을 true로 변환시켜 다시 false가 되지 않으면 Q를 사용하지 못하게 만듬
            Q_Active1 = true;
            Q_Active2 = true;
            Q_CoolTimer += Time.deltaTime;
            SpeedTimer = 0;
        }

        if (Q_Active1) //스피드 스킬 지속시간 체크 
        {
            Debug.Log("이동속도 증가");
            speed *= 1.3f;
            SpeedTimer += Time.deltaTime;
            if(SpeedTimer >= 2.3f) 
            {
                Debug.Log("이동속도증가 시간 종료");
                speed = 7f;
            }
        }
        if (Q_Active2) // 침묵 스킬 지속 시간 체크
        {
            Debug.Log("평타 강화(침묵)지속");
            SilenceTimer += Time.deltaTime;
            if (SilenceTimer >= 1.5f)
            {
                Debug.Log("평타 강화(침묵)지속 시간 종료");
                //if(기본 공격을 하게되면 )
                //침묵, 226의 물리피해를 입힌다.
            }
        }

        if (Q_CoolTime) //쿨타임 시간 체크
        {
            Q_CoolTimer += Time.deltaTime;
            if (Q_CoolTimer >= 8f)
            {
                Debug.Log("Q 쿨타임 초기화");
                Q_CoolTime = false;
                Q_CoolTimer = 0;
            }
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
