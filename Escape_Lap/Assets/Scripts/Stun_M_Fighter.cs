using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_M_Fighter : Basic_Fighter
{
    [SerializeField] private Vector2 targetPosition = new Vector2(0f, 0f);
    [SerializeField] private GameObject StunFull;
    private Vector2 startPosition; // ���� ��ǥ
    private bool shouldMove = true; // ������ ��� ���θ� ��Ÿ���� ����
    private SpriteRenderer spriteRenderer;
   
    private float fadeDuration = 0.5f;
    [SerializeField] private AnimationCurve fadeCurve;
    private int repeatCount = 3;

    public override void Start()
    {
        ////�÷��̾� ã�� ���ʿ�������
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
    private void StunStart() // �⺻ ���� 
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

            //yield return new WaitForSecondsRealtime(1.0f); // 1�� ���

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

            spriteRenderer.color = startColor; // ���� �������� ����

            yield return new WaitForSecondsRealtime(0.5f); // 1�� ���
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
            // ���� ��ġ�� ��ǥ ��ġ�� �Ÿ��� ���
            float distance = Mathf.Abs(transform.position.y - targetPosition.y);

            // �Ÿ��� ���� �� ������ �� ��ž
            if (distance <= 0.1f)
            {
                shouldMove = false; // ������ ����
                break;
            }

            transform.Translate(Vector2.up * Speed * Time.deltaTime);

            yield return null;
        }

        StunStart();
    }
}
