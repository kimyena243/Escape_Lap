using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_M_Fighter : Basic_Fighter
{
    [SerializeField] private Vector2 targetPosition = new Vector2(0f, 0f);
    [SerializeField] private bool moveScan = false;
    private Vector2 startPosition; // ���� ��ǥ
    private bool shouldMove = true; // ������ ��� ���θ� ��Ÿ���� ����
    private SpriteRenderer spriteRenderer1;
    private SpriteRenderer spriteRenderer2;
    private GameObject Player;
    private PlayerMove playerMove;
    private float fadeDuration = 0.5f;
    [SerializeField] private AnimationCurve fadeCurve;
    private int repeatCount = 3;

    public override void Start()
    {
        //�÷��̾� ã�� ���ʿ�������
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

            //������
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

            //yield return new WaitForSecondsRealtime(1.0f); // 1�� ���

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

            spriteRenderer1.color = startColor; // ���� �������� ����
            spriteRenderer2.color = startColor; // ���� �������� ����

            yield return new WaitForSecondsRealtime(0.5f);

        }

        moveScan = true;
        Debug.Log("����");
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("��");
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
