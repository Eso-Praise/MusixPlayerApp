using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixPlayerApp
{
    public class MusicPlayer
    {
        private List<Music> playlist = new List<Music>();
        public void CreatePlaylist(string directoryPath)
        {
            string[] musicFiles = Directory.GetFiles(directoryPath, "*.mp3");

            foreach (string filePath in musicFiles)
            {
                var music = new Music
                {
                    Title = Path.GetFileNameWithoutExtension(filePath),
                    Artist = "Unknown", // You can implement a more sophisticated method to retrieve artist information
                    FilePath = filePath
                };

                playlist.Add(music);
            }

            Console.WriteLine("Playlist created successfully.");
        }

        public void DisplayPlaylist()
        {
            Console.WriteLine("Current Playlist:");
            foreach (var music in playlist)
            {
                Console.WriteLine($"{music.Title} - {music.Artist}");
            }
        }

        public void EditMusicDetails(string title)
        {
            var music = playlist.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (music != null)
            {
                Console.Write("Enter new title: ");
                music.Title = Console.ReadLine();
                Console.Write("Enter new artist: ");
                music.Artist = Console.ReadLine();

                Console.WriteLine("Music details updated successfully.");
            }
            else
            {
                Console.WriteLine("Music not found in the playlist.");
            }
        }

        public void PlayMusic(string title)
        {
            var music = playlist.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (music != null)
            {
                Console.WriteLine($"Now playing: {music.Title} - {music.Artist}");
                // Implement audio playback logic here (e.g., using a third-party library)
            }
            else
            {
                Console.WriteLine("Music not found in the playlist.");
            }
        }

        public void DeleteMusic(string title)
        {
            var music = playlist.Find(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (music != null)
            {
                playlist.Remove(music);
                Console.WriteLine("Music deleted from the playlist.");
            }
            else
            {
                Console.WriteLine("Music not found in the playlist.");
            }
        }

        public void ShufflePlaylist()
        {
            Random random = new Random();
            playlist = playlist.OrderBy(x => random.Next()).ToList();
            Console.WriteLine("Playlist shuffled successfully.");
        }

        public void SortPlaylist()
        {
            playlist = playlist.OrderBy(x => x.Title).ToList();
            Console.WriteLine("Playlist sorted successfully.");
        }
    }
}
