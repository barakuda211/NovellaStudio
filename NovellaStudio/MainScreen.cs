using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovellaStudio
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            InitForm();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            InitForm();
        }
        private int InitForm()
        {
            if (File.Exists("init.txt"))
            {
                var initInfo = File.ReadAllLines("init.txt", Encoding.UTF8);
                this.Text = initInfo[0];
                this.BackgroundImage = new Bitmap(initInfo[1]);
                return 1;
            }

            return 0;
        }


    }
}
