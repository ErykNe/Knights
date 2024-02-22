using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemskoczkow
{
    public partial class Form1 : Form
    {
        public int[,] szachownica = new int[8, 8];
        public Form1()
        {
            InitializeComponent();
        }
        public void PlaceKnights()
        {
          for (int i = 0; i < szachownica.GetLength(0); i++)
            {
                for(int j = 0; j < szachownica.GetLength(1); j++)
                {
                    if(j % 2 != 0)
                    {
                        if (i % 2 == 0)
                        {
                            szachownica[i, j] = 1;
                        }
                    }
                    if(j % 2 == 0)
                    {
                        if (i % 2 != 0)
                        {
                            szachownica[i, j] = 1;
                        }
                    }
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
     
            int h = szachownica.GetLength(0);
            int w = szachownica.GetLength(1);
            int cellSize = 50;
            this.dataGridView1.ColumnCount = w;
            this.dataGridView1.RowCount = h;
            this.dataGridView1.Width = cellSize * 8 + 3;
            this.dataGridView1.Height = cellSize * 8 + 3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;

            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = cellSize;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = cellSize;
            }
            PlaceKnights();

       
            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    
                    dataGridView1[i,j].Value = szachownica[i,j];
                    if (szachownica[i, j] != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
                        
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = e.RowIndex;
            int y = e.ColumnIndex;
            if (szachownica[x, y] != 0)
            {
                if (x + 1 <= 7 && y + 2 <= 7) { dataGridView1.Rows[x + 1].Cells[y + 2].Style.BackColor = Color.Red; };
                if (x + 2 <= 7 && y + 1 <= 7) { dataGridView1.Rows[x + 2].Cells[y + 1].Style.BackColor = Color.Red; };
                if (x - 1 >= 0 && y + 2 <= 7) { dataGridView1.Rows[x - 1].Cells[y + 2].Style.BackColor = Color.Red; };
                if (x - 2 >= 0 && y + 1 <= 7) { dataGridView1.Rows[x - 2].Cells[y + 1].Style.BackColor = Color.Red; };

                if (x - 1 >= 0 && y - 2 >= 0) { dataGridView1.Rows[x - 1].Cells[y - 2].Style.BackColor = Color.Red; };
                if (x - 2 >= 0 && y - 1 >= 0) { dataGridView1.Rows[x - 2].Cells[y - 1].Style.BackColor = Color.Red; };
                if (x + 1 <= 7 && y - 2 >= 0) { dataGridView1.Rows[x + 1].Cells[y - 2].Style.BackColor = Color.Red; };
                if (x + 2 <= 7 && y - 1 >= 0) { dataGridView1.Rows[x + 2].Cells[y - 1].Style.BackColor = Color.Red; };
            }
        }
    }
    public class Knight
    {
        Knight(int x, int y)
        {
            this.x = x;
            this.y = y;

        }

        public int x { get; }
        public int y { get; }
    }
}
