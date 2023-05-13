using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static int n = 3; // Number of processes
        static int m = 4; // Number of resources
        string[,] allocate = new string[n, m];
        int[,] need = new int[n, m];
        string[,] maximum = new string[n, m];
        int[,] max = new int[n, m];
        int[,] alloc = new int[n, m];
        int[] nofresources = new int[m];
        String name;
        int[] avail = new int[m];
        int[] safeSequence = new int[n];
        String[] alpha = { "A", "B", "C", "D" };

        void initail_values() {


            allocate[0, 0] = textBox26.Text;
            allocate[0, 1] = textBox15.Text;
            allocate[0, 2] = textBox16.Text;
            allocate[0, 3] = textBox17.Text;
            allocate[1, 0] = textBox18.Text;
            allocate[1, 1] = textBox19.Text;
            allocate[1, 2] = textBox20.Text;
            allocate[1, 3] = textBox21.Text;
            allocate[2, 0] = textBox22.Text;
            allocate[2, 1] = textBox23.Text;
            allocate[2, 2] = textBox24.Text;
            allocate[2, 3] = textBox25.Text;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    alloc[i, j] = int.Parse(allocate[i, j]);
                }
            }
            maximum[0, 0] = textBox1.Text;
            maximum[0, 1] = textBox14.Text;
            maximum[0, 2] = textBox13.Text;
            maximum[0, 3] = textBox12.Text;
            maximum[1, 0] = textBox11.Text;
            maximum[1, 1] = textBox10.Text;
            maximum[1, 2] = textBox9.Text;
            maximum[1, 3] = textBox8.Text;
            maximum[2, 0] = textBox7.Text;
            maximum[2, 1] = textBox6.Text;
            maximum[2, 2] = textBox5.Text;
            maximum[2, 3] = textBox4.Text;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    max[i, j] = int.Parse(maximum[i, j]);

                }
            }
            avail[0] = int.Parse(textBox38.Text);
            avail[1] = int.Parse(textBox27.Text);
            avail[2] = int.Parse(textBox28.Text);
            avail[3] = int.Parse(textBox29.Text);








        }
        void calculateNeed()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    need[i, j] = max[i, j] - alloc[i, j];

                }
            }
        }
        	void isSafe()
	{
		int count = 0;

		// visited array to find the
		// already allocated process
		Boolean[] visited = new Boolean[n];
		for (int i = 0; i < n; i++)
		{
			visited[i] = false;
		}

		// work array to store the copy of
		// available resources
		int[] work = new int[m];
		for (int i = 0; i < m; i++)
		{
			work[i] = avail[i];
		}

		while (count < n)
		{
			Boolean flag = false;
			for (int i = 0; i < n; i++)
			{
				if (visited[i] == false)
				{
					int j;
					for (j = 0; j < m; j++)
					{
						if (need[i, j] > work[j])
							break;
					}
					if (j == m)
					{
						safeSequence[count++] = i;
						visited[i] = true;
						flag = true;
						for (j = 0; j < m; j++)
						{
							work[j] = work[j] + alloc[i, j];
						}
					}
				}
			}
			if (flag == false)
			{
				break;
			}
		}
		if (count < n)
		{
			MessageBox.Show("The System is UnSafe!");
		}
		else
		{
			MessageBox.Show("Following is the SAFE Sequence");
			for (int i = 0; i < n; i++)
			{
                    name = "P" + safeSequence[i]+ "->";
                //MessageBox.Show("P" + safeSequence[i]);
                //if (i != n - 1)
                MessageBox.Show(name.ToString());
                }
		}
	}

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            initail_values();
            calculateNeed();
            isSafe();


        }
    }
}
