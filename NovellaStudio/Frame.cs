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
        private List<string> delMusic { get; }
        private bool clearMusic { get; }

        private List<(string, string)> text { get; }

        public Dictionary<string, Sprite> Sprites => sprites;
        public Bitmap Background => back;
        public List<SoundPlayer> Sounds => sounds;
        public List<SoundPlayer> Music => music;
        public List<(string, string)> Text => text;
        public List<string> MusicToDelete => delMusic;
        public bool ClearMusic => clearMusic;


        /// <summary>
        /// Конструктор
        /// </summary>
        public Frame(Bitmap backGround, List<SoundPlayer> music, List<string> delMusic, List<SoundPlayer> sounds, List<string> delSprites, List<(string, int, int, int, string)> spritesAndPos, List<(string, string)> text, Frame previous, bool clearMusic = false, bool clearSprites = false)
        {
            if (backGround != null)     //Ставим фон, если такой задан. Иначе прошлый
                back = backGround;
            else
                back = previous.Background;

            this.text = text;       //текстовое сообщение

            this.sounds = sounds;       //Одноразовые звуковые эффекты, идущие подряд   //TODO задержки между треками

            this.delMusic = delMusic;       //Музыка для выключения
            this.clearMusic = clearMusic;   //Выключить всю музыку
            this.music = music;         //Фоновая музыка, играет одновременно

            if (previous != null && !clearSprites)
                sprites = new Dictionary<string, Sprite>(previous.Sprites);     //забираем список предыдущих спрайтов
            else
                sprites = new Dictionary<string, Sprite>();
            foreach (var x in delSprites)       //очистка ненужных спрайтов
                if (sprites.ContainsKey(x))
                    sprites.Remove(x);
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
                    sprites.Add(name, new Sprite(name, x.Item2, x.Item3, x.Item4, x.Item5));    //добавляем новые
                    }
                }

        }


    }
}
