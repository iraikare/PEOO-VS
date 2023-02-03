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
    /// Lógica interna para Cadastrar_Dep_UniWindow.xaml
    /// </summary>
    public partial class Cadastrar_Dep_UniWindow : Window
    {
        public Cadastrar_Dep_UniWindow()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        { 
            listUniversidades.ItemsSource = null;
            listUniversidades.ItemsSource = NUniversidades.Listar();
            listDepartamentos.ItemsSource = null;
            listDepartamentos.ItemsSource = NDepartamento.Listar();
        }

        private void CadastrarClick(object sender, RoutedEventArgs e)
        {
            if (listUniversidades.SelectedItem != null && listDepartamentos.SelectedItem != null)
            {
                Departamento d = (Departamento)listDepartamentos.SelectedItem;
                Universidade u = (Universidade)listUniversidades.SelectedItem;
                NDepartamento.CadastrarDepartamento(d, u);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um departamento e uma universidade");
            }
        }
    }
}
