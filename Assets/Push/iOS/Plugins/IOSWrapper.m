//
//  IOSWrapper.m
//  UnityFramework
//
//  Created by oneRain on 2021/6/8.
//

#import <Foundation/Foundation.h>
#import "PushManager.h"

void _ReqAuthorization() {
    [[PushManager sharedInstance] requestAuthorization];
}
