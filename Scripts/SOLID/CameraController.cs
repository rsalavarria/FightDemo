using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    CinemachineFreeLook vcam;

    void Start()
    {
        vcam = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        if (InputManager.instance.GetCameraInput())
        {
            vcam.m_XAxis.m_InputAxisName = "Mouse X";
            vcam.m_YAxis.m_InputAxisName = "Mouse Y";
        }
        else
        {
            vcam.m_XAxis.m_InputAxisName = "";
            vcam.m_YAxis.m_InputAxisName = "";
        }

    }
}
