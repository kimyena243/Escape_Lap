using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunCircle : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    private float fadeDuration = 1.0f;
    [SerializeField] private AnimationCurve fadeCurve;
    private int repeatCount = 3;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        StartCoroutine(FadeInOut());
       
        
    }

    private IEnumerator FadeInOut()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            float elapsedTime = 0f;
            Color startColor = spriteRenderer.color;
            Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0.4f);

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / fadeDuration;
                float curveValue = fadeCurve.Evaluate(t);

                Color currentColor = Color.Lerp(startColor, targetColor, curveValue);
                spriteRenderer.color = currentColor;

                yield return null;
            }

            spriteRenderer.color = targetColor;

            //yield return new WaitForSecondsRealtime(1.0f); // 1�� ���

            elapsedTime = 0f;
            startColor = spriteRenderer.color;
            targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / fadeDuration;
                float curveValue = fadeCurve.Evaluate(t);

                Color currentColor = Color.Lerp(startColor, targetColor, curveValue);
                spriteRenderer.color = currentColor;

                yield return null;
            }

            spriteRenderer.color = targetColor;

            yield return new WaitForSecondsRealtime(1.0f); // 1�� ���
            
        }

        circleCollider.enabled = true; //�ݶ��̴� Ȱ��ȭ
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("�浹");

            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            if (playerScript != null)
            {
                playerScript.isMove = false; // ������ false

                StartCoroutine(Delete(playerScript));
            }


        }
    }
    private IEnumerator Delete(PlayerScript playerScript)
    {
        yield return new WaitForSeconds(2.0f);
        playerScript.isMove = true;
        Destroy(this.gameObject);
    }

}