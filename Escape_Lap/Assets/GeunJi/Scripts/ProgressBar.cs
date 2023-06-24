using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressbar;
    public Image background;
    public Sprite pauseMode;
    public Sprite playMode;
    public float max;

    void Start()
    {
        
    }

    void Update()
    {
        progressbar.maxValue = max;
        if(progressbar.value > 0)
            progressbar.value = GameManager.HP;

        if (GameManager.Playing)
            background.sprite = playMode;
        else
            background.sprite = pauseMode;
    }
}
