using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class IOSWrapper {
    [DllImport("__Internal")]
    private static extern void _ReqAuthorization();

    public static void RequestAuthorization() {
        _ReqAuthorization();
    }
}
