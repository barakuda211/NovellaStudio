using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovellaStudio
{
    /// <summary>
    /// Один статичный кадр
    /// </summary>
    public class Frame
    {
        private Bitmap back { get; }
        private Dictionary<string,Sprite> sprites { get; }

        public Dictionary<string, Sprite> Sprites => sprites;
        public Bitmap Background => back;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Frame(Bitmap backGround, List<(string,int,int,int,string)> spritesAndPos, List<SoundPlayer> sounds, SoundPlayer music,Frame pervious)
        {
            back = backGround;
            sprites = new Dictionary<string, Sprite>(pervious.Sprites);
            foreach (var x in spritesAndPos)
            {
                string name = x.Item1;
                if (sprites.ContainsKey(name))
                {
                    sprites[name].X = x.Item2;
                    sprites[name].Y = x.Item3;
                    sprites[name].Scale = x.Item4;
                }
                else
                {
                    sprites.Add(name, new Sprite(name, x.Item2, x.Item3, x.Item4, x.Item5));
                }
            }

        }


    }
}
