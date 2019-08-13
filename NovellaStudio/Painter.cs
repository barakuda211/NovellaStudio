using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace NovellaStudio
{
    public static class Painter
    {
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
                        
                    }
                }


            }
        }

        public static void EditPictureBox(ref PictureBox pic, Sprite sprite)
        {
            
        }

    }
}
