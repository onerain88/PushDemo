using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushManager : MonoBehaviour {
    public Text deviceTokenText;

    public void OnRegisteredDeviceToken(string deviceToken) {
        deviceTokenText.text = deviceToken;
    }
}
