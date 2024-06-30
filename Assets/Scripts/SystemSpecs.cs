using System;
using System.Collections;
using System.Collections.Generic;
using System.Management;
using UnityEngine;

public class SystemSpecs : MonoBehaviour
{
    static void Main()
    {
        Console.WriteLine("System Specifications:");
        Console.WriteLine("----------------------");

        // Get CPU information
        ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
        foreach (ManagementObject obj in cpuSearcher.Get())
        {
            Console.WriteLine($"CPU: {obj["Name"]}"); // You can fetch other properties as needed
        }

        // Get RAM information
        ManagementObjectSearcher ramSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
        ulong totalMemory = 0;
        foreach (ManagementObject obj in ramSearcher.Get())
        {
            totalMemory += Convert.ToUInt64(obj["Capacity"]);
        }
        Console.WriteLine($"Total RAM: {totalMemory / (1024 * 1024 * 1024)} GB");

        // Get OS information
        ManagementObjectSearcher osSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
        foreach (ManagementObject obj in osSearcher.Get())
        {
            Console.WriteLine($"OS: {obj["Caption"]} Version {obj["Version"]}");
        }

        // You can add more queries to fetch other system specifications like GPU, disk drives, etc.

        Console.ReadLine();
    }
}
