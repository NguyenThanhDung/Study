using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    private bool _micConnected;
    private int _minFreq;
    private int _maxFreq;
    
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            _micConnected = true;
            Microphone.GetDeviceCaps(null, out _minFreq, out _maxFreq);
            if (_minFreq == 0 && _maxFreq == 0)
            {
                _maxFreq = 44100;
            }
        }
        else
        {
            Debug.LogWarning("Microphone not connected!");
            _micConnected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRecordButtonClicked()
    {
        if(_micConnected)
        {
            Debug.Log("Recording...");
            audioSource.clip = Microphone.Start(null, true, 20, _maxFreq);
        }
        else
        {
            Debug.LogWarning("Microphone not connected!");
        }
    }

    public void OnStopAndPlayButtonClicked()
    {        
        if(_micConnected)
        {
            Debug.Log("Stop and play");
            Microphone.End(null);
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Microphone not connected!");
        }
    }
}
