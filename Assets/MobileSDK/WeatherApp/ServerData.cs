using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;

[Serializable]
public class ServerData
{
    public string latitude;
    public string longitude;
    public dailyInfo daily;

    [Serializable]
    public class dailyInfo
    {
        public List<float> temperature_2m_max;
    }
}
