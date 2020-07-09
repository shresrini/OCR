using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ImageProcessing
{
    partial class ProgressFrm : Form
    {
        public ProgressFrm()
        {
            InitializeComponent();
            this.Refresh();
            this.Text = "Loading....";
        }
    }
}
