using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace MusicPlayerImplementation
{
    enum PlaybackState
    {
        Playing,
        Paused,
        Stopped
    }
    class MusicPlayer
    {
        List<string> playlist;
        WindowsMediaPlayer player;
        public PlaybackState State { get; set; }
        public List<string> Playlist { get { return playlist; } }
        public MusicPlayer()
        {
            playlist = new List<string>();
            player = new WindowsMediaPlayer();
            State = PlaybackState.Stopped;
            
        }
        public void LoadPlaylist(List<string> list)
        {
            playlist = list;
        }
        public void SelectMedia(int index)
        {
            string path = playlist.ElementAt(index);
            player.URL = path;
        }
        public void Play()
        {
            player.controls.play();
            State = PlaybackState.Playing;
        }
        public void Pause()
        {
            player.controls.pause();
            State = PlaybackState.Paused;
        }
        public void Stop()
        {
            player.controls.stop();
            State = PlaybackState.Stopped;
        }
    }
}
