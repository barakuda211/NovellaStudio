using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NovellaStudio
{
    /// <summary>
    /// Подвижный объект на сцене
    /// </summary>
    public class Sprite
    {
        private int x { get; set; }
        private int y { get; set; }
        private int scale { get; set; }
        private Bitmap pic { get; set; }

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public Bitmap Pic
        {
            get { return pic; }
            set { pic = value; }
        }

        /// <summary>
        /// Прост
        /// </summary>
        public Sprite() { }

        /// <summary>
        /// Задать битмапом
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        /// <param name="pic"></param>
        public Sprite(int x, int y, int scale, Bitmap pic)
        {
            this.x = x;
            this.y = y;
            this.scale = scale;
            this.pic = pic;
        }

        /// <summary>
        /// Задать файлом
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        /// <param name="path"></param>
        public Sprite(int x, int y, int scale, string path)
        {
            this.x = x;
            this.y = y;
            this.scale = scale;
            pic = new Bitmap(path);
        }

    }
}
