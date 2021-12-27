using LeThiYNhi.BLL.CongNo;
using LeThiYNhi.DTO.CongNo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeThiYNhi.GUI
{
    public partial class Form1 : Form
    {
        CongNoBLL cnBLL = new CongNoBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvCNo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            CongNoDTO cno = new CongNoDTO();
            if (tbId.Text.Length < 1)
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbId.Focus();
            }
            else
            {
                cno.IdCustomer = tbId.Text;
                cno.NameCustomer = tbName.Text;
                cno.NumberPhone = tbSdt.Text;
                cno.AmountOwed = decimal.Parse(tbStn.Text);

                cnBLL.NewCustomer(cno);
                dgvCNo.Rows.Add(cno.IdCustomer, cno.NameCustomer, cno.NumberPhone, cno.AmountOwed);
                MessageBox.Show("Đã thêm mới khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            CongNoDTO cno = new CongNoDTO();
            cno.IdCustomer = tbId.Text;
            cno.NameCustomer = tbName.Text;
            cno.NumberPhone = tbSdt.Text;
            cno.AmountOwed = decimal.Parse(tbStn.Text);

            cnBLL.DeleteCustomer(cno);


            DialogResult dg = MessageBox.Show("Bạn có chắn chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                int idx = dgvCNo.CurrentCell.RowIndex;
                dgvCNo.Rows.RemoveAt(idx);
            }
            MessageBox.Show("Đã xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            CongNoDTO cno = new CongNoDTO();
            if (tbId.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbId.Focus();
            }
            else
            {

                cno.IdCustomer = tbId.Text;
                cno.NameCustomer = tbName.Text;
                cno.NumberPhone = tbSdt.Text;
                cno.AmountOwed = decimal.Parse(tbStn.Text);
                cnBLL.EditCustomer(cno);

                DataGridViewRow row = dgvCNo.CurrentRow;
                row.Cells[0].Value = cno.IdCustomer;
                row.Cells[1].Value = cno.NameCustomer;
                row.Cells[2].Value = cno.NumberPhone;
                row.Cells[3].Value = cno.AmountOwed;

                MessageBox.Show("Đã sửa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CongNoDTO> lstCn = cnBLL.ReadCN();
            foreach (CongNoDTO cn in lstCn)
            {
                dgvCNo.Rows.Add(cn.IdCustomer, cn.NameCustomer, cn.NumberPhone, cn.AmountOwed);
            }
        }
    }
}
