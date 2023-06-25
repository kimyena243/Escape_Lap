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
    [SerializeField] private AudioClip stunAudio;
    [SerializeField] private AudioClip alarmAudio;
    
    private AudioSource audioPlay;
    private void Start()
    {
        audioPlay = GetComponent<AudioSource>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        StartCoroutine(FadeInOut());
       
        
    }

    private IEnumerator FadeInOut()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            audioPlay.clip = alarmAudio;
            audioPlay.Play();
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

            //yield return new WaitForSecondsRealtime(1.0f); // 1초 대기

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

            yield return new WaitForSecondsRealtime(1.0f); // 1초 대기
            
        }
        
        circleCollider.enabled = true; //콜라이더 활성화
        audioPlay.clip = stunAudio;
        audioPlay.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
           
            
            PlayerMove playerMove = collision.gameObject.GetComponent<PlayerMove>();
            if (playerMove != null)
            {
                playerMove.isMove = false; // 움직임 false

                StartCoroutine(Delete(playerMove));
            }


        }
    }
    private IEnumerator Delete(PlayerMove playerMove)
    {
        yield return new WaitForSeconds(2.0f);
        playerMove.isMove = true;
        Destroy(this.gameObject);
    }

}