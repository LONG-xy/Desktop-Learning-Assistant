﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DesktopLearningAssistant.Configuration;
using DesktopLearningAssistant.TimeStatistic;
using DesktopLearningAssistant.TimeStatistic.Model;
using Newtonsoft.Json;

namespace TimeStatisticTest
{
    class Program
    {
        /*
        static void Main(string[] args)
        {
            ActivityMonitor monitor = ActivityMonitor.GetMonitor();
            monitor.Start();
            TimeStatisticService timeStatisticService = TimeStatisticService.GetTimeStatisticService();
            DateTime beginTime = DateTime.Now;
            DateTime endTime = DateTime.Now;

            while (true)
            {
                endTime = DateTime.Now;
                //List<UserActivity> userActivities = timeStatisticService.GetUserActivitiesWithin(beginTime, endTime);   // 获取最近五秒的活动统计
                List<UserActivity> userActivities = timeStatisticService.GetAllUserActivities();        // 获取所有的活动统计
                Console.Clear();
                foreach (UserActivity userActivity in userActivities)
                {
                    Console.WriteLine(userActivity.ToString());
                }
                Console.WriteLine("\n————————————————————\n");
                List<UserActivity> killedActivities = timeStatisticService.GetKilledUserActivities();
                foreach (UserActivity killedActivity in killedActivities)
                {
                    Console.WriteLine(killedActivity.ToString());
                }
                //TimeDataManager.GetTimeDataManager().SaveDataToDb();
                Thread.Sleep(1000);
            }
        }*/
        static void Main(string[] args)
        {
            string appdata = Environment.GetEnvironmentVariable("AppData");
            string recentFilePath = $"{appdata}\\Microsoft\\Windows\\Recent";
            DirectoryInfo directoryInfo = new DirectoryInfo(recentFilePath);
            Console.WriteLine(recentFilePath);
        }
        */
        static void Main(string[] args)
        {
            string appdata = Environment.GetEnvironmentVariable("AppData");
            string recentFilePath = $"{appdata}\\Microsoft\\Windows\\Recent";
            DirectoryInfo directoryInfo = new DirectoryInfo(recentFilePath);
            List<FileInfo> fileInfos = new List<FileInfo>(directoryInfo.GetFiles());
            fileInfos.Sort((fi1, fi2) => fi1.CreationTime < fi2.CreationTime ? 1 : -1);
            foreach (var fileInfo in fileInfos)
            {
                Console.WriteLine($"{fileInfo.Name}\t{fileInfo.CreationTime}");
            }
        }
    }
}
