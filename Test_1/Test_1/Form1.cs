using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_1
{
    public partial class Form1 : Form
    {
        string chuoi = @"Data Source=ELLLLL;Initial Catalog=QLSV;Integrated Security=True";
        SqlConnection connect = null;
        string deleteRow = "";
        int curRow;
        public Form1()
        {
            InitializeComponent();
            connecDaTa();
            loadData();
        }
        void connecDaTa()
        {
            
            if(connect == null)
            {
                connect = new SqlConnection(chuoi);
            }
            if(connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
        }
        private void loadData()
        {
            string sql = "select *from sv";
            SqlCommand sqlCommand = new SqlCommand(sql, connect);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGrid.DataSource = dataTable;
            tao();
            connect.Close();
        }
        void tao()
        {
            dataGrid.Columns[0].Width = 100;
            dataGrid.Columns[0].HeaderText = "Mã SV";
            dataGrid.Columns[1].Width = 210;
            dataGrid.Columns[1].HeaderText = "Họ và tên";
            dataGrid.Columns[2].Width = 150;
            dataGrid.Columns[2].HeaderText = "Giới tính";
            dataGrid.Columns[3].Width = 110;
            dataGrid.Columns[3].HeaderText = "Ngày sinh";
            dataGrid.Columns[4].Width = 200;
            dataGrid.Columns[4].HeaderText = "Quê quán";
            dataGrid.Columns[5].Width = 150;
            dataGrid.Columns[5].HeaderText = "Số điện thoại";
            dataGrid.Columns[6].Width = 70;
            dataGrid.Columns[6].HeaderText = "Điểm A1";
            dataGrid.Columns[7].Width = 70;
            dataGrid.Columns[7].HeaderText = "Điểm A2";
            dataGrid.Columns[8].Width = 70;
            dataGrid.Columns[8].HeaderText = "Điểm A3";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell curCel = dataGrid.CurrentCell;
            curRow = curCel.RowIndex;
            dataGrid.Rows[curRow].Selected = true;
            deleteRow = dataGrid.Rows[curRow].Cells[0].Value.ToString();
            txtCode.Text = dataGrid.Rows[curRow].Cells[0].Value.ToString();
            txtName.Text = dataGrid.Rows[curRow].Cells[1].Value.ToString();
            if(dataGrid.Rows[curRow].Cells[2].Value.ToString() == "Nam")
            {
                radMale.Checked = true;
            }
            else
            {
                radFeMale.Checked = true;
            }
            txtBirrth.Text = String.Format("{0:yyyy-MM-dd}", dataGrid.Rows[curRow].Cells[3].Value);
            txtAddress.Text = dataGrid.Rows[curRow].Cells[4].Value.ToString();
            txtPhone.Text = dataGrid.Rows[curRow].Cells[5].Value.ToString();
            txtA1.Text = dataGrid.Rows[curRow].Cells[6].Value.ToString();
            txtA2.Text = dataGrid.Rows[curRow].Cells[7].Value.ToString();
            txtA3.Text = dataGrid.Rows[curRow].Cells[8].Value.ToString();
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtBirrth.Enabled = false;
            txtAddress.Enabled = false;
            radMale.Enabled = false;
            radFeMale.Enabled = false;
            bttAdd.Enabled = false;
            txtCode.Text = dataGrid.Rows[curRow].Cells[0].Value.ToString();
        }

        private void txtBirrth_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bttRemove_Click(object sender, EventArgs e)
        {
            dataGrid.Rows[curRow].Selected = false;
            txtCode.Text = "";
            txtCode.Enabled = true;
            radMale.Checked = false;
            radFeMale.Checked = false;
            txtName.Text = "";
            txtBirrth.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtA1.Text = "";
            txtA2.Text = "";
            txtA3.Text = "";
            txtName.Enabled = true;
            txtBirrth.Enabled = true;
            txtAddress.Enabled = true;
            radMale.Enabled = true;
            radFeMale.Enabled = true;
            bttAdd.Enabled = true;
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            try { 
            string code = txtCode.Text.ToString();
            string fullName = txtName.Text.ToString();
            string sex = "";
            if (radFeMale.Checked == true)
            {
                sex = "Nữ";
            }
            else if (radMale.Checked == true)
            {
                sex = "Nam";
            }
            else
            {
                sex = "";
            }
            string birth = txtBirrth.Text.ToString();
            string addres = txtAddress.Text.ToString();
            string phone = txtPhone.Text.ToString();
            float a1 = float.Parse(txtA1.Text);
            float a2 = float.Parse(txtA2.Text);
            float a3 = float.Parse(txtA3.Text);
            if (fullName == "" || birth == "" || addres == "" || phone == "" || sex == "" || a1 > 10 || a1 < 0 || a2 > 10 || a2 < 0 || a3 > 10 || a3 < 0)
            {
                MessageBox.Show("Bạn chưa nhập đúng/đủ dữ liệu!");
            }
            if (phone.ToString().Length != 10)
            {
                MessageBox.Show("Số điện thoại bạn nhập chưa đúng!");
            }
            string sql = "Insert into sv values('" + code + "',N'" + fullName + "', N'" + sex + "','" + birth + "',N'" + addres + "', '" + phone + "', " + a1 + "," + a2 + "," + a3 + ")";
            SqlCommand sqlCommand = new SqlCommand(sql, connect);
            MessageBox.Show(sql);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Đã thêm mới sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setInfo();
            loadData();
        }
            catch (Exception loi)
            {
                Console.WriteLine("Loi !!! " + loi);
            }
            finally
            {
                connect.Close();
            }
        }
        void setCode()
        {
            connecDaTa();
            string sql1 = "SELECT TOP 1 code FROM sv ORDER BY code DESC;";
            SqlCommand cmd = new SqlCommand(sql1, connect);
            string code = Convert.ToString(cmd.ExecuteScalar());
            string masv = "";
            if(code == "")
            {
                masv = "SV01";
            }
            else
            {
                Int32 code1 = Convert.ToInt32(code.Remove(0, 2));
                if ((code1.ToString().Length == 2) || (code1.ToString().Length == 1 && code1 == 9))
                {
                    code1 += 1;
                    masv = "SV" + code1.ToString();
                }
                else if (code1.ToString().Length == 1 && code1 < 9)
                {
                    code1 += 1;
                    masv = "SV0" + code1.ToString();
                }
                
            }
            txtCode.Text = masv;
            txtCode.Enabled = false;
        }

        private void txtA3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            setCode();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtA1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtA2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            
        }
        void setInfo()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            radFeMale.Checked = false;
            radMale.Checked = false;
            txtBirrth.Text = "";
            txtPhone.Text = "";
            txtA1.Text = "";
            txtA2.Text = "";
            txtA3.Text = "";
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            connecDaTa();
            try
            {
                if (deleteRow != "")
                {
                    string sql = "DELETE FROM sv Where Code = '" + deleteRow + "';";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    deleteRow = "";
                    setInfo();
                    loadData();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào!");
                }

            }
            catch (Exception loi)
            {
                MessageBox.Show("Lỗi " + loi);
            }
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            connecDaTa();
            try
            {
                string code = txtCode.Text.ToString();
                string adress = txtAddress.Text.ToString();
                string phoneNumber = txtPhone.Text.ToString();
                float a1 = float.Parse(txtA1.Text);
                float a2 = float.Parse(txtA2.Text);
                float a3 = float.Parse(txtA3.Text);
                if (adress == "" || phoneNumber == "" || phoneNumber.Length != 10)
                {
                    MessageBox.Show("Bạn chưa nhập đủ dữ liệu hoặc sai dữ liệu!");
                }
                else
                {
                    string sql = "UPDATE sv SET addres=N'" + adress + "', phone ='" + phoneNumber + "', score_A1 = " + a1 + ", score_A2 = " + a2 + ", score_A3 = " + a3+ " WHERE code = '" + code + "'";
                    MessageBox.Show(sql);
                    SqlCommand cmd1 = new SqlCommand(sql, connect);
                    cmd1.ExecuteNonQuery();
                    loadData();
                    
                    MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch (Exception loi)
            {
                Console.WriteLine("Loi !!! " + loi);
            }
            finally
            {
                connect.Close();
            }


        }
    }
 }