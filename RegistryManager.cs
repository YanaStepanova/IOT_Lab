using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace Snapshoter
{
    public static class RegistryManager
    {
        public static bool IsMotition
        {
            get
            {
                try
                {
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\SnapshotMaker", true);
                    int isAuto = (int)regKey.GetValue("IsMotition", 0);
                    regKey.Close();
                    return isAuto != 0;
                }
                catch
                {
                    return false;
                }
            }

            set
            {
                int val = value ? 1 : 0;
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software", true);
                RegistryKey wKey = regKey.CreateSubKey("SnapshotMaker");
                wKey.SetValue("IsMotition", val);
                wKey.Close();
            }
        }

        public static string DefaultCamera
        {
            get
            {
                try
                {
                    RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\SnapshotMaker", true);
                    string saveFile = (string)regKey.GetValue("DefaultCamera", "");
                    regKey.Close();
                    return saveFile;
                }
                catch
                {
                    return "";
                }
            }

            set
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software", true);
                RegistryKey wKey = regKey.CreateSubKey("SnapshotMaker");
                wKey.SetValue("DefaultCamera", value);
                wKey.Close();
            }
        }
    }
}

