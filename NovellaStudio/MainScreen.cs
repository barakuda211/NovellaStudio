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
        private int InitForm(string path = "init.txt")
        {
            if (File.Exists(path))
            {
                var initInfo = File.ReadAllLines("init.txt", Encoding.UTF8);
                this.Text = initInfo[0];
                this.BackgroundImage = new Bitmap(initInfo[1]);
                for (int i = 2; i < initInfo.Length; i++)
                {

                }
                return 1;
            }

            return 0;
        }

        private int InitScript(string path = "scen1.txt")
        {
            if (!File.Exists(path))
             return 0;

            return 1;
        }


    }
}
