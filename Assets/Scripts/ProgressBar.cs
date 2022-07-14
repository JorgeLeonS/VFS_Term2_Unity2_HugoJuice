using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Adapted script from:
/// https://www.youtube.com/watch?v=UCAo-uyb94c
/// </summary>
public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private ParticleSystem particles;
    public float fillSpeed = 0.5f;
    private float targetProgress = 0;

    private bool isIncrementing;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        particles = GameObject.Find("Particles").GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgressBar(1f);
        DecrementProgressBar(0f);
    }

    // Update is called once per frame
    void Update()
    {
        HasProgressBarFinished();
    }

    public bool HasProgressBarFinished()
    {
        if (isIncrementing)
        {
            if (slider.value < targetProgress)
            {
                slider.value += fillSpeed * Time.deltaTime;
                if (!particles.isPlaying)
                {
                    particles.Play();
                }
                return false;
            }
            else
            {
                particles.Stop();
                return true;
            }
        }
        else
        {
            if (slider.value > targetProgress)
            {
                slider.value -= fillSpeed * Time.deltaTime;
                if (!particles.isPlaying)
                {
                    particles.Play();
                }
                return false;
            }
            else
            {
                particles.Stop();
                return true;
            }
        }
    }

    public void IncrementProgressBar(float newnewValue)
    {
        targetProgress = slider.value + newnewValue;
        isIncrementing = true;
    }
    public void DecrementProgressBar(float newValue)
    {
        targetProgress = newValue;
        isIncrementing = false;
    }
}
