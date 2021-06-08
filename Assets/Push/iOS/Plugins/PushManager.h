//
//  PushManager.h
//  PushDemo
//
//  Created by oneRain on 2021/6/7.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface PushManager : NSObject

+ (instancetype)sharedInstance;

- (void)requestAuthorization;

@end

NS_ASSUME_NONNULL_END
