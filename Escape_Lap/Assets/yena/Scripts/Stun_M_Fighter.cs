using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_M_Fighter : Basic_Fighter
{
    [SerializeField] private Vector2 targetPosition = new Vector2(0f, 0f);
    [SerializeField] private GameObject StunFull;
    private Vector2 startPosition; // 시작 좌표
    private bool shouldMove = true; // 움직임 허용 여부를 나타내는 변수
    private SpriteRenderer spriteRenderer;
   
    private float fadeDuration = 0.5f;
    [SerializeField] private AnimationCurve fadeCurve;
    private int repeatCount = 3;

    public override void Start()
    {
        ////플레이어 찾기 안필요할지도
        //GameObject Player = GameObject.FindWithTag("Player");
        //if(Player!=null)
        //{
        //    PlayerScript playerScript = Player.GetComponent<PlayerScript>();
        //}

        startPosition = transform.position;
        rd = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        Move();


    }

    // Update is called once per frame
    private void StunStart() // 기본 공격 
    {
        GameObject BackGround = GameObject.FindWithTag("BackGround");
        spriteRenderer = BackGround.GetComponent<SpriteRenderer>();
        

        StartCoroutine(Stun());

    }

    private IEnumerator Stun()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            float elapsedTime = 0f;
            Color startColor = spriteRenderer.color;
            Color targetColor = new Color(startColor.r, 0.5f, 0.5f, 1.0f);

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / fadeDuration;
                float curveValue = fadeCurve.Evaluate(t);

                Color currentColor = Color.Lerp(startColor, targetColor, curveValue);
                spriteRenderer.color = currentColor;

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
                spriteRenderer.color = currentColor;

                yield return null;
            }

            spriteRenderer.color = startColor; // 원래 색상으로 설정

            yield return new WaitForSecondsRealtime(0.5f); // 1초 대기
        }

        Instantiate(StunFull, transform.position, Quaternion.identity);
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
