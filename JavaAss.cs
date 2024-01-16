using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_111
{
    public partial class JavaAss : Form
    {
        public JavaAss()
        {
            InitializeComponent();
        }
        public string old, newN;
        public int use=0, pay=1;
        public int[] monthly = new int[100];
        public int monthlyUsed=0,monthlyPay=1,i=0,j;
        private void btnRes_Click(object sender, EventArgs e)
        {
            txtNew.Clear();
            txtOld.Clear();
            txtUse.Clear();
            txtPay.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JavaAss_Load(object sender, EventArgs e)
        {

        }

        private void tblList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblList.SelectedItems.Count > 0)
            {
                btnRemove.Visible = true;
            }
            else
            {
                btnRemove.Visible = false;
            }
        }

        private void btnRemove2_Click(object sender, EventArgs e)
        {
            DialogResult MessageDelete = MessageBox.Show("Are you sure want to delete this record ?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (MessageDelete == DialogResult.Yes)
            {
                tblListMonthly.Items.Remove(tblListMonthly.SelectedItems[0]);
            }
        }

        private void tblListMonthly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblListMonthly.SelectedItems.Count > 0)
            {
                btnRemove2.Visible = true;
            }
            else
            {
                btnRemove2.Visible = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult UserAnswer = MessageBox.Show("Are you sure want to delete this record ?",
                "Confirm",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
                if (UserAnswer == DialogResult.Yes)
                {
                    tblList.Items.Remove(tblList.SelectedItems[0]);
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            old = txtOld.Text; 
            newN = txtNew.Text;
            use = Convert.ToInt32(newN)-Convert.ToInt32(old);
            txtUse.Text = use.ToString()+"KW";
            pay = calcMoney(use, pay);
            txtPay.Text = pay.ToString();
            ListViewItem tblListVar = new ListViewItem(old);
            tblListVar.SubItems.Add(newN);
            tblListVar.SubItems.Add(use.ToString());
            tblListVar.SubItems.Add(pay.ToString());
            tblListVar.Name = old;
            if (txtOld.Text == String.Empty)
            {
                Msg("The Old Input field Cannot be Empty !");
            }
            else if (txtNew.Text == String.Empty)
            {
                Msg("The New Input field Cannot be Empty !");
            }
            else
            {
                if (tblList.Items.ContainsKey(old))
                {
                    Msg("The Old Input field cannot be the same !");
                }
                else if (Convert.ToInt32(newN) < Convert.ToInt32(old))
                {
                    Msg("វាមិនដែលអាណាលេខកុងទ័រចាស់ធំជាងលេខកុងទ័រថ្មី​ !");
                    txtNew.Clear();
                    txtOld.Clear();
                    txtUse.Clear();
                    txtPay.Clear();
                    txtNew.Focus();
                }
                else
                {
                    tblList.Items.Add(tblListVar);
                    for (i = 0; i < tblList.Items.Count; i++)
                    {
                        monthly[i] = Convert.ToInt32(tblList.Items[i].SubItems[2].Text);
                    }
                }
                if (tblList.Items.Count % 6 == 0)
                {
                    for (j=i-6; j<tblList.Items.Count; j++)
                    {
                        monthlyUsed = monthlyUsed + monthly[j];
                    }
                    monthlyPay = calcMoney(monthlyUsed, monthlyPay);
                    ListViewItem ListTableMonthly = new ListViewItem(monthlyUsed.ToString());
                    ListTableMonthly.SubItems.Add(monthlyPay.ToString());
                    tblListMonthly.Items.Add(ListTableMonthly);
                    monthlyUsed = 0;
                    tblList.Items.Clear();
                }
            }
        }
        public static void Msg(string msg)
        {
            MessageBox.Show(msg,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        private static int calcMoney(int use, int pay)
        {
            if (use <= 100)
            {
                pay = use * 500;
            }
            else if (use <= 200)
            {
                pay = 50000 + ((use - 100) * 700);
            }
            else if (use <= 300)
            {
                pay = 120000 + ((use - 200) * 1000);
            }
            else if (use > 300)
            {
                pay = 220000 + ((use - 300) * 1500);
            }
            return pay;
        }
    }
}
