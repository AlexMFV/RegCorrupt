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
                if(key != "SECURITY")
                    lstRegistry.Items.Add(key);
            }
        }

        public void LoadSubKeys(RegistryKey path)
        {
            lstRegistry.Items.Clear();

            foreach(string key in path.GetSubKeyNames())
            {
                lstRegistry.Items.Add(key);
            }
        }

        private void lstRegistry_DoubleClick(object sender, EventArgs e)
        {
            if (lstRegistry.SelectedIndex != -1)
                LoadSubKeys(def_path.OpenSubKey(lstRegistry.SelectedItem.ToString()));
        }
    }
}
