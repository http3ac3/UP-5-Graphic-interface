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

        static double Function(double x) => Math.Sqrt(x * x - 1);

        private void GetTableButton_Click(object sender, EventArgs e)
        {
            TableTextBox.Text = "";
            if (!double.TryParse(AValueBox.Text, out double a))
            {
                MessageBox.Show("Поле а содержит недопустимые значения!\n" +
                    "К вводу доступны только цифры, знак \"минус\" и запятая!", "Ошибка");
                return;
            }

            if (!double.TryParse(BValueBox.Text, out double b))
            {
                MessageBox.Show("Поле b содержит недопустимые значения!\n" +
                    "К вводу доступны только цифры, знак \"минус\" и запятая!", "Ошибка");
                return;
            }

            if (!double.TryParse(HValueBox.Text, out double h))
            {
                MessageBox.Show("Поле h содержит недопустимые значения!\n" +
                    "К вводу доступны только цифры, знак \"минус\" и запятая!", "Ошибка");
                return;
            }

            TableTextBox.Text = "x\t|y\n====================\n";

            for (double x = a; x <= b; x += h)
            {
                if (x == 0)
                {
                    TableTextBox.Text += "В точке 0 функция не определена!\n";
                    continue;
                }

                TableTextBox.Text += $"{x}\t|{Function(x)}\n";
            }
        }
    }
}
