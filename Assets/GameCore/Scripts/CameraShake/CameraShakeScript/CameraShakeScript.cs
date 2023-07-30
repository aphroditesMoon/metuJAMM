using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Cinemachine;

public class CameraShakeScript : MonoBehaviour
{
    public static CameraShakeScript instance { get; private set; }
    
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeIntensity = 1f;
    private float shakeDuration = 0.1f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cBMCP;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StopShake();
    }

    public void CameraShake()
    {
        CinemachineBasicMultiChannelPerlin _cBMCP =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cBMCP.m_AmplitudeGain = shakeIntensity;

        //timer = shakeDuration;
    }

    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cBMCP =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cBMCP.m_AmplitudeGain = 0f;

        //timer = 0f;
    }

    public async void StartShake(int timer)
    {
        CameraShake();
        await Task.Delay(timer);
        StopShake();
    }
}
