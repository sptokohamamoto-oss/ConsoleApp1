using Refit;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using TodoApp.Client.Services;
using TodoApp.Client.ViewModels;

namespace TodoApp.Client
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var todoApi = RestService.For<ITodoApi>(
                new HttpClient { BaseAddress = new Uri("https://localhost:7200") },
                new RefitSettings
                {
                    ContentSerializer = new SystemTextJsonContentSerializer(
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        })
                });

            var mainWindow = new Views.MainWindow
            {
                DataContext = new MainViewModel(todoApi)
            };

            mainWindow.Show();
        }
    }
}