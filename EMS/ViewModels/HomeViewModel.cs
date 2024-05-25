using EMS.Models;
using Microsoft.Build.Evaluation;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
namespace EMS.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        // Observer Pattern Stuff
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        private Employee? _selectedEmployee;
        public Employee? SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }


        public HomeViewModel()
        {
            // Initialize Employees
            Employees = new();
            SelectedEmployee = new();
        }

        public void onLoad()
        {
            // TODO: Get Data From DB OR API
            Employees.Add(new Employee() { Id = "1", Image = "db/media/1.jpg", Name = "Mohamed", Address = "Alexandria", Age = 30, Phone = "+0201023456789", Gender = Gender.Male, Description = "Works as a software engineer" });
            Employees.Add(new Employee() { Id = "2", Image = "db/media/2.jpg", Name = "Fatma", Address = "Luxor", Age = 28, Phone = "+0201122334455", Gender = Gender.Female, Description = "Teacher at a local school" });
            Employees.Add(new Employee() { Id = "3", Image = "db/media/3.jpg", Name = "Amira", Address = "Aswan", Age = 35, Phone = "+0201234567890", Gender = Gender.Female, Description = "Doctor at a public hospital" });
            Employees.Add(new Employee() { Id = "4", Image = "db/media/4.jpg", Name = "Youssef", Address = "Giza", Age = 40, Phone = "+0201098765432", Gender = Gender.Male, Description = "Owns a small grocery shop" });
            Employees.Add(new Employee() { Id = "5", Image = "db/media/5.jpg", Name = "Nour", Address = "Sharm El Sheikh", Age = 26, Phone = "+0201987654321", Gender = Gender.Female, Description = "Tour guide at a resort" });
            Employees.Add(new Employee() { Id = "6", Image = "db/media/6.jpg", Name = "Ali", Address = "Hurghada", Age = 33, Phone = "+0201765432109", Gender = Gender.Male, Description = "Fisherman by profession" });
            Employees.Add(new Employee() { Id = "7", Image = "db/media/7.jpg", Name = "Sara", Address = "Mansoura", Age = 29, Phone = "+0201654321098", Gender = Gender.Female, Description = "Works as a pharmacist" });
            Employees.Add(new Employee() { Id = "8", Image = "db/media/8.jpg", Name = "Khaled", Address = "Suez", Age = 45, Phone = "+0201987654321", Gender = Gender.Male, Description = "Civil engineer" });
            Employees.Add(new Employee() { Id = "9", Image = "db/media/9.jpg", Name = "Aya", Address = "Port Said", Age = 27, Phone = "+0201765432109", Gender = Gender.Female, Description = "Graphic designer" });
            Employees.Add(new Employee() { Id = "10", Image = "db/media/10.jpg", Name = "Hassan", Address = "Tanta", Age = 38, Phone = "+0201876543210", Gender = Gender.Male, Description = "Owner of a local restaurant" });
            Employees.Add(new Employee() { Id = "11", Image = "db/media/2.jpg", Name = "Nadia", Address = "Ismailia", Age = 31, Phone = "+0201765432109", Gender = Gender.Female, Description = "Accountant at a construction company" });
            Employees.Add(new Employee() { Id = "12", Image = "db/media/3.jpg", Name = "Amr", Address = "Damanhour", Age = 34, Phone = "+0201654321098", Gender = Gender.Male, Description = "Police officer" });
            Employees.Add(new Employee() { Id = "13", Image = "db/media/4.jpg", Name = "Reham", Address = "Zagazig", Age = 32, Phone = "+0201987654321", Gender = Gender.Female, Description = "Journalist" });
            Employees.Add(new Employee() { Id = "14", Image = "db/media/5.jpg", Name = "Mahmoud", Address = "Damietta", Age = 37, Phone = "+0201765432109", Gender = Gender.Male, Description = "Electrician" });
            Employees.Add(new Employee() { Id = "15", Image = "db/media/6.jpg", Name = "Yara", Address = "Banha", Age = 25, Phone = "+0201876543210", Gender = Gender.Female, Description = "Student studying medicine" });
            Employees.Add(new Employee() { Id = "16", Image = "db/media/7.jpg", Name = "Hesham", Address = "Sohag", Age = 42, Phone = "+0201765432109", Gender = Gender.Male, Description = "High school teacher" });
            Employees.Add(new Employee() { Id = "17", Image = "db/media/8.jpg", Name = "Mona", Address = "Beni Suef", Age = 36, Phone = "+0201654321098", Gender = Gender.Female, Description = "Dentist" });
            Employees.Add(new Employee() { Id = "18", Image = "db/media/9.jpg", Name = "Tarek", Address = "Kafr El Sheikh", Age = 39, Phone = "+0201987654321", Gender = Gender.Male, Description = "Mechanical engineer" });
            Employees.Add(new Employee() { Id = "19", Image = "db/media/10.jpg", Name = "Heba", Address = "Marsa Matruh", Age = 28, Phone = "+0201765432109", Gender = Gender.Female, Description = "Tourism manager" });
            Employees.Add(new Employee() { Id = "20", Image = "db/media/1.jpg", Name = "Walid", Address = "Qena", Age = 43, Phone = "+0201876543210", Gender = Gender.Male, Description = "Owner of a car repair shop" });
        }


        public void changeImageHandler()
        {
            if (SelectedEmployee != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.png;*.jpg";
                if (openFileDialog.ShowDialog() == true)
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationDirectory = Path.Combine("db", "media");
                    string destinationPath = Path.Combine(destinationDirectory, fileName);

                    //pack://application:,,,/AssemblyName;component/

                    try
                    {
                        if (!Directory.Exists(destinationDirectory))
                        {
                            Directory.CreateDirectory(destinationDirectory);
                        }

                        File.Copy(sourceFilePath, destinationPath, true);
                        string relativePath = Path.Combine("db", "media", fileName);

                        var currentDirectory = Directory.GetCurrentDirectory();

                        SelectedEmployee.Image = $"{currentDirectory}\\{relativePath}";

                        OnPropertyChanged(nameof(SelectedEmployee));

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error copying image: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose or add an employee first", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
