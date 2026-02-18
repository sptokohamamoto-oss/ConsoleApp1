using System.ComponentModel;
using System.Runtime.CompilerServices;
using TodoApp.Client.Models;

namespace TodoApp.Client.ViewModels
{
    //ToDo登録・編集ダイアログ用ViewModel
    //画面入力値をTodoItemモデルへバインドする役割を持つ
    public class TodoDialogViewModel : INotifyPropertyChanged
    {
        //編集対象のToDoデータ
        public TodoItem Item { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        //編集対象のTodoitemを受け取るコンストラクタ
        public TodoDialogViewModel(TodoItem item)
        {
            Item = item;
        }

        //タイトル
        public string Title
        {
            get => Item.Title;
            set { Item.Title = value; OnPropertyChanged(); }
        }

        //詳細説明
        public string? Description
        {
            get => Item.Description;
            set { Item.Description = value; OnPropertyChanged(); }
        }

        //期日
        public DateTime? DueDate
        {
            get => Item.DueDate;
            set { Item.DueDate = value; OnPropertyChanged(); }
        }

        //優先度
        public int Priority
        {
            get => Item.Priority;
            set { Item.Priority = value; OnPropertyChanged(); }
        }

        //プロパティ変更通知
        //UIへリアルタイムに更新を反映する
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}