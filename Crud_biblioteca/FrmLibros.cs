using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_biblioteca
{
    public partial class FrmLibros : Form
    {
        private int? id;
        public FrmLibros(int? id=null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmLibros_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                dsBibliotecaTableAdapters.librosTableAdapter tabla = new dsBibliotecaTableAdapters.librosTableAdapter();
                dsBiblioteca.librosDataTable data= tabla.MostrarDatosId((int)id);
                dsBiblioteca.librosRow row = (dsBiblioteca.librosRow)data.Rows[0];
                txtTitulo.Text = row.titulo;
                txtAutor.Text = row.autor;
                txtEditorial.Text = row.editorial;
                txtAnio.Value = row.anio;
                txtEdicion.Text = row.edicion;
                txtVolumen.Value = row.volumen;
                txtNumVolumen.Value = row.num_volumenes;
                txtGenero.Text = row.genero;
                txtEstado.Text = row.estado;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsBibliotecaTableAdapters.librosTableAdapter tabla = new dsBibliotecaTableAdapters.librosTableAdapter();
            if (id == null)
            {
                tabla.Agregar(txtTitulo.Text.Trim(), txtAutor.Text, txtEditorial.Text, (int)txtAnio.Value, txtEdicion.Text, (int)txtVolumen.Value, (int)txtNumVolumen.Value, txtGenero.Text, txtEstado.Text);
            } else
            {
                tabla.Editar(txtTitulo.Text.Trim(), txtAutor.Text, txtEditorial.Text, (int)txtAnio.Value, txtEdicion.Text, (int)txtVolumen.Value, (int)txtNumVolumen.Value, txtGenero.Text, txtEstado.Text, (int)id);
            }

            this.Close();
        }
    }
}
