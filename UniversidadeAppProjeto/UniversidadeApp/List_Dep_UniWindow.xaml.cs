using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace UniversidadeApp
{
    /// <summary>
    /// Lógica interna para List_Dep_UniWindow.xaml
    /// </summary>
    public partial class List_Dep_UniWindow : Window
    {
        public List_Dep_UniWindow()
        {
            InitializeComponent();
            listUniversidades.ItemsSource = NUniversidades.Listar();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            if (listUniversidades.SelectedItem != null)
            {
                Universidade u = (Universidade)listUniversidades.SelectedItem;
                listDepartamentos.ItemsSource = null;
                listDepartamentos.ItemsSource = NDepartamento.Listar(u);
            }
            else
                MessageBox.Show("É preciso selecionar uma Universidade");
        }
    }
}
