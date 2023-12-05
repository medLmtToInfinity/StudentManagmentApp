using CrystalDecisions.Shared;
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

namespace StudentManagmentApp
{
    public partial class Form1 : Form
    {
        LinkToSqlDataContext _db;
        //declarer la filiere qu'on va afficher lorsque l'utilisateur clique sur dataGridView:
        public Filiere filiereToBeEdited;
        List<Etudiant> eds;
        List<int> ids = new List<int>();
        int Cne;
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sMA_dbDataSet4.Filieres' table. You can move, or remove it, as needed.
            this.filieresTableAdapter3.Fill(this.sMA_dbDataSet4.Filieres);
            // TODO: This line of code loads data into the 'sMA_dbDataSet3.Filieres' table. You can move, or remove it, as needed.
            this.filieresTableAdapter2.Fill(this.sMA_dbDataSet3.Filieres);
            // TODO: This line of code loads data into the 'sMA_dbDataSet2.Filieres' table. You can move, or remove it, as needed.
            this.filieresTableAdapter1.Fill(this.sMA_dbDataSet2.Filieres);
            // TODO: This line of code loads data into the 'sMA_dbDataSet1.Filieres' table. You can move, or remove it, as needed.
            this.filieresTableAdapter.Fill(this.sMA_dbDataSet1.Filieres);
            // Med Code
            this._db = new LinkToSqlDataContext(new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"));
            StatisticDataSet sds = new StatisticDataSet();

            // Create a connection and command to fetch data from the database
            using (SqlConnection conn = new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"))
            {
                conn.Open(); // Open the connection

                using (SqlCommand cmd = new SqlCommand($"SELECT e.id AS student_id, f.nom_filiere FROM Filieres f LEFT JOIN Etudiants e ON f.id = e.id_filiere ORDER BY f.id, e.id;", conn))
                {
                    // Use SqlDataAdapter to fill the DataTable in the dataset
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(sds.DataTable1);
                }
            }

            if (sds.DataTable1.Rows.Count > 0)
            {
                // Create a Crystal Report object
                Statistics cs = new Statistics();

                // Set the dataset as the data source for the Crystal Report
                cs.SetDataSource(sds);


                // Set the Crystal Report as the report source for the CrystalReportViewer
                crystalReportViewer1.ReportSource = cs;
                crystalReportViewer1.RefreshReport();
            }
            else
            {
                // Handle the case when no data is found
                MessageBox.Show("No data found for the specified CNE.");
            }

            // TODO: This line of code loads data into the 'sMA_dbDataSet.Etudiants' table. You can move, or remove it, as needed.
            //this.etudiantsTableAdapter.Fill(this.sMA_dbDataSet.Etudiants);
            //this.filieresTableAdapter.Fill(this.sMA_dbDataSet3.Filieres);

            //added nv to cmbx levels
            var niveaus = from nv in _db.Levels select nv.name;
            foreach (var nv in niveaus)
            { comboBox1.Items.Add(nv); }

            //added nv to cmbx filieres
            var frs = from fr in _db.Filieres select fr.Nom_filiere;
            foreach (var fr in frs)
            { comboBox4.Items.Add(fr); }

        }


        

        

        //Add a Field to db

        private void button1_Click(object sender, EventArgs e)
        {
            string nom_filiere = textBox1.Text;
            if (nom_filiere != null)
            {

                var id_filiere = (_db.Filieres
                                .OrderByDescending(f => f.id)
                                .FirstOrDefault()).id + 1;
                Filiere AddedFiliere = new Filiere
                {
                    id = id_filiere,
                    Nom_filiere = nom_filiere,
                };

                _db.Filieres.InsertOnSubmit(AddedFiliere);

                try
                {
                    _db.SubmitChanges();
                    MessageBox.Show("Data inserted into Filieres table successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //******************************* Filiere Tab ****************************************
        //Get selected Field into the input
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the clicked row
            DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];

            // Access data in the clicked row
            string filiere_nom = clickedRow.Cells["Nom_Filiere"].Value.ToString();
            int id = Convert.ToInt32(clickedRow.Cells["id_filiere"].Value);

            filiereToBeEdited = _db.Filieres
                    .OrderByDescending(f => f.id == id)
                    .FirstOrDefault();



            // Display the clicked Nom_filiere
            textBox1.Text = filiere_nom;
        }

        //Modify a Field
        private void button2_Click(object sender, EventArgs e)
        {
            filiereToBeEdited.Nom_filiere = textBox1.Text;


            //submit the changes:
            try
            {
                _db.SubmitChanges();
                MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //delete a Field to db
        private void button3_Click(object sender, EventArgs e)
        {
            _db.Filieres.DeleteOnSubmit(filiereToBeEdited);

            try
            {
                _db.SubmitChanges();
                MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid1();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //****************************** Etudiant Tab ***********************************

        private void UpdateGrid()
        {
            int selectLevel = comboBox1.SelectedIndex + 1;

            var etudiants = from ed in _db.Etudiants
                            where ed.id_level == selectLevel
                            select ed;


            eds = etudiants.ToList();
            dataGridView2.DataSource = eds;
        }

        private void UpdateGrid1() {
            var filieres = from f in _db.Filieres
                            select f;


            List<Filiere> fl = filieres.ToList();
            dataGridView1.DataSource = fl;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            var etudiants = from ed in _db.Etudiants where ed.id_level == comboBox1.SelectedIndex + 1 select ed;
            ids.Clear();

            comboBox2.Items.Clear();
            foreach (var ed in etudiants)
            {
                ids.Add(ed.id);
                comboBox2.Items.Add(ed.prenom + " " + ed.nom);
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String[] nom = comboBox2.SelectedItem.ToString().Split(' ');

            var etudiants = from ed in _db.Etudiants
                            where ed.id_level == comboBox1.SelectedIndex + 1 && ed.id == ids[comboBox2.SelectedIndex]
                            select ed;


            this.dataGridView2.DataSource = etudiants.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //added data level in datagridview
            if (comboBox1.SelectedIndex == -1) { MessageBox.Show("Vous devez selectioner une class!"); }


            UpdateGrid();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|.xls;.xlsx;*.xlsm",
                Title = "Select an Excel file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {

                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first worksheet

                    DataTable dataTable = new DataTable();

                    // Assuming your Excel columns match the Etudiants table columns
                    dataTable.Columns.Add("id", typeof(int));
                    dataTable.Columns.Add("cne", typeof(string));
                    dataTable.Columns.Add("nom", typeof(string));
                    dataTable.Columns.Add("prenom", typeof(string));
                    dataTable.Columns.Add("sexe", typeof(string));
                    dataTable.Columns.Add("date_naiss", typeof(DateTime));
                    dataTable.Columns.Add("adress", typeof(string));
                    dataTable.Columns.Add("email", typeof(string));
                    dataTable.Columns.Add("telephone", typeof(string));
                    dataTable.Columns.Add("id_filiere", typeof(int));
                    dataTable.Columns.Add("id_level", typeof(int));

                    // Assuming your data starts from the second row (row index 2)
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        DataRow dataRow = dataTable.NewRow();

                        // Assuming your Excel columns match the Etudiants table columns
                        dataRow["id"] = int.Parse(worksheet.Cells[row, 1].Text);
                        dataRow["cne"] = worksheet.Cells[row, 2].Text;
                        dataRow["nom"] = worksheet.Cells[row, 3].Text;
                        dataRow["prenom"] = worksheet.Cells[row, 4].Text;
                        dataRow["sexe"] = worksheet.Cells[row, 5].Text;
                        dataRow["date_naiss"] = DateTime.Parse(worksheet.Cells[row, 6].Text);
                        dataRow["adress"] = worksheet.Cells[row, 7].Text;
                        dataRow["email"] = worksheet.Cells[row, 8].Text;
                        dataRow["telephone"] = worksheet.Cells[row, 9].Text;
                        dataRow["id_filiere"] = int.Parse(worksheet.Cells[row, 10].Text);
                        dataRow["id_level"] = int.Parse(worksheet.Cells[row, 11].Text);

                        dataTable.Rows.Add(dataRow);
                    }

                    // Now you have the data in a DataTable, you can use it to insert into your Etudiants table
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Etudiant etudiant = new Etudiant
                        {
                            id = Convert.ToInt32(row["id"]),
                            cne = Convert.ToInt32(row["cne"]),
                            nom = row["nom"].ToString(),
                            prenom = row["prenom"].ToString(),
                            sexe = Convert.ToChar(row["sexe"]),
                            date_naiss = Convert.ToDateTime(row["date_naiss"]),
                            adress = row["adress"].ToString(),
                            email = row["email"].ToString(),
                            telephone = row["telephone"].ToString(),
                            id_filiere = Convert.ToInt32(row["id_filiere"]),
                            id_level = Convert.ToInt32(row["id_level"])
                        };

                        _db.Etudiants.InsertOnSubmit(etudiant);
                    }

                    try
                    {
                        _db.SubmitChanges();
                        MessageBox.Show("Data inserted into Etudiants table successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inserting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    // InsertDataIntoEtudiantsTable(dataTable);
                }

                MessageBox.Show("Import successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = eds.OrderBy(ed => ed.nom).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = eds.OrderByDescending(ed => ed.nom).ToList();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
            Cne = Convert.ToInt32(selectedRow.Cells["cne_1"].Value);
            textBox2.Text = Convert.ToString(selectedRow.Cells["cne_1"].Value);
            textBox3.Text = Convert.ToString(selectedRow.Cells["nom"].Value);
            textBox4.Text = Convert.ToString(selectedRow.Cells["prenom"].Value);

            if (Convert.ToChar(selectedRow.Cells["sexe"].Value) == 'F')
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            textBox5.Text = Convert.ToString(selectedRow.Cells["adress"].Value);
            dateBox.Text = Convert.ToString(selectedRow.Cells["date_naiss"].Value);
            textBox6.Text = Convert.ToString(selectedRow.Cells["telephone"].Value);


            comboBox4.Text = (from f in _db.Filieres
                              where f.id == Convert.ToInt32(selectedRow.Cells["id_filiere_1"].Value)
                              select f).SingleOrDefault()?.Nom_filiere;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char Sexe = 'M';
            if (radioButton1.Checked) { Sexe = 'F'; }
            //int Id = (dtContext.Etudiants.OrderByDescending(ed => ed.id).FirstOrDefault()).id + 1;
            Etudiant edInserted = new Etudiant
            {
                cne = Convert.ToInt32(textBox2.Text),
                nom = textBox3.Text,
                prenom = textBox4.Text,
                sexe = Sexe,
                date_naiss = DateTime.Parse(dateBox.Text),
                adress = textBox5.Text,
                telephone = textBox6.Text,
                id_filiere = comboBox4.SelectedIndex + 1,
                id_level = comboBox1.SelectedIndex + 1,
            };

            // Add the object to the DataContext.Etudiants
            _db.Etudiants.InsertOnSubmit(edInserted);



            try
            {
                // Submit changes to the database
                _db.ExecuteCommand("SET IDENTITY_INSERT Etudiants ON");
                _db.SubmitChanges();
                UpdateGrid();
                MessageBox.Show("Student Inserted successfuly");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var edToUpdate = _db.Etudiants
                   .SingleOrDefault(ed => ed.cne == Cne);

            char Sexe = 'M';
            if (radioButton1.Checked) { Sexe = 'F'; }
            if (edToUpdate != null)
            {
                edToUpdate.cne = Convert.ToInt32(textBox2.Text);
                edToUpdate.nom = textBox3.Text;
                edToUpdate.prenom = textBox4.Text;
                edToUpdate.sexe = Sexe;
                edToUpdate.date_naiss = Convert.ToDateTime(dateBox.Text);
                edToUpdate.adress = textBox5.Text;
                edToUpdate.telephone = textBox6.Text;
                edToUpdate.id_filiere = comboBox4.SelectedIndex + 1;
                edToUpdate.id_level = comboBox1.SelectedIndex + 1;

                _db.SubmitChanges();

            }

            UpdateGrid();
            MessageBox.Show("Etudiant a ete modifier avec success");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var p = dataGridView2.CurrentRow.Index;
            if (p == -1) { MessageBox.Show("Vous devez selectioner une ligne!"); }
            var id = int.Parse(dataGridView2.Rows[p].Cells["id"].Value.ToString());



            var edToDelete = (from ed in _db.Etudiants
                              where ed.id == id
                              select ed).SingleOrDefault();

            if (edToDelete != null)
            {
                _db.Etudiants.DeleteOnSubmit(edToDelete);
                _db.SubmitChanges();
                UpdateGrid();
                MessageBox.Show("Etudiant a ete supprimer avec success");

            }
            else
            {
                MessageBox.Show("No Row Selected");
            }
        }





        //****************************** Statistique Tab ***********************************




        //****************************** Reporting Tab ***********************************

        private void button11_Click(object sender, EventArgs e)
        {
            int cneField = Convert.ToInt32(textBox7.Text);

            // Create a new dataset to hold the data
            DataSet1 ds = new DataSet1();

            // Create a connection and command to fetch data from the database
            using (SqlConnection conn = new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"))
            {
                //conn.Open(); // Open the connection

                using (SqlCommand cmd = new SqlCommand($"SELECT e.*, f.nom_filiere FROM Etudiants e JOIN Filieres f ON e.id_filiere = f.id WHERE e.cne = {cneField}", conn))
                {
                    // Use SqlDataAdapter to fill the DataTable in the dataset
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds.DataTable1);
                }
            }

            if (ds.DataTable1.Rows.Count > 0)
            {
                // Create a Crystal Report object
                CrystalReport1 cs = new CrystalReport1();

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

        private void button12_Click(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();

            // Create a connection and command to fetch data from the database
            using (SqlConnection conn = new SqlConnection("data Source =  mssql-156674-0.cloudclusters.net,15848; initial Catalog = SMA_db; User ID=admin;Password=Admin1234;"))
            {
                //conn.Open(); // Open the connection

                using (SqlCommand cmd = new SqlCommand($"SELECT e.*, f.nom_filiere FROM Etudiants e JOIN Filieres f ON e.id_filiere = f.id", conn))
                {
                    // Use SqlDataAdapter to fill the DataTable in the dataset
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds.DataTable1);
                }
            }

            if (ds.DataTable1.Rows.Count > 0)
            {
                // Create a Crystal Report object
                AllStudent cs = new AllStudent();

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

        //****************************** Trombinoscope Tab ***********************************
        private void button13_Click(object sender, EventArgs e)
        {
            // get the data from table Etudiants 
            List<Etudiant> etudiantsList = _db.Etudiants.ToList();

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
