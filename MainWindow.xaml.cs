using System;
using System.Windows;
using System.Windows.Controls;
using Lab_2_2.Exceptions;
using Lab_2_2.Models;

namespace Lab_2_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ShotService _shotService;

        public MainWindow()
        {
            InitializeComponent();
            _shotService = new ShotService();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var xCoord = GetNumberFromTextBox(x);
            var yCoord = GetNumberFromTextBox(y);

            try
            {
                var result = _shotService.MakeShot(new Point(xCoord, yCoord));
                ListBox.Items.Add($"{GetResultMessage(result)} in ({xCoord.ToString()},{yCoord.ToString()})");
            }
            catch (TooManyShotsException exception)
            {
                ShowMessage(
                    $"You've tried to make more shots than available.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private static string GetResultMessage(bool result)
        {
            return result ? "Success" : "FAIL";
        }

        private static double GetNumberFromTextBox(TextBox textBox)
        {
            var safeString = textBox.Text.Contains('.') ? textBox.Text.Replace('.', ',') : textBox.Text;
            try
            {
                return double.Parse(safeString);
            }
            catch (FormatException e)
            {
                ShowMessage(
                    $"It isn't number",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }

            return 0;
        }

        private void OnRestart(object sender, RoutedEventArgs e)
        {
            _shotService.Restart();
            ListBox.Items.Clear();
        }

        private static MessageBoxResult ShowMessage(string message, string caption, MessageBoxButton button,
            MessageBoxImage image)
        {
            return MessageBox.Show(
                message,
                caption,
                button,
                image);
        }
    }
}