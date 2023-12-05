using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagmentApp
{
    public partial class Enseignant : Form
    {
        public LinkToSqlDataContext dbContext;
        public int selectedLevel;
        public Enseignant()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


        }

        private void Enseignant_Load(object sender, EventArgs e)
        {
            dbContext = new LinkToSqlDataContext(new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"));

            var classes = from c in dbContext.Levels select c.name;
            foreach (var c in classes)
            {
                comboBox1.Items.Add(c);
            }

        }



        //generer tous les etudiants (enseignait trombinoscope)
        private void button13_Click(object sender, EventArgs e)
        {
            // get the data from table Etudiants 
            List<Etudiant> etudiantsList = dbContext.Etudiants.ToList();

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Add a new worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Etudiants");

                // Add headers to the worksheet
                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "CNE";
                worksheet.Cells["C1"].Value = "Nom";
                worksheet.Cells["D1"].Value = "Prenom";
                worksheet.Cells["E1"].Value = "Sexe";
                worksheet.Cells["F1"].Value = "Date_Naissance";
                worksheet.Cells["G1"].Value = "Adresse";
                worksheet.Cells["H1"].Value = "Email";
                worksheet.Cells["I1"].Value = "Telephone";
                worksheet.Cells["J1"].Value = "Filiere";
                worksheet.Cells["K1"].Value = "Level";
                // Add other headers for the remaining columns...

                // add data to the excel file starting from the second row
                int row = 2;
                foreach (Etudiant etudiant in etudiantsList)
                {
                    worksheet.Cells[$"A{row}"].Value = etudiant.id;
                    worksheet.Cells[$"B{row}"].Value = etudiant.cne;
                    worksheet.Cells[$"C{row}"].Value = etudiant.nom;
                    worksheet.Cells[$"D{row}"].Value = etudiant.prenom;
                    worksheet.Cells[$"E{row}"].Value = etudiant.sexe;
                    worksheet.Cells[$"F{row}"].Value = etudiant.date_naiss;
                    worksheet.Cells[$"G{row}"].Value = etudiant.adress;
                    worksheet.Cells[$"H{row}"].Value = etudiant.email;
                    worksheet.Cells[$"I{row}"].Value = etudiant.telephone;
                    worksheet.Cells[$"J{row}"].Value = etudiant.id_filiere;
                    worksheet.Cells[$"K{row}"].Value = etudiant.id_level;

                    row++;
                }

                // Save the Excel file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                    MessageBox.Show("Excel file generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //generer tous les email etudiants (enseignait trombinoscope)
        private void button2_Click(object sender, EventArgs e)
        {
            // get the data from table Etudiants (les emails des etudiants de la classe selectionnee)
            var etudiantsList = (from et in dbContext.Etudiants where et.id_level == selectedLevel select new { et.id, et.nom, et.prenom, et.email }).ToList();

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                // Add a new worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Etudiants_Emails");

                // Add headers to the worksheet
                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Nom";
                worksheet.Cells["C1"].Value = "Prenom";
                worksheet.Cells["D1"].Value = "Email";
                // Add other headers for the remaining columns...

                // add data to the excel file starting from the second row
                int row = 2;
                foreach (var etudiant in etudiantsList)
                {
                    worksheet.Cells[$"A{row}"].Value = etudiant.id;
                    worksheet.Cells[$"C{row}"].Value = etudiant.nom;
                    worksheet.Cells[$"C{row}"].Value = etudiant.prenom;
                    worksheet.Cells[$"D{row}"].Value = etudiant.email;
                    row++;
                }

                // Save the Excel file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Excel File"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                    MessageBox.Show("Excel file generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLevel = comboBox1.SelectedIndex + 1;
        }


        //tab etudiant in enseignant form
        private void button1_Click(object sender, EventArgs e)
        {

            int cne = Convert.ToInt32(textBox1.Text);
            if (cne != 0)
            {
                var student = from s in dbContext.Etudiants
                              from f in dbContext.Filieres
                              from l in dbContext.Levels
                              where s.cne == cne & s.id_filiere == f.id & s.id_level == l.id
                              select new { s.nom, s.prenom, s.date_naiss, s.adress, s.telephone, f.Nom_filiere, l.name };

                if (student.Count() != 0)
                {
                    var etudiant = student.ToList().ElementAt(0);
                    textBox2.Text = etudiant.nom;
                    textBox3.Text = etudiant.prenom;
                    textBox4.Text = Convert.ToString(etudiant.date_naiss);
                    textBox5.Text = etudiant.adress;
                    textBox6.Text = etudiant.telephone;
                    textBox7.Text = etudiant.Nom_filiere;
                    textBox8.Text = etudiant.name;
                }
                else
                {
                    MessageBox.Show("Ooops, There is no student with this cne");
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataSet2 ds = new DataSet2();

            // Create a connection and command to fetch data from the database
            using (SqlConnection conn = new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"))
            {
                //conn.Open(); // Open the connection

                using (SqlCommand cmd = new SqlCommand($"SELECT CONCAT(nom, ' ', prenom) as full_name, cne FROM ETUDIANTS", conn))
                {
                    // Use SqlDataAdapter to fill the DataTable in the dataset
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds.DataTable1);
                }
            }

            if (ds.DataTable1.Rows.Count > 0)
            {
                // Create a Crystal Report object
                Trombinoscope cs = new Trombinoscope();

                // Set the dataset as the data source for the Crystal Report
                cs.SetDataSource(ds);

                // Set the DataTable from the dataset as the data source for the Crystal Report (in case of multiple tables in the dataset)
                // cs.SetDataSource(ds.DataTable1);

                Form2 reportForm = new Form2();

                // Set the Crystal Report as the report source for the CrystalReportViewer
                reportForm.crystalReportViewer2.ReportSource = cs;
                reportForm.crystalReportViewer2.RefreshReport();
                reportForm.Show();
            }
            else
            {
                // Handle the case when no data is found
                MessageBox.Show("No data found for the specified CNE.");
            }
        }
    }
}
