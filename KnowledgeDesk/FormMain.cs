using KnowledgeDesk.CommonFrm.Floor;
using KnowledgeDesk.CommonFrm.Room;
using KnowledgeModel.Common;
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

        }

        private void QueryFloor()
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Floor/QueryFloor", strPost, "Get", ref strErr);

            this.dgvFloor.DataSource = result.DTData;
            AutoSize(dgvFloor);
        }

        private void QueryRoom()
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Room/QueryRoom", strPost, "Get", ref strErr);

            this.dgvRoom.DataSource = result.DTData;
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
            foreach (DataGridViewRow row in dgvRoom.Rows)
            {
                if (row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value)
                {
                    MessageBox.Show(row.Cells["RoomName"].Value.ToString());
                }
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
    }
}
