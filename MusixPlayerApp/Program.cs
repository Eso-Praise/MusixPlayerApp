using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusixPlayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                MusicPlayer musicPlayer = new MusicPlayer();

                // Specify the directory path where your music files are stored
                string directoryPath = @"C:\Your\Music\Directory";

                musicPlayer.CreatePlaylist(directoryPath);

                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Display Playlist");
                    Console.WriteLine("2. Edit Music Details");
                    Console.WriteLine("3. Play Music");
                    Console.WriteLine("4. Delete Music");
                    Console.WriteLine("5. Shuffle Playlist");
                    Console.WriteLine("6. Sort Playlist");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            musicPlayer.DisplayPlaylist();
                            break;
                        case "2":
                            Console.Write("Enter the title of the music to edit: ");
                            string titleToEdit = Console.ReadLine();
                            musicPlayer.EditMusicDetails(titleToEdit);
                            break;
                        case "3":
                            Console.Write("Enter the title of the music to play: ");
                            string titleToPlay = Console.ReadLine();
                            musicPlayer.PlayMusic(titleToPlay);
                            break;
                        case "4":
                            Console.Write("Enter the title of the music to delete: ");
                            string titleToDelete = Console.ReadLine();
                            musicPlayer.DeleteMusic(titleToDelete);
                            break;
                        case "5":
                            musicPlayer.ShufflePlaylist();
                            break;
                        case "6":
                            musicPlayer.SortPlaylist();
                            break;
                        case "0":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}
