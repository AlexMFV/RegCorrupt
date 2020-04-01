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
        }
    }
}
