using EMS.Models;
using EMS.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;

namespace EMS.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private HomeViewModel viewModel;
        public Home()
        {
            viewModel = new HomeViewModel();
            InitializeComponent();

            this.DataContext = viewModel;
            Loaded += HomeWindow_loaded;
        }

        private void HomeWindow_loaded(object sender, RoutedEventArgs e)
        {
            viewModel.onLoad();
        }

        private void ClearFormHandler(object sender, RoutedEventArgs e)
        {
            viewModel.SelectedEmployee = new();
        }

        private void AddFormHandler(object sender, RoutedEventArgs e)
        {
            string id = Guid.NewGuid().ToString();
            viewModel.Employees.Insert(0, new Employee() { Id = id });
            viewModel.SelectedEmployee = viewModel.Employees.FirstOrDefault();

        }

        private void changeImageHandler(object sender, RoutedEventArgs e)
        {
            viewModel.changeImageHandler();

        }

        private void DeleteFormHandler(object sender, RoutedEventArgs e)
        {

            if (viewModel.SelectedEmployee != null)
            {
                int selectedIndex = viewModel.Employees.IndexOf(viewModel.SelectedEmployee);
                viewModel.Employees.Remove(viewModel.SelectedEmployee);

                if (viewModel.Employees.Count > 0)
                {
                    viewModel.SelectedEmployee = selectedIndex < viewModel.Employees.Count ? viewModel.Employees[selectedIndex] : viewModel.Employees[0];
                }
                else
                {
                    viewModel.SelectedEmployee = null;
                }
            }
        }
    }
}
