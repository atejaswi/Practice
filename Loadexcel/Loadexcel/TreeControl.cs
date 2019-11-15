using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loadexcel
{
    public partial class TreeControl : Form
    {
        public TreeControl()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string s = "";
                s = treeView1.SelectedNode.Name.ToString();

                if (s.Equals("Aiken"))
                {
                    textBox1.Text = "Aiken";
                }
                if (s.Equals("Sumter"))
                {
                    textBox1.Text = "Sum";
                }

                TreeNode node = e.Node;
            
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
              
            }


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
