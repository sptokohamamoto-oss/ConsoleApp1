using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoApp.Client.Infrastructure;
using TodoApp.Client.Models;
using TodoApp.Client.Services;

namespace TodoApp.Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ITodoApi _todoApi;

        public ObservableCollection<TodoItem> TodoItems { get; } = new();

        private TodoItem? _selectedItem;
        public TodoItem? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        private string _selectedFilter = "All";

        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                _selectedFilter = value;
                OnPropertyChanged();
                _ = LoadAsync(); 
            }
        }

        // :star: ステータスバー用プロパティ
        public int CompletedCount => TodoItems.Count(t => t.IsCompleted);
        public int ActiveCount => TodoItems.Count(t => !t.IsCompleted);

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ToggleCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(ITodoApi todoApi)
        {
            _todoApi = todoApi;

            LoadCommand = new RelayCommand(async () => await LoadAsync());
            AddCommand = new RelayCommand(async () => await OnAddAsync());
            EditCommand = new RelayCommand(async () => await OnEditAsync());
            DeleteCommand = new RelayCommand(async () => await OnDeleteAsync());
            ToggleCommand = new RelayCommand(async () => await OnToggleAsync());
        }

        // 一覧取得
        public async Task LoadAsync()
        {
            bool? filter = SelectedFilter switch
            {
                "Active" => false,
                "Completed" => true,
                _ => null
            };

            var items = await _todoApi.GetAllAsync(filter);

            TodoItems.Clear();
            foreach (var item in items)
                TodoItems.Add(item);

            OnPropertyChanged(nameof(CompletedCount));
            OnPropertyChanged(nameof(ActiveCount));
        }


        // 新規登録
        private async Task OnAddAsync()
        {
            var vm = new TodoDialogViewModel(new TodoItem());
            var dialog = new Views.TodoDialog { DataContext = vm };

            if (dialog.ShowDialog() == true)
                await CreateAsync(vm.Item);
        }
        
        // 編集
        private async Task OnEditAsync()
        {
            if (SelectedItem == null) return;

            var clone = new TodoItem
            {
                Id = SelectedItem.Id,
                Title = SelectedItem.Title,
                Description = SelectedItem.Description,
                DueDate = SelectedItem.DueDate,
                Priority = SelectedItem.Priority,
                IsCompleted = SelectedItem.IsCompleted
            };

            var vm = new TodoDialogViewModel(clone);
            var dialog = new Views.TodoDialog { DataContext = vm };

            if (dialog.ShowDialog() == true)
                await UpdateAsync(vm.Item);
        }

        // 削除
        private async Task OnDeleteAsync()
        {
            if (SelectedItem == null) return;

            await _todoApi.DeleteAsync(SelectedItem.Id);
            TodoItems.Remove(SelectedItem);

            UpdateCounts();
        }

        // 完了切替
        private async Task OnToggleAsync()
        {
            if (SelectedItem == null) return;

            SelectedItem.IsCompleted = !SelectedItem.IsCompleted;
            await _todoApi.UpdateAsync(SelectedItem.Id, SelectedItem);

            UpdateCounts();
        }

        // 登録処理
        private async Task CreateAsync(TodoItem item)
        {
            var created = await _todoApi.CreateAsync(item);
            TodoItems.Add(created);

            UpdateCounts();
        }

        // 更新処理
        private async Task UpdateAsync(TodoItem item)
        {
            await _todoApi.UpdateAsync(item.Id, item);

            var existing = TodoItems.FirstOrDefault(t => t.Id == item.Id);
            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.DueDate = item.DueDate;
                existing.Priority = item.Priority;
                existing.IsCompleted = item.IsCompleted;
            }

            UpdateCounts();
        }

        // 件数更新通知
        private void UpdateCounts()
        {
            OnPropertyChanged(nameof(CompletedCount));
            OnPropertyChanged(nameof(ActiveCount));
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}