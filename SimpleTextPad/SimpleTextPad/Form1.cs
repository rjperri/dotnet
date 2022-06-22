namespace SimpleTextPad
{
    public partial class SimpleTextPad : Form
    {
        public SimpleTextPad()
        {
            InitializeComponent();
        }


        private void openFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Contains(".txt")) //Checks if it's all ok and if the file name contains .txt
            {
                string open = File.ReadAllText(openFileDialog1.FileName);
                richTextBox1.Text = open;
            }
            else
            {
                MessageBox.Show("The File you've chosen is not a text file");
            }
        }

        private void font_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog(); //Shows the font dialog
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }

        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string name = saveFileDialog1.FileName + ".txt";
                File.WriteAllText(name, richTextBox1.Text);
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}