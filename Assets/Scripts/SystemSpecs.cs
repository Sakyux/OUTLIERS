using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSpecs : MonoBehaviour {

    void Start() {

        public static string deviceModel = SystemInfo.deviceModel;
        public static string deviceName = SystemInfo.deviceName;
        public static string deviceVersion = SystemInfo.graphicsDeviceVersion;

        public string DeviceTest()
        {
            string SystemInfo;
            SystemInfo = deviceModel + "\n" + deviceName + "\n" + deviceVersion;
            return SystemInfo;
        }
    }
}
