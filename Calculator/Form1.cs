using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Parce(string stringParcing)
        {
            string value = "";
            while (stringParcing.Substring(0, 1) != "+")
            {
                value += stringParcing.Substring(0, 1);
                stringParcing = stringParcing.Remove(0, 1);
                if (stringParcing == "")
                {
                    break;
                }
            }

            if (stringParcing!="")
            {
                stringParcing = stringParcing.Remove(0, 1);
            }

            textBox1.Text = stringParcing;
            return Convert.ToInt32(value);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Number first = new Number();
            first.num = Parce(textBox1.Text);

            Number second = new Number();
            second.num = Parce(textBox1.Text);

            if (textBox1.Text == "")
            {
                label1.Text = Convert.ToString(first.num + second.num);
                return;
            }

            Summ summ = new Summ(); 
            Summ summ2 = new Summ();

            summ.a = first;
            summ.b = second;

            while (textBox1.Text != "") 
            {
                summ2 = new Summ();
                summ2.a = summ;
                second = new Number();
                second.num = Parce(textBox1.Text);
                summ2.b = second;

                summ = new Summ();
                summ.a = summ2;
                second = new Number();
                if (textBox1.Text != "")
                {
                    second.num = Parce(textBox1.Text);
                    summ.b = second;
                }
                else
                {
                    second.num = 0;
                    summ.b = second;
                }

                if (textBox1.Text == "")
                {
                    label1.Text = Convert.ToString(summ.calc());
                    break;
                }
            }

        }
    }

    public interface IOperation
    {
        int calc();
    }

    public class Number : IOperation
    {
        public int num { get; set; }

        public int calc()
        {
            return num;
        }

    }

    public class Summ : IOperation
    {
        public IOperation a { get; set; }
        public IOperation b { get; set; }

        public int calc()
        {
            return a.calc() + b.calc();
        }
    }

}
