using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loadexcel
{
    public partial class Benchmark : Form
    {
        public Benchmark()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            String mainFolder = @"C:\LogFiles\";
            if (!Directory.Exists(mainFolder))
            {
                Directory.CreateDirectory(mainFolder);

            }
            string filesFolderName = string.Format("DummyFiles_{0:MMddyyyy_hhmmssfff_tt}", DateTime.Now);
            string subFolder = Path.Combine(mainFolder, filesFolderName);
            string srcFolder = Path.Combine(subFolder, "src");
            Directory.CreateDirectory(srcFolder);

            string destFolder = Path.Combine(subFolder, "dest");
            Directory.CreateDirectory(destFolder);

            string oneKbFileName = Path.Combine(srcFolder, "1KB.txt");
            string tenKbFileName = Path.Combine(srcFolder, "10KB.txt");
            string hundredKbFileName = Path.Combine(srcFolder, "100KB.txt");
            string oneMbFileName = Path.Combine(srcFolder, "1MB.txt");

            byte[] oneDataArray = new byte[1000];
            byte[] tenDataArray = new byte[10 * 1000];
            byte[] hundredDataArray = new byte[100 * 1024];
            byte[] oneMBDataArray = new byte[1024 * 1024];

            FileStream oneFs = new FileStream(oneKbFileName, FileMode.CreateNew);
            for (int i = 0; i < oneDataArray.Length; i++)
            {
                oneFs.WriteByte((byte)i);
            }

            FileStream tenFs = new FileStream(tenKbFileName, FileMode.CreateNew);
            for (int i = 0; i < tenDataArray.Length; i++)
            {
                tenFs.WriteByte((byte)i);
            }

            FileStream hundredFs = new FileStream(hundredKbFileName, FileMode.CreateNew);
            for (int i = 0; i < hundredDataArray.Length; i++)
            {
                hundredFs.WriteByte((byte)i);
            }

            FileStream oneMBFs = new FileStream(oneMbFileName, FileMode.CreateNew);
            for (int i = 0; i < oneMBDataArray.Length; i++)
            {
                oneMBFs.WriteByte((byte)i);
            }
            oneFs.Close();
            tenFs.Close();
            hundredFs.Close();
            oneMBFs.Close();

            DateTime startTime;
            DateTime endTime;
            TimeSpan totalTime;
            DataTable dt = new DataTable("Benchmark");
            dt.Columns.Add("File Size");
            dt.Columns.Add("Milliseconds");
            dt.Columns.Add("Seconds");
            dt.Columns.Add("Minutes");
            dt.Columns.Add("Hours");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            startTime = DateTime.Now;
            File.Copy(Path.Combine(srcFolder, "1KB.txt"), Path.Combine(destFolder, "1KB.txt"), true);
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            dt.Rows.Add("1KB", totalTime.Milliseconds, totalTime.Seconds, totalTime.Minutes, totalTime.Hours);

            startTime = DateTime.Now;
            File.Copy(Path.Combine(srcFolder, "10KB.txt"), Path.Combine(destFolder, "10KB.txt"), true);
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            dt.Rows.Add("10KB", totalTime.Milliseconds, totalTime.Seconds, totalTime.Minutes, totalTime.Hours);

            startTime = DateTime.Now;
            File.Copy(Path.Combine(srcFolder, "100KB.txt"), Path.Combine(destFolder, "100KB.txt"), true);
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            dt.Rows.Add("100KB", totalTime.Milliseconds, totalTime.Seconds, totalTime.Minutes, totalTime.Hours);

            startTime = DateTime.Now;
            File.Copy(Path.Combine(srcFolder, "1MB.txt"), Path.Combine(destFolder, "1MB.txt"), true);
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            dt.Rows.Add("1MB", totalTime.Milliseconds, totalTime.Seconds, totalTime.Minutes, totalTime.Hours);

            dataGridView1.DataSource = ds.Tables["Benchmark"].DefaultView;

        }
    }
}
