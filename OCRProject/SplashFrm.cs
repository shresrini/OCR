using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ImageProcessing
{
    partial class SplashFrm : Form
    {
        public SplashFrm()
        {
            InitializeComponent();
            this.Refresh();
            this.Text = "Loading....";
        }
    }
}
