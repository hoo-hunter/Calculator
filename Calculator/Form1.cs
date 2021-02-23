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

        public string Half_String { get; set; }
        public int Parcing(string Str)
        {
            string Value = "";
            while (Str.Substring(0, 1) != "+") 
            {
                Value = Value + Str.Substring(0, 1);
                Str = Str.Remove(0, 1);
            }
            Number H_String = new Number();
            H_String.Half_String = Str.Remove(0, 1);
            return Convert.ToInt32(Value);
        }

    }

    public class Summ : IOperation
    {
        public IOperation a { get; set; }
        public IOperation b { get; set; }

        public int calc()
        {
            //switch case для выбора знака, который и будем считать 
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
            string Half_String = Str.Half_String;
            Number First = new Number();
            First.num = First_Numb;

            Number Second = new Number();
            int Second_Numb = Str.Parcing(Half_String);
            Second.num = Second_Numb;

            Summ summ = new Summ();
            summ.a = First;
            summ.b = Second;
            summ.calc();

            Summ summ1 = new Summ();
            summ1.a = summ;
            summ1.b = Second;

            summ1.calc();

        }
    }
}