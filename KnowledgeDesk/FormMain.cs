using KnowledgeDesk.CommonFrm.AnswerInfo;
using KnowledgeDesk.CommonFrm.Car;
using KnowledgeDesk.CommonFrm.Floor;
using KnowledgeDesk.CommonFrm.Room;
using KnowledgeModel.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeDesk
{
    public partial class frmKnowledge : Form
    {
        public frmKnowledge()
        {
            InitializeComponent();
        }

        private void frmKnowledge_Load(object sender, EventArgs e)
        {
            //DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            //newColumn.HeaderText = "选择";
            //dgvFloor.Columns.Insert(0,newColumn);

            //DataTable dt = new DataTable();
            //dt.Columns.Add("楼层");
            //dt.Columns.Add("描述");
            //dt.Columns.Add("创建人");
            //dt.Columns.Add("创建时间");
            //DataRow dr = dt.NewRow();
            //dr["楼层"] = "0";
            //dr["描述"] = "地基";
            //dr["创建人"] = "admin";
            //dr["创建时间"] = DateTime.Now.ToString();

            //dt.Rows.Add(dr);
            QueryFloor();
            QueryRoom();
            QueryCar();
        }

        private void btnAddFloor_Click(object sender, EventArgs e)
        {
            AddFloor frm = new AddFloor();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                //更新列表
                QueryFloor();
            }
        }

        private void btnDelFloor_Click(object sender, EventArgs e)
        {
            string strFloorIDs = "";
            foreach (DataGridViewRow row in dgvFloor.Rows)
            {
                if (row.Cells["colSelected"].Value != null && (bool)row.Cells["colSelected"].Value)
                {
                    strFloorIDs += row.Cells["FloorID"].Value.ToString() + ",";
                }
            }
            if(string.IsNullOrEmpty(strFloorIDs))
            {
                MessageBox.Show("请选择楼层！");
                return;
            }
            //验证有没有房间
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "FloorID=" + strFloorIDs.TrimEnd(',');
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/QueryRoomByFloorID", strPost, "Get", ref strErr);
            if (result.DTData.Rows.Count > 0)
            {
                MessageBox.Show("选择楼层中存在房间，操作失败");
                return;
            }
            else
            {
                ExecResult resultDel = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Floor/DelFloor", strPost, "Get", ref strErr);
                MessageBox.Show("操作成功");
                QueryFloor();
            }
        }
        private void QueryCar()
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/QueryCar", strPost, "Get", ref strErr);

            this.dgvCar.DataSource = result.DTData;
            if (result.DTData.Columns.Count > 0)
                this.dgvCar.Columns[1].Visible = false;
            AutoSize(dgvCar);
        }
        private void QueryFloor()
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Floor/QueryFloor", strPost, "Get", ref strErr);

            this.dgvFloor.DataSource = result.DTData;
            if (result.DTData.Columns.Count > 0)
                this.dgvFloor.Columns[1].Visible = false;
            AutoSize(dgvFloor);
        }

        private void QueryRoom()
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/QueryRoom", strPost, "Get", ref strErr);

            this.dgvRoom.DataSource = result.DTData;
            if(result.DTData.Columns.Count>0)
                this.dgvRoom.Columns[1].Visible = false;
            AutoSize(dgvRoom);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            AddRoom frm = new AddRoom();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                //更新列表
                QueryRoom();
            }
        }

        private void btnDelRoom_Click(object sender, EventArgs e)
        {
            string strRoomIDs = "";
            foreach (DataGridViewRow row in dgvRoom.Rows)
            {
                if (row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value)
                {
                    strRoomIDs+=row.Cells["RoomID"].Value.ToString()+",";
                }
            }

            //验证有没有卡牌
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "RoomIDs="+strRoomIDs.TrimEnd(',');
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/QueryCarByRoomIDs", strPost, "Get", ref strErr);
            if(result.DTData.Rows.Count>0)
            {
                MessageBox.Show("选择房间中存在卡牌，操作失败");
                return;
            }
            else
            {
                string postpara = "IDs=" + strRoomIDs.TrimEnd(',') ;
                ExecResult resultDel = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/DelRoom", postpara, "Get", ref strErr);
                MessageBox.Show("操作成功");
                QueryRoom();
            }

        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (dgvRoom.Columns[e.ColumnIndex].Name != "Selected") return;

            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvRoom.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && (bool)cell.Value)
            {
                cell.Value = false;
            }
            else
            {
                cell.Value = true;
            }
        }

        public void AutoSize(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddCar frm = new AddCar();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                QueryCar();
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            Answer frm = new Answer();
            frm.IsRandom = 1;
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Answer frm = new Answer();
            frm.IsRandom = 0;
            frm.ShowDialog();
        }

        private void dgvFloor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (dgvRoom.Columns[e.ColumnIndex].Name != "Selected") return;

            DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvFloor.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && (bool)cell.Value)
            {
                cell.Value = false;
            }
            else
            {
                cell.Value = true;
            }
        }

        private void btnChangeFloor_Click(object sender, EventArgs e)
        {
            List<int> RoomIDs = new List<int>();
            foreach (DataGridViewRow row in dgvRoom.Rows)
            {
                if (row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value)
                {
                    RoomIDs.Add(Convert.ToInt32(row.Cells["RoomID"].Value));
                }
            }
            if(RoomIDs.Count!=1)
            {
                MessageBox.Show("只能选择一个房间！");
                return;
            }
            AddRoom frm = new AddRoom();
            frm.RoomID = RoomIDs.First();
            if(frm.ShowDialog()==DialogResult.Yes)
            {
                QueryRoom();
            }
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            List<int> CarIDs = new List<int>();
            foreach (DataGridViewRow row in dgvCar.Rows)
            {
                if (row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value)
                {
                    CarIDs.Add(Convert.ToInt32(row.Cells["CarID"].Value));
                }
            }
            if (CarIDs.Count != 1)
            {
                MessageBox.Show("只能选择单张卡牌！");
                return;
            }
            AddCar frm = new AddCar();
            if (frm.ShowDialog() == DialogResult.Yes)
            {
                QueryCar();
            }
        }
    }
}
