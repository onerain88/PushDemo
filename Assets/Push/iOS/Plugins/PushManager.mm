//
//  PushManager.m
//  PushDemo
//
//  Created by oneRain on 2021/6/7.
//

#import "PushManager.h"
#import <UIKit/UIKit.h>
#import <UserNotifications/UserNotifications.h>

#include "Classes/PluginBase/AppDelegateListener.h"
#include "Classes/PluginBase/LifeCycleListener.h"

@implementation PushManager

+ (void)load {
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        NSNotificationCenter* nc = [NSNotificationCenter defaultCenter];
        [nc addObserverForName:UIApplicationDidFinishLaunchingNotification
                        object:nil
                         queue:[NSOperationQueue mainQueue]
                    usingBlock:^(NSNotification * _Nonnull note) {
            
        }];
        
        [nc addObserverForName:kUnityDidRegisterForRemoteNotificationsWithDeviceToken object:nil queue:[NSOperationQueue mainQueue] usingBlock:^(NSNotification * _Nonnull note) {
            NSLog(@"didRegisterForRemoteNotificationsWithDeviceToken");
            if ([note.userInfo isKindOfClass: [NSData class]]) {
                NSString* deviceToken = [PushManager hexadecimalStringFromData:(NSData*)note.userInfo];
                UnitySendMessage("PushManager", "OnRegisteredDeviceToken", [deviceToken UTF8String]);
            }
        }];
    });
}

+ (instancetype)sharedInstance {
    static PushManager* sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[PushManager alloc] init];
    });
    return sharedInstance;
}

- (void)requestAuthorization {
    [[UNUserNotificationCenter currentNotificationCenter] getNotificationSettingsWithCompletionHandler:^(UNNotificationSettings * _Nonnull settings) {
        switch ([settings authorizationStatus]) {
            case UNAuthorizationStatusAuthorized:
                dispatch_async(dispatch_get_main_queue(), ^{
                    [[UIApplication sharedApplication] registerForRemoteNotifications];
                });
                break;
            case UNAuthorizationStatusNotDetermined:
                [[UNUserNotificationCenter currentNotificationCenter] requestAuthorizationWithOptions:UNAuthorizationOptionBadge | UNAuthorizationOptionSound | UNAuthorizationOptionAlert completionHandler:^(BOOL granted, NSError * _Nullable error) {
                    if (granted) {
                        dispatch_async(dispatch_get_main_queue(), ^{
                            [[UIApplication sharedApplication] registerForRemoteNotifications];
                        });
                    }
                }];
                break;
            default:
                break;
        }
    }];
}

+ (NSString *)hexadecimalStringFromData:(NSData *)data {
    NSUInteger dataLength = data.length;
    if (!dataLength) {
        return nil;
    }
    const unsigned char* dataBuffer = (unsigned char*)data.bytes;
    NSMutableString *hexString = [NSMutableString stringWithCapacity:(dataLength * 2)];
    for (int i = 0; i < dataLength; ++i) {
        [hexString appendFormat:@"%02.2hhx", dataBuffer[i]];
    }
    return hexString;
}

@end
