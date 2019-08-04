using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NovellaStudio.MyExceptions;

namespace NovellaStudio
{
    

    public partial class MainScreen : Form
    {
        private Frame defaultFrame;
        private List<Frame> Script = new List<Frame>();
        private SoundPlayer nya = new SoundPlayer(@"default/nya.wav");

        public MainScreen()
        {
            InitializeComponent();
            InitForm();
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            return;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            InitForm();
            nya.Play();
        }
        private int InitForm(string path = @"default\init.txt")
        {
            if (!File.Exists(path))
                return 0;

            var initInfo = File.ReadAllLines(path, Encoding.UTF8);
            Text = initInfo[0];
            BackgroundImage = new Bitmap(initInfo[1]);
            InitScript(initInfo[2]);
            return 1;
            
        }


        private void InitDefault()
        {
            var music = new SoundPlayer[] { new SoundPlayer("default/defMusic.mp3") }.ToList();
            var sound = new SoundPlayer[] { new SoundPlayer("default/nya.wav") }.ToList();
            var spr = new (string, int, int, int, string)[] { ("Алиса", 300, 300, 1, "default /alice.png") }.ToList();
            var txt = new (string, string)[] { ("Летов", "Ты не должен был сюда попасть!") }.ToList();
            defaultFrame = new Frame(new Bitmap("default/defBack.jpg"), music, new List<string>(), sound, new List<string>(), spr, txt, defaultFrame);
        }

        private int InitScript(string path = "scen1.txt")
        {
            try
            {
                if (!File.Exists(path))
                    throw new ScriptNotFoundException();
                Script.Add(defaultFrame);
                var file = File.ReadAllLines(path).ToList();
                int i = 0;
                while (i <= file.Count)
                {
                    Script.Add(ConvertFrame(ref i, ref file));
                }
                return 1;
            }
            catch (ScriptNotFoundException e)
            {
                return 0;
            }
            catch (ScriptTextException e)
            {
                return 0;
            }
        }

        private Frame ConvertFrame(ref int i,ref List<string> file)
        {
            if (file[i] != "[")
                throw new ScriptTextException();
            file.RemoveAll(x => x.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length == 0);    //удаление пустых строк
            bool IsFrameRead = false;

            Bitmap background;
            var music = new List<SoundPlayer>();
            var clearMusic = false;
            var listOfDelMusic = new List<string>();
            var sounds = new List<SoundPlayer>();
            var spritesAndPos = new List<(string, int, int, int, string)>();
            var clearSprites = false;
            var listOfDelSprites = new List<string>();
            var textList = new List<(string, string)>();

            while (!IsFrameRead)
            {
                i++;
                if (i == file.Count)
                    throw new ScriptTextException();
                var line = file[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (line[0])
                {
                    case "@background":
                        background = new Bitmap(line[1]);
                        continue;
                    case "@music":
                        for (int j = 1; j < line.Length; j++)
                            music.Add(new SoundPlayer(line[j]));
                        continue;
                    case "@delmusic":
                        for (int j = 1; j < line.Length; j++)
                            listOfDelMusic.Add(line[j]);
                        continue;
                    case "@clearmusic":
                        clearMusic = true;
                        continue;
                    case "@sounds":
                        for (int j = 1; j < line.Length; j++)
                            sounds.Add(new SoundPlayer(line[j]));
                        continue;
                    case "@clearsprites":
                        clearSprites = true;
                        continue;
                    case "@delsprites":
                        for (int j = 1; j < line.Length; j++)
                            listOfDelSprites.Add(line[j]);
                        continue;
                    case "@sprites":
                        ConvertSprites(ref i, ref spritesAndPos, ref file);
                        continue;
                    case "@text":
                        ConvertText(ref i, ref textList, ref file);
                        continue;
                    case "]":
                        IsFrameRead = true;
                        continue;
                }
                var frame = new Frame();
                
            }

            return null;
        }

        private void ConvertText(ref int i, ref List<(string, string)> lst, ref List<string> file)
        {
            while (true)
            {
                i++;
                if (file[i] == "]")
                {
                    i--;
                    return;
                }
                var line = file[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "@nl")
                {
                    if (lst.Count == 0)
                        throw new ScriptTextException();
                    //lst[lst.Count - 1] += Environment.NewLine.ToString();


                    if (i + 1 < file.Count && file[i + 1] != "]" && file[i + 1] != "@nl")
                        lst[lst.Count] = (lst[lst.Count].Item1, file[++i]);
                }
                else
                {
                    var split = file[i].Split('|');
                    lst.Add((split[0],split[1]));
                }
            }
        }

        private void ConvertSprites(ref int i, ref List<(string, int, int, int, string)> lst,ref List<string> file)
        {
            while (true)
            {
                i++;
                if (file[i] == "@text" || file[i] == "]")
                {
                    i--;
                    return;
                }
                var line = file[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = line[0];
                line.RemoveAt(0);
                int x = int.MinValue; int y = int.MinValue; int scale = int.MinValue; string path = "";
                foreach (var word in line)
                {
                    if (word.StartsWith("x:"))
                    {
                        x = int.Parse(word.Substring(2));
                        continue;
                    }
                    if (word.StartsWith("y:"))
                    {
                        y = int.Parse(word.Substring(2));
                        continue;
                    }
                    if (word.StartsWith("scale:"))
                    {
                        scale = int.Parse(word.Substring(6));
                        continue;
                    }
                    path = word;
                }
                lst.Add((name, x, y, scale, path));
            }
        }


    }
}
