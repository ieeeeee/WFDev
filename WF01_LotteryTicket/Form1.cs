using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF01_LotteryTicket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bntLaunch_Click(object sender, EventArgs e)
        {
            List<string> lstResult = new List<string>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Num");
            int betsCount = Int32.Parse(txtBetsCount.Text.ToString());

            for(int i=0;i< betsCount; i++)
            {
                int[] diffNumPartOne = new int[5];

                int[] diffNumPartTwo = new int[2];
                dt.Rows.Add(strRandomDiffNum(1, 35, 0,5, diffNumPartOne) + "," + strRandomDiffNum(1, 12, 0,2, diffNumPartTwo));
            }
            listBoxResult.DataSource = dt;
            listBoxResult.DisplayMember = "Num";
        }
        Random random = new Random();
        bool flag = false;
        private string strRandomDiffNum(int m, int n, int start, int end,int[] diffNum)
        {
            randomDiffNum(m, n, start, end, diffNum);
            return string.Join(",", diffNum);
        }
        //j到k之间

        private  void randomDiffNum(int m, int n,int start,int end, int[] diffNum)
        {
            int i, j, randomNum;
            for (i = start; i < end; i++)
            {
                flag = false;
                randomNum = random.Next(m, n);
                if (i == 0)
                {
                    diffNum[0] = randomNum;
                }
                else
                {
                    for (j = 0; j < i; j++)
                    {
                        if (diffNum[j] == randomNum)
                        {
                            flag = true;
                            start = j;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        diffNum[i] = randomNum;
                    }
                    else
                    {
                        randomDiffNum(m, n, start, end, diffNum);
                    }
                }
            }
        }
    }
}
