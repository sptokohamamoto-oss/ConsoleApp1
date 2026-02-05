using EmployeeClient.Services;
using System.Collections.ObjectModel;
using System.Windows;
using EmployeeClient.Models;
using System.Windows.Controls;

namespace EmployeeClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeeApiService _service = new EmployeeApiService();
        private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            EmployeeGrid.ItemsSource = _employees;
            LoadEmployees();
        }
        private async void LoadEmployees()
        {
            var list = await _service.GetAllAsync();
            _employees.Clear();
            foreach (var emp in list)
            {
                _employees.Add(emp);
            }
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var emp = new Employee
            {
                Name = NameTextBox.Text,
                Department = DepartmentTextBox.Text,
                HireDate = HireDatePicker.SelectedDate

            };

            await _service.AddAsync(emp);
            LoadEmployees();
            ClearInputs();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is not Employee selected)
                return;

            selected.Name = NameTextBox.Text;
            selected.Department = DepartmentTextBox.Text;
            selected.HireDate = HireDatePicker.SelectedDate;


            await _service.UpdateAsync(selected);
                LoadEmployees();
        }
        
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is not Employee selected)
                return;

            await _service.DeleteAsync(selected.Id);
            LoadEmployees();
            ClearInputs();
        }
        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployees();
        }

        private void EmployeeGrid_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee emp)
            {
                NameTextBox.Text = emp.Name;
                DepartmentTextBox.Text = emp.Department;
                HireDatePicker.SelectedDate = emp.HireDate;
            }

        }
        private void ClearInputs()
        {
            NameTextBox.Text = "";
            DepartmentTextBox.Text = "";
            HireDatePicker.SelectedDate = null;
        }

    }
}
