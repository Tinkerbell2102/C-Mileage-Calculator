using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG521_FA3_6955
{
    public partial class MEfficiency : Form
    {
        public MEfficiency()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal decMiles =
                    Convert.ToDecimal(txtMiles.Text);
                decimal decGallons =
                    Convert.ToDecimal(txtGallons.Text);
                decimal decEfficiency = decMiles / decGallons;
                txtEfficiency.Text =
                    String.Format("{0:n}", decEfficiency);

                using (StreamWriter writer = new StreamWriter("d:\\tmp\\MilesperGallon.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine("Miles(" + decMiles + ") / " + "Gallons(" + decGallons + ") =  Miles Per Hour(" + decEfficiency + ")");
                    writer.WriteLine("");
                }
            }

            catch (FormatException fe)
            {
                string msg = String.Format(
                     "Message: {0} Please enter a number value!\n",
                     fe.Message);
                MessageBox.Show(msg.ToString());

                using (StreamWriter writer = new StreamWriter("d:\\tmp\\Exceptionfile.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(fe);
                    writer.WriteLine("");
                }
            }
            catch (DivideByZeroException dbze)
            {
                string msg = String.Format(
                    "Message: {0}Cannot devide by zero!\n",
                    dbze.Message);
                    MessageBox.Show(
                    msg.ToString());

                using (StreamWriter writer = new StreamWriter("d:\\tmp\\Exceptionfile.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(dbze);
                    writer.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                string msg = String.Format(
                    "Message: {0}Please enter a smaller value\n",
                    ex.Message);
                    MessageBox.Show(msg.ToString());

                using (StreamWriter writer = new StreamWriter("d:\\tmp\\Exceptionfile.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex);
                    writer.WriteLine("");
                }
            }
            finally
            {
                txtMiles.Focus();
            }
        }
        private void MEfficiency_Load(object sender, EventArgs e)
        {
            txtMiles.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMiles.Clear();
            txtGallons.Clear();
            txtEfficiency.Clear();
            txtMiles.Focus();
        }
    } 
}
