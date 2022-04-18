using SpotifyAPI.Web;

namespace SpotifyShuffler
{
    public partial class Form1 : Form
    {
        Spotify.Spotify s;

        public Form1()
        {
            InitializeComponent();
            s = new Spotify.Spotify(this);

            

        }

        private async void BUTTON_Login_Click(object sender, EventArgs e)
        {
          await Spotify.Spotify.Login();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ManagePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string selected = PlaylistListbox.Text;

            var result = Spotify.Spotify.playlists.Find(x => x.name == selected);
            //System.Diagnostics.Debug.WriteLine(result.id);


            System.Diagnostics.Debug.WriteLine("started shuffling and getting tracks");
            List<String> newPlaylist = await Spotify.Spotify.ShufflePlaylist(result.id);
            var userId = Spotify.Spotify.tempS.UserProfile.Current().Result.Id;
            System.Diagnostics.Debug.WriteLine("Shuffled playlist");
            var playlistConfig = new PlaylistCreateRequest(selected + " - SHUFFLED") {
                Public = true
            };





            var playlistAddConfig = new PlaylistAddItemsRequest(newPlaylist);

           

            var playlistId = Spotify.Spotify.tempS.Playlists.Create(userId, playlistConfig);
            System.Diagnostics.Debug.WriteLine("Adding items");
            await Spotify.Spotify.AddSongsIterate(newPlaylist, playlistId.Result.Id);
            System.Diagnostics.Debug.WriteLine("!!!!!!!!Adding items done!!!!!!!!!!");
        }

        private void PlaylistListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            string selected = PlaylistListbox.Text;

            var result = Spotify.Spotify.playlists.Find(x => x.name == selected);
            System.Diagnostics.Debug.WriteLine(result.Uri);



        }
    }
}