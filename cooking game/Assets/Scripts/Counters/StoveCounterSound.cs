using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    private float warningSoundTimer;
    private AudioSource audioSource;
    private bool playwarningSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgressAmount = .5f;
         playwarningSound = stoveCounter.IsFried() && e.ProgressNormalizd >= burnShowProgressAmount;

    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;

        if (playSound)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
    private void Update()
    {
        if (playwarningSound)
        {
            warningSoundTimer -= Time.deltaTime;
            if (warningSoundTimer <= 0)
            {
                float warningSoundTimerMax = .2f;
                warningSoundTimer = warningSoundTimerMax;
                SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);
            }
        }

    }
}
