using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        byte length = 0;
        bool kolpoint = false;
        double rez = 0.0;
        float SIze = 36f;
        byte kolvo ;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true; // чтобы работал keyDown нужно установить фокус на объекте
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "0";
        }
        private void Button2_Click(object sender, EventArgs e)//равно
        {
            
            if (label1.Text != "" & label2.Text != "0")
            {
                string s12 = label1.Text.Substring(label1.Text.Length - 1, 1);
                switch (s12)
                {
                    case "+":
                        rez = double.Parse(label1.Text.Substring(0, label1.Text.Length - 1)) + double.Parse(label2.Text);
                        break;
                    case "-":
                        rez = double.Parse(label1.Text.Substring(0, label1.Text.Length - 1)) - double.Parse(label2.Text);
                        break;
                    case "*":
                        rez = double.Parse(label1.Text.Substring(0, label1.Text.Length - 1)) * double.Parse(label2.Text);
                        break;
                    case ":":
                        rez = double.Parse(label1.Text.Substring(0, label1.Text.Length - 1)) / double.Parse(label2.Text);
                        break;

                }


                label1.Text = "";
                label2.Text = rez.ToString("G");
                rez = 0.0;

            }
        }
        void fontScale()//изменение размера шрифта
        {
            int lengthnow = label2.Text.Length;
            if (lengthnow>7&lengthnow>length)
            {
                SIze -= 1.7f;
                label2.Font = new Font("Microsoft Sans Serif", SIze, FontStyle.Regular, GraphicsUnit.Point);
                length =Convert.ToByte( lengthnow);
            }
            else if(lengthnow>7&lengthnow<length)
            {
                SIze += 1.7f;
                label2.Font = new Font("Microsoft Sans Serif", SIze, FontStyle.Regular, GraphicsUnit.Point);
                length = Convert.ToByte(lengthnow);
            }

        }
        void enter(double x)//ввод числа 
        {
            if (label2.Text == "0") label2.Text = "";
            label2.Text += x;
            
         }
        void operand(string op)   //операция над числом
        {
            if (label1.Text == "")
            {
                label1.Text = label2.Text + op;
                label2.Text = "0";
                kolpoint = false;
            }
            else if (label1.Text != "" & !label1.Text.EndsWith(op))
            { label1.Text = label1.Text.Substring(0, label1.Text.Length - 1) + op; }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e) // проверка нажатия кнопки
        {
            Keys key = e.KeyData;

            
            if ((kolvo=Convert.ToByte(label2.Text.Length)) <= 16)
            {
                switch (key)
                {
                    case Keys.NumPad1:
                        enter(1);

                        break;
                    case Keys.NumPad2:
                        enter(2);
                        break;
                    case Keys.NumPad3:
                        enter(3);
                        break;
                    case Keys.NumPad4:
                        enter(4);
                        break;
                    case Keys.NumPad5:
                        enter(5);
                        break;
                    case Keys.NumPad6:
                        enter(6);
                        break;
                    case Keys.NumPad7:
                        enter(7);
                        break;
                    case Keys.NumPad8:
                        enter(8);
                        break;
                    case Keys.NumPad9:
                        enter(9);
                        break;
                    case Keys.NumPad0:
                        enter(0);
                        break;
                    case Keys.Decimal:
                        if (kolpoint == false )
                        {
                            kolpoint = true;
                            if (label2.Text == "0") label2.Text = "0";
                            label2.Text += ",";
                            
                        }
                        break;


                }


            }
            
            switch (key)
            {
                case Keys.Subtract:
                    operand("-");
                    break;
                case Keys.Add:
                    operand("+");
                    break;
                case Keys.Back:
                    Button3_Click(sender, e);
                    break;
                case Keys.Divide:
                    operand(":");
                    break;
                case Keys.Multiply:
                    operand("*");
                    break;
                case Keys.Enter:
                    Button20_Click(sender, e);
                    break;
            }
        }
        private void Button3_Click(object sender, EventArgs e)   //backspase
        {
            if (label2.Text=="0")
            { }
            else if (label2.Text != "0")
            {
                if (!label2.Text.EndsWith(","))
                {
                    if (label2.Text.Length == 1)
                    { label2.Text = "0"; }
                    else
                    {
                        label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
                    }
                    
                }
                else
                {
               
                
                    kolpoint = false;
                    label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
                
                }
                
            }
            
            
        }
        private void Button20_Click(object sender, EventArgs e)//очистить
        {
            label1.Text = "";
            label2.Text = "0";
            rez = 0;
            kolvo = 0;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            enter(9);
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            enter(8);
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            enter(7);
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            enter(6);
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            enter(5);
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            enter(4);
        }
        private void Button13_Click(object sender, EventArgs e)
        {
            enter(3);
        }
        private void Button14_Click(object sender, EventArgs e)
        {
            enter(2);
        }
        private void Button15_Click(object sender, EventArgs e)
        {
            enter(1);
        }
        private void Button18_Click(object sender, EventArgs e)
        { enter(0); }
        private void Button16_Click(object sender, EventArgs e)
        {
            operand("+");
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            operand("-");
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            operand(":");
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            operand("*");
        }
        private void Button19_Click(object sender, EventArgs e)
        {
            if (kolpoint == false)
            {
                kolpoint = true;
                if (label2.Text == "0") label2.Text = "0";
                label2.Text += ",";

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
        }
    }
}
