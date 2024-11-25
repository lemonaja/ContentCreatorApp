using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentCreatorApp.Models;
using ContentCreatorApp.Services;

namespace ContentCreatorApp.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiService _apiService; // Armazena a instância do ApiService

        public MainPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService; // Atribui a instância ao campo
        }

        private async void OnLoadPlaylistsClicked(object sender, EventArgs e)
        {
            try
            {
                var playlists = await _apiService.GetPlaylistsAsync();
             
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        private async void OnGetPlaylistsClicked(object sender, EventArgs e)
        {
            try
            {
                var playlists = await _apiService.GetPlaylistsAsync();
                string message = playlists.Any()
                    ? string.Join(", ", playlists.Select(p => p.Nome))
                    : "Nenhuma playlist encontrada.";
                await DisplayAlert("Playlists", message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void OnAddPlaylistClicked(object sender, EventArgs e)
        {
            try
            {
                var novaPlaylist = new Playlist
                {
                    Nome = "Minha Nova Playlist",
                    Conteudos = new List<Content>
                    {
                        new Content { Nome = "Conteúdo 1", Tipo = "Vídeo" }
                    }
                };

                await _apiService.AddPlaylistAsync(novaPlaylist);
                await DisplayAlert("Sucesso", "Playlist adicionada", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void OnDeletePlaylistClicked(object sender, EventArgs e)
        {
            try
            {
                int idParaExcluir = 1; // Id da playlist a ser excluída
                await _apiService.DeletePlaylistAsync(idParaExcluir);
                await DisplayAlert("Sucesso", "Playlist excluída", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
