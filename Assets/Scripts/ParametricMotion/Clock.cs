using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    //public TextMeshProUGUI gameTime, dspTime, beat;
    private AudioSource audioSource;
    public AudioClip song;
    public float songDuration;

    public float TimeForFinishingSong = 2.8f;

    private bool hasSongFinished;

    public int BPM = 60;

    private float startingDSPTime;

    private bool running;

    public ProgressBar progressBar;
    public GameObject scoreSection;
    public GameObject readySection;

    public static Clock current;
    public event Action event_songHasFinished;
    bool hasEventBeenCalled = false;

    private void Awake()
    {
        current = this;
        audioSource = GetComponent<AudioSource>();
        scoreSection.gameObject.SetActive(false);

        //songDuration = song.length - TimeForFinishingSong;
        songDuration = song.length;

    }

    private IEnumerator Start()
    {
        //yield return new WaitUntil(() => progressBar.HasProgressBarFinished());
        yield return new WaitForSeconds(1f);
        scoreSection.gameObject.SetActive(true);
        readySection.gameObject.SetActive(false);

        //yield return new WaitForSeconds(1);

        running = true;

        startingDSPTime = (float)AudioSettings.dspTime;

        audioSource.clip = song;

        audioSource.Play();
    }

    private void Update()
    {
        float currentDSPTime = CurrentTime();
        if (!hasSongFinished && !hasEventBeenCalled)
        {
            HasSongFinished();
        }
        else if(hasSongFinished && !hasEventBeenCalled)
        {
            print("Song finished on clock!");
            event_songHasFinished.Invoke();
            hasEventBeenCalled = true;
        }
        
        //gameTime.text = $"Game: {currentTime:00.00}";
        //dspTime.text = $"DSP: {currentDSPTime:00.00}";
        //beat.text = $"Beat: {CurrentBeat()}";
    }

    public bool HasSongFinished()
    {
        return hasSongFinished = CurrentTime() < songDuration ? false : true;
    }

    /// <summary>
    /// Current time synced with audio.
    /// </summary>
    /// <returns></returns>
    public float CurrentTime()
    {
        if (!running)
            return 0;

        return (float)AudioSettings.dspTime - startingDSPTime;
    }

    public int CurrentBeat()
    {
        return Mathf.FloorToInt(CurrentTime() / (BPM / 60f)) + 1;
    }
}
