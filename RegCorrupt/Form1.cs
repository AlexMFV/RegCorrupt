using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegCorrupt
{
    public partial class Form1 : Form
    {
        RegistryKey def_path = Registry.LocalMachine;

        public Form1()
        {
            InitializeComponent();
            GetFullRegistry();
        }

        public void GetFullRegistry()
        {
            string[] SubKeys = def_path.GetSubKeyNames();

            foreach (string key in SubKeys)
            {
                if (key != "SECURITY")
                {
                    TreeNode parent = treeRegistry.Nodes.Add(key);
                    LoadSubKeys(def_path.OpenSubKey(key), parent);
                }
            }
        }

        public void LoadSubKeys(RegistryKey path, TreeNode parent)
        {
            foreach(string key in path.GetSubKeyNames())
            {
                try
                {
                    TreeNode newParent = parent.Nodes.Add(key);
                    LoadSubKeys(path.OpenSubKey(key), newParent);
                }
                catch (System.Security.SecurityException)
                {
                    break;
                }
            }
        }
    }
}
