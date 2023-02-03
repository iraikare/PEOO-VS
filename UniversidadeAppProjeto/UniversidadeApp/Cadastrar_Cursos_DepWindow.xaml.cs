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
    /// Lógica interna para Cadastrar_Cursos_DepWindow.xaml
    /// </summary>
    public partial class Cadastrar_Cursos_DepWindow : Window
    {
        public Cadastrar_Cursos_DepWindow()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listDepartamentos.ItemsSource = null;
            listDepartamentos.ItemsSource = NDepartamento.Listar();
            listCursos.ItemsSource = null;
            listCursos.ItemsSource = NCurso.Listar();
        }

        private void CadastrarClick(object sender, RoutedEventArgs e)
        {
            if (listDepartamentos.SelectedItem != null && listCursos.SelectedItem != null)
            {
                Curso c = (Curso)listCursos.SelectedItem;
                Departamento d = (Departamento)listDepartamentos.SelectedItem;
                NCurso.CadastrarCurso(c, d);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um curso e um departamento");
            }
        }
    }
}
