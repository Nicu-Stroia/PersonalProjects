using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class MathTest : Form
    {
        public Random randomizer = new Random();
        public int add1, add2, minus1, minus2, multiply1, multiply2, divide1, divide2, temp,timeLeft;



        private void startButton_Click(object sender, EventArgs e)
        {
            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);
            plusLeftLabel.Text = add1.ToString();
            plusRightLabel.Text = add2.ToString();
            sum.Value = 0;

            minus1 = randomizer.Next(51);
            minus2 = randomizer.Next(51);
            minusLeftLabel.Text = minus1.ToString();
            minusRightLabel.Text = minus2.ToString();
            difference.Value = 0;

            multiply1 = randomizer.Next(21);
            multiply2 = randomizer.Next(21);
            timesLeftLabel.Text = multiply1.ToString();
            timesRightLabel.Text = multiply2.ToString();
            product.Value = 0;

            divide2 = randomizer.Next(2, 21);
            temp = randomizer.Next(2, 21);
            divide1 = divide2 * temp;
            dividedLeftLabel.Text = divide1.ToString();
            dividedRightLabel.Text = divide2.ToString();
            quotient.Value = 0;

            timeLeft = 40;
            timeLabel.Text = timeLeft + " seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                Answer();
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time is up!";
                sum.Value = add1 + add2;
                difference.Value = minus1 - minus2;
                product.Value = multiply1 * multiply2;
                quotient.Value = divide1 / divide2;
                MessageBox.Show("You didn't finish on time!");
            }
            if(timeLeft <= 5 && timeLeft >0)
            {
                timeLabel.BackColor = Color.Red;
            }
            if (CheckTheAnswer() == true && timeLeft > 0)
            {
                timer1.Stop();
                MessageBox.Show("Congratulations! You got all the answers right!");
            }
        }

        private bool CheckTheAnswer()
        {
            if ((add1 + add2 == sum.Value && minus1 - minus2 == difference.Value) && 
                (multiply1 * multiply2 == product.Value && divide1 / divide2 == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Answer()
        {
            if (add1 + add2 != sum.Value && sum.Value != 0)
            {
                sum.BackColor = Color.Red;
            }
            else
            {
                sum.BackColor= Color.White;
            }
        }

    public MathTest()
        {
            InitializeComponent();
        }
    }
}
