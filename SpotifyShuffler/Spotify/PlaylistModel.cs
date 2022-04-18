using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyShuffler.Spotify
{
    class PlaylistModel
    {
        public String name { get; set; }
        public String id { get; set; }
        
        public string Uri { get; set; }

        public int tracks { get; set; }
    }
}
