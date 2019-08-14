using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace NovellaStudio
{
    public static class Painter
    {
        /// <summary>
        /// Ввод данных с фреймов на экран
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="screen"></param>
        public static void DrawFrames(List<Frame> lst, MainScreen screen )
        {
            if (lst == null || lst.Count == 0)
                return;
            foreach (var frame in lst)
            {
                if (frame.Background != null)
                    screen.BackgroundImage = frame.Background;  //меняем фон

                if (frame.ClearMusic)
                    foreach (var x in screen.PlayingMusic)  //чистим музыку
                    {
                        x.Value.Stop();
                        screen.PlayingMusic.Remove(x.Key);
                    }
                else
                    foreach (var x in frame.MusicToDelete)  //удаляем по списку музыку
                    {
                        screen.PlayingMusic[x].Stop();
                        screen.PlayingMusic.Remove(x);
                    }
                foreach (var x in frame.Music)  //добавляем музыку
                {
                    screen.PlayingMusic.Add(x.SoundLocation, x);
                    screen.PlayingMusic[x.SoundLocation].Play();
                }

                if (frame.ClearSprites) //чистим спрайты
                    foreach (var x in screen.Sprites)
                    {
                        x.Value.Visible = false;
                        x.Value.Dispose();
                    }
                else
                    foreach (var x in frame.SpritesToDelete)    //удаляем по списку спрайты
                    {
                        screen.Sprites[x].Visible = false;
                        screen.Sprites[x].Dispose();
                    }
                foreach (var x in frame.Sprites)
                {
                    if (screen.Sprites.ContainsKey(x.Name))
                    {
                        if (x.Pic != null)     //Присваиваем картинку
                            screen.Sprites[x.Name].Image = x.Pic;

                        if (x.X != null)       //Присваиваем X
                            screen.Sprites[x.Name].Location = new Point((int)x.X, screen.Sprites[x.Name].Location.Y);

                        if (x.Y != null)       //Присваиваем Y
                            screen.Sprites[x.Name].Location = new Point(screen.Sprites[x.Name].Location.X, (int)x.Y);

                        if (x.Scale != null)   //Меняем Scale
                            screen.Sprites[x.Name].Scale(new SizeF((float)(screen.Sprites[x.Name].Image.Width * x.Scale), (float)(screen.Sprites[x.Name].Image.Height * x.Scale)));
                    }
                    else
                    {
                        var pic = SpriteToPictureBox(x,screen);
                        screen.Sprites.Add(pic.Name, pic);
                    }
                }


            }
        }

        /// <summary>
        /// Создаёт PictureBox по спрайту
        /// </summary>
        /// <param name="sprite"></param>
        /// <returns></returns>
        public static PictureBox SpriteToPictureBox(Sprite sprite, MainScreen screen)
        {
            if (sprite == null)
                return null;

            var res = new PictureBox();

            res.Name = sprite.Name;
            res.Image = sprite.Pic;
            res.Location = new Point((int)sprite.X, (int)sprite.Y);
            res.Scale(new SizeF((float)(res.Image.Width * sprite.Scale), (float)(res.Image.Height * sprite.Scale)));
            res.Visible = true;
            res.Parent = screen;
            return res;
        }

       

    }
}
