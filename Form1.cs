using System;
using System.Collections;
using System.Numerics;

namespace practice8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger g=0, p;
            Random rnd = new Random();
            do
            {
                p = rnd.Next()%10000;
                if (Global.GetPRoot(p).HasValue)
                    g = Global.GetPRoot(p).Value;
                else continue;
            } while (!Global.IsPRoot(p, g));
            Global.G = g;
            Global.P = p;
            textBox1.Text = p.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Global.G.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox3.Text = (rnd.Next() % 1000000).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox4.Text = (rnd.Next() % 1000000).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Text = (BigInteger.Pow(Global.G,int.Parse(textBox3.Text))%Global.P).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = (BigInteger.Pow(Global.G, int.Parse(textBox4.Text)) % Global.P).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox6.Text = (BigInteger.Pow(int.Parse(textBox5.Text), int.Parse(textBox3.Text)) % Global.P).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox7.Text = (BigInteger.Pow(int.Parse(textBox8.Text), int.Parse(textBox4.Text)) % Global.P).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            String message = "Число простое";
            String caption = "Проверка";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            
        }

    }

    static class Global
    {
        private static BigInteger _g = 0;
        private static BigInteger _p = 0;
        private static Dictionary<BigInteger, BigInteger> keys = new Dictionary<BigInteger, BigInteger>();
        public static BigInteger G
        {
            get { return _g; }
            set { _g = value; }
        }
        public static BigInteger P
        {
            get { return _p; }
            set { _p = value; }
        }

        public static BigInteger? GetPRoot(BigInteger p)
        {
            for (BigInteger i = 0; i < p; i++)
                if (IsPRoot(p, i))
                    return i;
            return null;
        }
        public static Dictionary<BigInteger, BigInteger> Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        public static bool IsPRoot(BigInteger p, BigInteger a)
        {
            if (a == 0 || a == 1)
                return false;
            BigInteger last = 1;
            var set = new HashSet<BigInteger>();
            for (BigInteger i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.Contains(last)) // Если повтор
                    return false;
                set.Add(last);
            }
            return true;
        }
    }

}