using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleUnderline
{
    public partial class DoubleUnderLineForm : Form
    {
        private DoubleUnderLineController _controller = new DoubleUnderLineController();

        public DoubleUnderLineForm()
        {
            InitializeComponent();
        }

        private void btnQuest_Click(object sender, EventArgs e)
        {
            ofdQuest.ShowDialog();
            tbxQuest.Text = ofdQuest.FileName;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            ofdAnswer.ShowDialog();
            tbxAnswer.Text = ofdAnswer.FileName;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ofdQuest.FileName) || string.IsNullOrEmpty(ofdAnswer.FileName))
            {
                MessageBox.Show("File path can't be empty!");
                return;
            }

            try
            {
                _controller.RunDetail(ofdQuest.FileName, ofdAnswer.FileName);
                MessageBox.Show("Done!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unhandled exception!");
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnRunSimple_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ofdQuest.FileName) || string.IsNullOrEmpty(ofdAnswer.FileName))
            {
                MessageBox.Show("File path can't be empty!");
                return;
            }

            try
            {
                _controller.RunSimple(ofdQuest.FileName, ofdAnswer.FileName);
                MessageBox.Show("Done!");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unhandled exception!");
                MessageBox.Show(exception.ToString());
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            _controller.Test(ofdQuest.FileName, ofdAnswer.FileName);
        }
    }
}