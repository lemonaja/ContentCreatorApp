using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using ContentCreatorApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ContentCreatorApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Playlist>> GetPlaylistsAsync()
        {
            var response = await _httpClient.GetAsync("api/Playlist");
            if (response.IsSuccessStatusCode)
            {
                var playlists = await response.Content.ReadFromJsonAsync<List<Playlist>>();
                return playlists ?? new List<Playlist>();
            }
            else
            {
                throw new Exception("Erro ao buscar playlists.");
            }
        }

        public async Task AddPlaylistAsync(Playlist playlist)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Playlist", playlist);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdatePlaylistAsync(Playlist playlist)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Playlist/{playlist.Id}", playlist);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Playlist/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
