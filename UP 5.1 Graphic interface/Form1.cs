using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP_5._1_Graphic_interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static double Function(double x)
        {
            x = Math.Round(x, 2);
            return Math.Sqrt(x * x - 1);
        }

        private void GetTableButton_Click(object sender, EventArgs e)
        {
            double a, b, h;
            TableTextBox.Text = "";
            if (!double.TryParse(AValueBox.Text, out a))
            {
                MessageBox.Show("Поле а содержит недопустимые значения!\n" +
                    "К вводу доступны только цифры, знак \"минус\" и запятая!", "Ошибка");
                return;
            }

            if (!double.TryParse(BValueBox.Text, out b))
            {
                MessageBox.Show("Поле b содержит недопустимые значения!\n" +
                    "К вводу доступны только цифры, знак \"минус\" и запятая!", "Ошибка");
                return;
            }

            if (!double.TryParse(HValueBox.Text, out h))
            {
                MessageBox.Show("Поле h содержит недопустимые значения!\n" +
                    "К вводу доступны только цифры, знак \"минус\" и запятая!", "Ошибка");
                return;
            }

            TableTextBox.Text = "x\t|y\n====================\n";

            for (double x = a; x <= b; x += h)
            {
                try
                {
                    if (Math.Round(x * x - 1, 2) < 0) throw new Exception($"В точке { Math.Round(x, 2) } функция не определена!");
                }
                catch (Exception ex)
                {
                    TableTextBox.Text += $"{Math.Round(x, 2)}\t| {ex.Message}\n";
                    continue;
                }
               
                TableTextBox.Text += $"{Math.Round(x, 2)}\t|{Function(x)}\n";
            }
        }
    }
}
