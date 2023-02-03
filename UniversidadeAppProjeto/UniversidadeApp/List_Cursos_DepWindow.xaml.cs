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
    /// Lógica interna para List_Cursos_DepWindow.xaml
    /// </summary>
    public partial class List_Cursos_DepWindow : Window
    {
        public List_Cursos_DepWindow()
        {
            InitializeComponent();
            listDepartamentos.ItemsSource = NDepartamento.Listar();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            if (listDepartamentos.SelectedItem != null)
            {
                Departamento d = (Departamento)listDepartamentos.SelectedItem;
                listCursos.ItemsSource = null;
                listCursos.ItemsSource = NCurso.Listar(d);
            }
            else
                MessageBox.Show("É preciso selecionar um Departamento");
        }
    }
}
