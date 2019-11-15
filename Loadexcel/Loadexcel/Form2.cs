using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loadexcel
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", label2.Text);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    try
                    {
                        // Create Connection to Excel Workbook
                        using (OleDbConnection connection =
                                     new OleDbConnection(excelConnectionString))
                        {
                            //OleDbCommand command = new OleDbCommand("Select * FROM [RLSA$]", connection);
                          OleDbCommand command = new OleDbCommand("Select * FROM [Sheet1$]", connection);
                            //OleDbCommand command = new OleDbCommand("Select * FROM [RefAssociatedScreen_T1$]", connection);

                          
                            //OleDbCommand command = new OleDbCommand("Select * FROM [RefScreen_T1$]", connection);
                            //OleDbCommand command = new OleDbCommand("Select * FROM [RefScreenFunctions_T1$]", connection);
                            //OleDbCommand command = new OleDbCommand("Select * FROM [RefRoles_T1$]", connection);
                            //OleDbCommand command = new OleDbCommand("Select * FROM [RefRoleScreenAccess_T1$]", connection);

                            connection.Open();

                            //OleDbDataAdapter objDatAdap = new OleDbDataAdapter();
                            //objDatAdap.SelectCommand = command;
                            //DataSet ds = new DataSet();
                            //objDatAdap.Fill(ds);
                            //DataTable Exceldt = ds.Tables[0];

                            // Create DbDataReader to Data Worksheet
                            using (DbDataReader dr = command.ExecuteReader())
                            {

                                //string sqlConnectionString = @"Server = PRO-2891; Database = TEST; Trusted_Connection = True";
                                string sqlConnectionString = @"Server = PRO-2842; Database = SC_DEV_REF_DB; Trusted_Connection = True";
                                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                                {
                                   //bulkCopy.DestinationTableName = "PACSSR";
                                    //bulkCopy.DestinationTableName  = "RefScreenFunctions_T1";
                                    //bulkCopy.DestinationTableName = "RefAssociatedScreen_T1";

                                   
                                    //bulkCopy.DestinationTableName = "RefScreen_T1";
                                    //bulkCopy.DestinationTableName = "RefScreenFunctions_T1";
                                    //bulkCopy.DestinationTableName = "RefRoles_T1";
                                   bulkCopy.DestinationTableName = "RLSA";



                                    bulkCopy.WriteToServer(dr);

                                }
                            }
                        }
                        MessageBox.Show("The data has been exported succefuly from Excel to SQL");
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Visible = false;
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        label2.Text = path;
                        label2.Visible = true;

                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
