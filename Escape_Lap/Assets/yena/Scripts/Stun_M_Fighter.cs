using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_M_Fighter : Basic_Fighter
{
    [SerializeField] private Vector2 targetPosition = new Vector2(0f, 0f);
    [SerializeField] private bool moveScan = false;
    private Vector2 startPosition; // 시작 좌표
    private bool shouldMove = true; // 움직임 허용 여부를 나타내는 변수
    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    private GameObject Player;
    private PlayerMove playerMove;
    private float fadeDuration = 0.5f;
    [SerializeField] private AnimationCurve fadeCurve;
    private int repeatCount = 3;

    public override void Start()
    {
        //플레이어 찾기 안필요할지도
        Player = GameObject.FindWithTag("Player");
        if (Player != null)
        {
            playerMove = Player.GetComponent<PlayerMove>();
        }

        startPosition = transform.position;
        rd = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        Move();


    }

    public override void Update()
    {
        Delete();
        Die();
        if(moveScan == true)
        {
            if (playerMove.pos.x != 0 || playerMove.pos.y != 0 || playerMove.pos.z != 0)
                playerMove.isMove = false;
        }
    }

    public override void Die()
    {
        if (Hp <= 0)
        {
            ItemDrop();
            spriteRenderer1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            spriteRenderer2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Destroy(this.gameObject);

            //아이템
        }
    }


    // Update is called once per frame
    private void StunStart() 
    {
        GameObject background1 = GameObject.FindWithTag("BackGround");
        spriteRenderer1 = background1.GetComponent<SpriteRenderer>();

      
        GameObject background2 = GameObject.FindWithTag("BackGround2");
        spriteRenderer2 = background2.GetComponent<SpriteRenderer>();

        StartCoroutine(Warning());

    }
   
    private IEnumerator Warning()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            float elapsedTime = 0f;
            Color startColor = spriteRenderer1.color;
            Color targetColor = new Color(startColor.r, 0.5f, 0.5f, 1.0f);
            

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / fadeDuration;
                float curveValue = fadeCurve.Evaluate(t);

                Color currentColor = Color.Lerp(startColor, targetColor, curveValue);
                spriteRenderer1.color = currentColor;
                spriteRenderer2.color = currentColor;

                yield return null;
            }

            //yield return new WaitForSecondsRealtime(1.0f); // 1초 대기

            elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / fadeDuration;
                float curveValue = fadeCurve.Evaluate(t);

                Color currentColor = Color.Lerp(targetColor, startColor, curveValue);
                spriteRenderer1.color = currentColor;
                spriteRenderer2.color = currentColor;

                yield return null;
            }

            spriteRenderer1.color = startColor; // 원래 색상으로 설정
            spriteRenderer2.color = startColor; // 원래 색상으로 설정

            yield return new WaitForSecondsRealtime(0.5f);

        }

        moveScan = true;
        Debug.Log("시작");
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("끝");
        moveScan = false;
        yield return new WaitForSecondsRealtime(3f);
        playerMove.isMove = true;
        Destroy(this.gameObject);
       
    }

    public override void Move()
    {
        //rd.AddForce(Vector2.up * Speed);

        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (shouldMove)
        {
            // 현재 위치와 목표 위치의 거리를 계산
            float distance = Mathf.Abs(transform.position.y - targetPosition.y);

            // 거리가 일정 값 이하일 때 스탑
            if (distance <= 0.1f)
            {
                shouldMove = false; // 움직임 중지
                break;
            }

            transform.Translate(Vector2.up * Speed * Time.deltaTime);

            yield return null;
        }

        StunStart();
    }
}
