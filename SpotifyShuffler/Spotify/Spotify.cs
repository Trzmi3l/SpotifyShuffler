using SpotifyAPI.Web;
using SpotifyAPI;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SpotifyShuffler.Spotify
{
    class Spotify
    {

        static Form1 f = null;




        readonly static string clientID = "ce61404266af4eaa8654aec278a45397";
        static SpotifyClientConfig config;
        static EmbedIOAuthServer _server;
        public static SpotifyClient Client;
        public static string userId;
        public static SpotifyClient tempS;

        public static List<PlaylistModel> playlists = new List<PlaylistModel>();

        public Spotify(Form1 _f)
        {
            f = _f as Form1;
            Initialize();
        }

        static async void GetPlaylists()
        {

        }

        public static async Task Login()
        {
            _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
            await _server.Start();

            _server.ImplictGrantReceived += OnImplicitGrantReceived;
            _server.ErrorReceived += OnErrorReceived;

            var request = new LoginRequest(_server.BaseUri, clientID, LoginRequest.ResponseType.Token)
            {
                Scope = new List<string> { Scopes.PlaylistModifyPublic, Scopes.PlaylistModifyPrivate, Scopes.PlaylistReadCollaborative }
            };
            BrowserUtil.Open(request.ToUri());
        }
        private static async Task OnImplicitGrantReceived(object sender, ImplictGrantResponse response)
        {
            await _server.Stop();
            
            var spotify = new SpotifyClient(response.AccessToken);
            tempS = spotify;
            // do calls with Spotify

            //disable login and enable panel >>>>
            f.ManagePanel.Invoke((MethodInvoker)delegate
            {
                f.ManagePanel.Enabled = true;
                f.Shuffle.Enabled = true;
                f.CreateShuffle.Enabled = true;
                f.BUTTON_Login.Enabled = false;
            });

            var _sraka = spotify.Playlists.CurrentUsers().Result.Items;
            foreach (var d in _sraka)
            {
                System.Diagnostics.Debug.WriteLine(d.Name);



                f.PlaylistListbox.Invoke((MethodInvoker)delegate
                {
                    PlaylistModel temp = new PlaylistModel()
                    {
                        Uri = d.Uri,
                        id = d.Id,
                        name = d.Name,
                        tracks = d.Tracks.Total.Value
                    };

                    playlists.Add(temp);
                    f.PlaylistListbox.Items.Add(temp.name);
                });
            }
        }

        public static async Task<List<String>>ShufflePlaylist(string playlistId)
        {
            List<String> tracks = new List<String>();
            List<String> shuffled = new List<String>();

            var temp = await tempS.Playlists.GetItems(playlistId);
            int d = 1;
            await foreach (var item in tempS.Paginate(temp))
            {
                
                if(item.Track is FullTrack track)
                {
                    tracks.Add(track.Uri);
                    System.Diagnostics.Debug.WriteLine("Progress: " + d + " / 1795");
                    System.Diagnostics.Debug.WriteLine(track.Name);
                    d++;
                }
                
                
            }
            

            shuffled = tracks;
           

            
            //shuffled.Shuffle();
           
            
            System.Diagnostics.Debug.WriteLine(shuffled.Count);
            return tracks;

        }

        public static async Task AddSongsIterate(List<string> _uris, string _playlistId)
        {
            _uris.Shuffle2();

            if (_uris.Count <= 100)
            {
                _uris.Shuffle();
                var lowerthan100Request = new PlaylistAddItemsRequest(_uris);
                
                await tempS.Playlists.AddItems(_playlistId, lowerthan100Request);

            } else if(_uris.Count > 100)
            {
                int iters = (_uris.Count / 99) + 1;
                //System.Diagnostics.Debug.WriteLine("Iters: " + iters);
                System.Diagnostics.Debug.WriteLine("144");
                int addedTracks = 0;
                for (int i = 0; i < iters; i++)
                {
                    System.Diagnostics.Debug.WriteLine("147");
                    List<string> tempUris = new List<string>();
                    for (int j = 0; j < 99; j++)
                    {
                        if(addedTracks >= _uris.Count)
                        {
                            break;
                        }
                        if(tempUris.Count == 50) tempUris.Shuffle();
                        tempUris.Add(_uris[addedTracks]);
                       
                        addedTracks++;
                    }
                    System.Diagnostics.Debug.WriteLine("154");
                    tempUris.Shuffle();
                    var multiAddRequest = new PlaylistAddItemsRequest(tempUris);
                    await tempS.Playlists.AddItems(_playlistId, multiAddRequest);
                    tempUris.Clear();
                    System.Diagnostics.Debug.WriteLine("158");
                }

            }
        }

        private static async Task OnErrorReceived(object sender, string error, string state)
        {
            Console.WriteLine($"Aborting authorization, error received: {error}");
            await _server.Stop();
        }

        static async Task<bool> Initialize()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Spotify api initialized");
                Client = new SpotifyClient(config);

                return true;
            } catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }

    }

    static class Extension
    {
        public static async void Shuffle<T>(this IList<T> list)
        {
            System.Diagnostics.Debug.WriteLine("Shuffling playlist METHOD SHUFFLE EXTENSION");
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            System.Diagnostics.Debug.WriteLine(list.Count);
            int n = list.Count;
            int p = 1;
            while (n > 1)
            {
                System.Diagnostics.Debug.WriteLine("207");
                byte[] box = new byte[1];
                System.Diagnostics.Debug.WriteLine("209");
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                System.Diagnostics.Debug.WriteLine("212");
                int k = (box[0] % n);
                System.Diagnostics.Debug.WriteLine("214");
                n--;
                System.Diagnostics.Debug.WriteLine("216");
                T value = list[k];
                list[k] = list[n];
                System.Diagnostics.Debug.WriteLine("219");
                list[n] = value;
                p++;
            }

            System.Diagnostics.Debug.WriteLine("Shuffling playlist !!ENDED!! METHOD SHUFFLE EXTENSION");
        }
        private static Random rng = new Random();
        public static void Shuffle2<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }

}
