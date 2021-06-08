using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloPush : MonoBehaviour {
    public void OnRequestAuthorizationClicked() {
        IOSWrapper.RequestAuthorization();
    }
}
