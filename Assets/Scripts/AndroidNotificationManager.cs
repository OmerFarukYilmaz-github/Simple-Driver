using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationManager : MonoBehaviour
{
#if UNITY_ANDROID
    const string CHANNEL_ID ="Not_Channel_Id";
    public void ScheduleNotification(System.DateTime dateTime)
    {
        AndroidNotificationChannel notificationChannel = 
        new AndroidNotificationChannel
        {
            Id = CHANNEL_ID,
            Name = "Notification Channel Name ",
            Description = "Description",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification
        {
            Title = "Energy is full! ",
            Text = "Let's have one more tour",
            SmallIcon= "default",
            LargeIcon= "default",
            FireTime= dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);
    }
#endif
}
