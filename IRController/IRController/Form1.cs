using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRController
{
    public partial class Form1 : Form
    {
        private bool input = false, 
                    output = false;
        private ReviewCleaner tester;
        private string inputFileName;
        private string outputFileName;
  
        public Form1()
        {
            InitializeComponent();
            //Instantiate Object to clean Reviews
            tester = new ReviewCleaner();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputFileName = textBox1.Text;
            input = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            outputFileName = textBox2.Text;
            output = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             // Create an instance of the open file dialog box.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);

            // Set filter options and filter index.
            ofd.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            ofd.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //save the chosen path
                inputFileName = ofd.FileName;

                //when file is chosen display it in the text box
                textBox1.Text = ofd.FileName;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            
            // Set filter options and filter index.
            saveFileDialog1.Filter = "Basket Files(*.basket)|*.basket|All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //save the chosen path
                outputFileName = saveFileDialog1.FileName;
                
                //when file is chosen display it in the text box
                textBox2.Text = saveFileDialog1.FileName;

            } 

        }

        private void startCleaning_Click_1(object sender, EventArgs e)
        {
            //Check to see if there is a file to open and a file name to save results.
            if (input && output)
            {
  
                tester.cleanReviews(inputFileName, outputFileName);

            }
            else
            {
                if (!(input && output))
                {
                    MessageBox.Show("Please enter in a Review and a location to save to");
                }
                else if (!input)
                    MessageBox.Show("Please Enter in a Review to clean");
                else if (!output)
                    MessageBox.Show("Please Enter in a location to save the file");
            }
        }

    }
}
