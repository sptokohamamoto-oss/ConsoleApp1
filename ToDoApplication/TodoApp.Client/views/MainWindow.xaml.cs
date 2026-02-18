using Refit;
using System.Windows;
using System.Windows.Controls;
using TodoApp.Client.Services;
using TodoApp.Client.ViewModels;

namespace TodoApp.Client.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // API クライアント生成
            var todoApi = RestService.For<ITodoApi>("https://localhost:7200");

            // ViewModel を生成して DataContext に設定
            var vm = new MainViewModel(todoApi);
            this.DataContext = vm;

            // 起動時に一覧を読み込む
            Loaded += async (_, __) => await vm.LoadAsync();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}