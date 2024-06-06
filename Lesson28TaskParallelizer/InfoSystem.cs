using System.Management;

namespace Lesson28TaskParallelizer;

internal class InfoSystem
{

    public static string GetOSVersion() => Environment.OSVersion.VersionString;

    public static int GetProcessorCount() => Environment.ProcessorCount;

    public static string GetProcessorName()
    {
        string name = "";
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
        foreach (ManagementObject obj in searcher.Get())
        {
            name = obj["Name"].ToString();
        }
        return name;
    }

    public static int GetProcessorFrequency()
    {
        int frequency = 0;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
        foreach (ManagementObject obj in searcher.Get())
        {
            frequency = Convert.ToInt32(obj["MaxClockSpeed"]);
        }
        return frequency;
    }

    public static long GetTotalMemoryInMB()
    {
        long totalMemory = 0;
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("select TotalPhysicalMemory from Win32_ComputerSystem");
        foreach (ManagementObject obj in searcher.Get())
        {
            totalMemory = Convert.ToInt64(obj["TotalPhysicalMemory"]) / (1024 * 1024);
        }
        return totalMemory;
    }

}
