using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace MyOCR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap pict;
        MyOCRClass2 mOcr;


        private void Form1_Load(object sender, EventArgs e)
        {
            mOcr = new MyOCRClass2();
            mOcr.fillEtalonBase();
        }

        private void open_Image()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {


                try
                {

                    // create image document
                    pict = new Bitmap(ofd.FileName);
                    this.Text = ofd.FileName;
                    pictureBox1.Image = new Bitmap(ofd.FileName);

                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }		

        }


        private Bitmap draw_Matrix(MyOCRClass2.Matrix m)
        {
            Bitmap bmp = new Bitmap(30, 40);

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    //if (m.matrix[i, j] == 1)
                    //{
                    //    bmp.SetPixel(i, j, Color.White);
                    //}

                    if (m.matrix[i, j] == 0)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }
            return bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open_Image();

           mOcr.compareMatrix(mOcr.createMatrix(pict));

           // ResizeNearestNeighbor Resizefilter = new ResizeNearestNeighbor(60, 70);
            //Bitmap resized = Resizefilter.Apply(draw_Matrix(mOcr.createMatrix(pict)));
           // pictureBox_matrix.Image = draw_Matrix(mOcr.createMatrix(pict));
            label1.Text = (mOcr.getLetter());

           
        }





    }
}
