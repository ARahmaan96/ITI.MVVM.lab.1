using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EMS.Models
{
    public enum Gender { Male, Female }
    public class Employee
    {
        public BitmapImage? BitmapImage { get; set; }
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        // public string? Image { get; set; }
        // public string? Image { get; set; }


        private string? _image;
        public string? Image
        {
            get { return _image; }
            set
            {
                if (value != null)
                {
                    if (!Path.IsPathRooted(value))
                    {
                        value = Path.Combine(Directory.GetCurrentDirectory(), value);
                    }
                }
                _image = value;
            }
        }


    }
}
