using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace responsi
{
    public partial class Form1 : Form
    {
        private KaryawanHelper karyawanHelper;
        private ReferensiHelper referensiHelper;

        public Form1()
        {
            InitializeComponent();
            karyawanHelper = new KaryawanHelper();
            referensiHelper = new ReferensiHelper();
            LoadData();
            LoadDepartemen();
            LoadJabatan();
        }

        // Add button click event
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int depId = Convert.ToInt32(comboBox2.SelectedValue);
            int jabatanId = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                karyawanHelper.InsertKaryawan(name, depId, jabatanId);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data: " + ex.Message);
            }
        }

        // Edit button click event
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Get the selected employee ID
                string name = textBox1.Text;
                int depId = Convert.ToInt32(comboBox2.SelectedValue);
                int jabatanId = Convert.ToInt32(comboBox1.SelectedValue);

                try
                {
                    karyawanHelper.EditKaryawan(id, name, depId, jabatanId);
                    LoadData(); // Refresh the DataGridView after update
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        // Delete button click event
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Get the selected employee ID

                try
                {
                    karyawanHelper.DeleteKaryawan(id);
                    LoadData(); // Refresh the DataGridView after deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }

        // Function to load data from PostgreSQL and bind to DataGridView
        private void LoadData()
        {
            try
            {
                DataTable dt = karyawanHelper.LoadKaryawan();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // Load Departemen data into ComboBox
        private void LoadDepartemen()
        {
            try
            {
                DataTable dt = referensiHelper.LoadDepartemen();
                comboBox2.DisplayMember = "department_name";
                comboBox2.ValueMember = "id_dep";
                comboBox2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Departemen: " + ex.Message);
            }
        }

        // Load Jabatan data into ComboBox
        private void LoadJabatan()
        {
            try
            {
                DataTable dt = referensiHelper.LoadJabatan();
                comboBox1.DisplayMember = "position_name";
                comboBox1.ValueMember = "id_jabatan";
                comboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Jabatan: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
