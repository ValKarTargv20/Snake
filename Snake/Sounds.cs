using System;
using System.Collections.Generic;
using System.Text;
using WMPLib;

namespace Snake
{
    public class Sounds
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        private string pathToMedia;
        public Sounds(string pathToResources)
        {
            pathToMedia = pathToResources;
        }
        public void Play()
        {
            player.URL = pathToMedia + "space.mp3";
            player.settings.volume = 30;
            player.controls.play();
            player.settings.setMode("loop", true);
        }
        public void Stop()
        {
            player.URL = pathToMedia + "space.mp3";
            player.controls.stop();
        }
        public void PlayEat()
        {
            player.URL = pathToMedia + "crunch.mp3";
            player.settings.volume = 80;
            player.controls.play();
        }
        public void PlayEatS()
        {
            player.URL = pathToMedia + "Nut.mp3";
            player.settings.volume = 80;
            player.controls.play();
        }
        public void PlayEatB()
        {
            player.URL = pathToMedia + "explosion.mp3";
            player.settings.volume = 80;
            player.controls.play();
        }

    }
}