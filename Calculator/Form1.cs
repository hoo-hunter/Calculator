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

        public int Parcing(string Str)
        {
            return 0;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Number Str = new Number();
            int First_Numb = Str.Parcing(textBox1.Text);
            Number First = new Number();
            First.num = First_Numb;

            Number Second = new Number();
            Second.num = 5;

            Summ summ = new Summ();
            summ.a = First;
            summ.b = Second;

            Summ summ1 = new Summ();
            summ1.a = summ;
            summ1.b = Second;

            summ1.calc();

        }
    }
}
