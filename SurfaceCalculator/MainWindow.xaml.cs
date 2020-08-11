using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SurfaceCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<FormDescription> FormDescriptions { get; set; } = new ObservableCollection<FormDescription>();
        public ObservableCollection<Form> Forms { get; set; } = new ObservableCollection<Form>();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var t in types)
            {
                FormDescriptions.Add(new FormDescription(t.Name));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            double a;
            double b;

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract);

            if (Double.TryParse(ATextBox.Text, out a) && Double.TryParse(BTextBox.Text, out b) && FormComboBox.SelectedIndex != -1)
            {
                foreach (var t in types)
                {
                    if ((FormComboBox.SelectedItem as FormDescription).Name == t.Name)
                    {
                        var form = t?.GetConstructor(Type.EmptyTypes)?.Invoke(null) as Form;

                        form.A = a;
                        form.B = b;
                        Forms.Add(form);
                        UpdateTotal();
                    }
                }
            }
        }

        private void UpdateTotal()
        {
            double tot = 0;
            foreach(var f in Forms)
            {
                tot += f.Surface;
            }
            TotalTextBlock.Text = tot.ToString();
        }
    }
}
