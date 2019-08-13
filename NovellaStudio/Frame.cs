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
        private List<Sprite> sprites { get; }
        private List<SoundPlayer> sounds { get; }
        private List<SoundPlayer> music { get; }
        private List<string> delMusic { get; }
        private bool clearMusic { get; }
        private List<string> delSprites { get; }
        private bool clearSprites { get; }
        private List<(string, string)> text { get; }

        public List<Sprite> Sprites => sprites;
        public Bitmap Background => back;
        public List<SoundPlayer> Sounds => sounds;
        public List<SoundPlayer> Music => music;
        public List<(string, string)> Text => text;
        public List<string> MusicToDelete => delMusic;
        public bool ClearMusic => clearMusic;
        public List<string> SpritesToDelete => delSprites;
        public bool ClearSprites => clearSprites;


        /// <summary>
        /// Конструктор
        /// </summary>
        public Frame(Bitmap backGround, List<SoundPlayer> music, List<string> delMusic, List<SoundPlayer> sounds, List<string> delSprites, List<(string, int?, int?, int?, string)> spritesAndPos, List<(string, string)> text, bool clearMusic = false, bool clearSprites = false)
        {
            back = backGround;

            this.text = text;       //текстовое сообщение

            this.sounds = sounds;       //Одноразовые звуковые эффекты, идущие подряд   //TODO задержки между треками

            this.delMusic = delMusic;       //Музыка для выключения
            this.clearMusic = clearMusic;   //Выключить всю музыку
            this.music = music;         //Фоновая музыка, играет одновременно

            this.clearSprites = clearSprites;
            this.delSprites = delSprites;
            this.sprites = new List<Sprite>();
            if (spritesAndPos != null)
               foreach (var x in spritesAndPos)
               {
                       sprites.Add(new Sprite(x.Item1, x.Item2, x.Item3, x.Item4, x.Item5));    //добавляем новые
               }

        }


    }
}
