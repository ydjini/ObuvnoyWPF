using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObuvnoyWPF.Services
{
    public class MessageManager
    {
        public void Error(string description)
        {
            MessageBox.Show(description, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void Success(string description)
        {
            MessageBox.Show(description, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void Warning(string description)
        {
            MessageBox.Show(description, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
