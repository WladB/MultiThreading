using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SaveAsThread saveAsThread1;
        SaveAsThread saveAsThread2;
        SaveAsThread saveAsThread3;
        InitializeArThread initialize1;
        InitializeArThread initialize2;
        InitializeArThread initialize3;
        public int[] array2;
        public int[] array3;
        public int[] array1;
        
        private void button1_Click(object sender, EventArgs e)
        {
            initialize1.Stop();
            initialize2.Stop();
            initialize3.Stop();
            saveAsThread1.Stop();
            saveAsThread2.Stop();
            saveAsThread3.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            array1 = new int[10000000];
            array2 = new int[10000000];
            array3 = new int[10000000];
            initialize1 = new InitializeArThread(array1);
            initialize2 = new InitializeArThread(array2);
            initialize3 = new InitializeArThread(array3);
            saveAsThread1 = new SaveAsThread(array1, "1.txt");
            saveAsThread2 = new SaveAsThread(array2, "2.txt");
            saveAsThread3 = new SaveAsThread(array3, "3.txt");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            initialize1.Start();
            initialize2.Start();
            initialize3.Start();
            saveAsThread1.Start();
            saveAsThread2.Start();
            saveAsThread3.Start();
        }
    }
}
