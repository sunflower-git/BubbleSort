using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Natia Mamaiashvili Group 1
namespace MyBubbleSorting
{
    //Inicialization of arrays and giving them random numbers;
    public partial class Form1 : Form
    {
        Random gen = new Random();
        Label[] arr = new Label[7];
        int[] y = { 77, 112, 147, 182, 217, 252, 287 };
        int counter1, counter2, check, swapIndex = 0;
        int changer;
        string status = "think";
        public Form1()
        {
            InitializeComponent();
            arr[0] = label1;
            arr[1] = label2;
            arr[2] = label3;
            arr[3] = label4;
            arr[4] = label5;
            arr[5] = label6;
            arr[6] = label7;


            label1.Top = y[0];
            label2.Top = y[1];
            label3.Top = y[2];
            label4.Top = y[3];
            label5.Top = y[4];
            label6.Top = y[5];
            label7.Top = y[6];

            label1.Text = gen.Next(1, 100).ToString();
            label2.Text = gen.Next(1, 100).ToString();
            label3.Text = gen.Next(1, 100).ToString();
            label4.Text = gen.Next(1, 100).ToString();
            label5.Text = gen.Next(1, 100).ToString();
            label6.Text = gen.Next(1, 100).ToString();
            label7.Text = gen.Next(1, 100).ToString();

        }

        // Reset Button: aranging labels in previous order and assignig them random numbers;
        private void button1_Click(object sender, EventArgs e)
        {
            arr[0] = label1;
            arr[1] = label2;
            arr[2] = label3;
            arr[3] = label4;
            arr[4] = label5;
            arr[5] = label6;
            arr[6] = label7;

            label1.Top = y[0];
            label2.Top = y[1];
            label3.Top = y[2];
            label4.Top = y[3];
            label5.Top = y[4];
            label6.Top = y[5];
            label7.Top = y[6];


            label1.Text = gen.Next(1, 100).ToString();
            label2.Text = gen.Next(1, 100).ToString();
            label3.Text = gen.Next(1, 100).ToString();
            label4.Text = gen.Next(1, 100).ToString();
            label5.Text = gen.Next(1, 100).ToString();
            label6.Text = gen.Next(1, 100).ToString();
            label7.Text = gen.Next(1, 100).ToString();
            label10.Location = new System.Drawing.Point(2, 74);
            button2.Enabled = true;

            //Changing Color To Black;
            for (int i = 0; i < 7; i++)
                arr[i].ForeColor = Color.Black;
            changer = 5;
            timer1.Stop();
        }

        // Sort Button : timer Starts and thus the timer tick starts and bubble sort algorithm;
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            changer = 5;
            counter1 = 0;
            counter2 = 0;
            swapIndex = 0;
            check = 5;
            label10.Top = 74;
            timer1.Start();
            button2.Enabled = false;
            button1.Enabled = false;
        }

        // Bubble Sort Algorithm with three status: move, think and swap step;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (status == "swap")
            {
                if (counter1 > 34)
                {
                    timer1.Stop();
                    Label temp = arr[swapIndex];
                    arr[swapIndex] = arr[swapIndex + 1];
                    arr[swapIndex + 1] = temp;
                    counter1 = 0;
                    status = "move";
                    timer1.Start();
                    return;

                }

                counter1++;
                arr[swapIndex].Top += 1;
                arr[swapIndex + 1].Top -= 1;

            }

            else if (status == "move")
            {
                if (changer < 0)
                {
                    arr[swapIndex].ForeColor = Color.Green;
                    
                    button1.Enabled = true;
                    return;
                }
                if (swapIndex ==changer)
                {
                    if (changer != -2)
                    {
                        arr[changer +1].ForeColor = Color.Green;
                        check -= 34;
                        label10.Top = 74;
                    }
                    changer--;
                    swapIndex = 0;
                    label10.Top = 74;
                    status = "think";
                    
                }
                else
                {

                    if (counter2 > 34)
                    {

                        swapIndex++;
                        counter2 = 0;
                        status = "think";
                        timer1.Start();
                        return;

                    }
                    counter2++;
                    label10.Top += 1;
                }

            }
            else if (status == "think")
            {
                timer1.Stop();
                if (Convert.ToInt32(arr[swapIndex].Text) > Convert.ToInt32(arr[swapIndex + 1].Text))
                {
                    status = "swap";
                }
                else
                    status = "move";


                timer1.Start();
            }
        }

        // Changing track bar values;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = trackBar1.Value.ToString();
            timer1.Interval = trackBar1.Value / 2 + 1;
        }
    }
}

