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
        private List<SoundPlayer> sounds { get; }
        private List<SoundPlayer> music { get; }
        private (string, string) text { get; }

        public Dictionary<string, Sprite> Sprites => sprites;
        public Bitmap Background => back;
        public List<SoundPlayer> Sounds => sounds;
        public List<SoundPlayer> Music => music;
        public (string,string) Text => text;


        /// <summary>
        /// Конструктор
        /// </summary>
        public Frame(Bitmap backGround, (string, string) text, List<(string,int,int,int,string)> spritesAndPos, List<SoundPlayer> sounds, List<SoundPlayer> music,Frame previous)
        {
            if (backGround != null)     //Ставим фон, если такой задан. Иначе прошлый
                back = backGround;
            else
                back = previous.Background;

            this.text = text;       //текстовое сообщение

            this.sounds = sounds;       //Одноразовые звуковые эффекты, идущие подряд   //TODO задержки между треками

            this.music = music;         //Фоновая музыка, играет одновременно

            if (previous != null)
                sprites = new Dictionary<string, Sprite>(previous.Sprites);     //забираем список предыдущих спрайтов
            else
                sprites = new Dictionary<string, Sprite>();
            if (spritesAndPos!=null) 
                foreach (var x in spritesAndPos)
                {
                    string name = x.Item1;
                    if (sprites.ContainsKey(name))      //меняем положение и размер прошлых
                    {
                    sprites[name].X = x.Item2;
                    sprites[name].Y = x.Item3;
                    sprites[name].Scale = x.Item4;
                    }
                    else
                    {
                    sprites.Add(name, new Sprite(name, x.Item2, x.Item3, x.Item4, x.Item5));    //добовляем новые
                    }
                }

        }


    }
}
