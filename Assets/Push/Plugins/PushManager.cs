using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushManager : MonoBehaviour {
    public Text deviceTokenText;

    /// <summary>
    /// 统一暴露给用户的接口
    /// </summary>
    public static void RequestAuthorization() {
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            IOSWrapper.RequestAuthorization();
        } else if (Application.platform == RuntimePlatform.Android) {
            AndroidWrapper.RequestAuthorization();
        }
    }

    /// <summary>
    /// 统一回调，由 Android/iOS 通知到 Unity
    /// </summary>
    /// <param name="deviceToken"></param>
    public void OnRegisteredDeviceToken(string deviceToken) {
        deviceTokenText.text = deviceToken;
    }
}
