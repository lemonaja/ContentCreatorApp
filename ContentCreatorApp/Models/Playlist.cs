using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentCreatorApp.Models
{
    public class Playlist
    {
        public int Id { get; set; } 
        public string Nome { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public List<Content> Conteudos { get; set; } = new List<Content>();
    }

    public class Content
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; 
    }
}
