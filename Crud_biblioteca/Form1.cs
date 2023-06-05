namespace Crud_biblioteca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar()
        {
            dsBibliotecaTableAdapters.librosTableAdapter tabla = new dsBibliotecaTableAdapters.librosTableAdapter();
            dsBiblioteca.librosDataTable datos = tabla.GetData();
            dataGridView1.DataSource = datos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLibros frm = new FrmLibros();
            frm.ShowDialog();
            Mostrar();
        }

        private int? ObtenerId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int? id= ObtenerId();
            if(id != null)
            {
                FrmLibros frm = new FrmLibros(id);
                frm.ShowDialog();
                Mostrar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id= ObtenerId();

            if (id != null)
            {
                DialogResult resultado = MessageBox.Show("Estas seguro que deseas eliminar el registro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)

                {
                    dsBibliotecaTableAdapters.librosTableAdapter tabla = new dsBibliotecaTableAdapters.librosTableAdapter();
                    tabla.Eliminar((int)id);
                    Mostrar();
                }
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}