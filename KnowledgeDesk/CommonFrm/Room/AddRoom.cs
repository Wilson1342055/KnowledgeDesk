using KnowledgeModel.Common;
using KnowledgeModel.Room;
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

namespace KnowledgeDesk.CommonFrm.Room
{
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtRoomName.Text.Trim()))
            {
                MessageBox.Show("请填写房间名称！");
                return;
            }
            if (string.IsNullOrEmpty(this.cmbFloor.Text.Trim()))
            {
                MessageBox.Show("请填写所在楼层！");
                return;
            }
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            RoomModel room = new RoomModel();
            room.RoomName = this.txtRoomName.Text.Trim();
            room.RoomDesc = this.txtDes.Text.Trim();
            room.CreateUser = "Admin";
            room.CreateTime = DateTime.Now;
            room.FloorID = Convert.ToInt32(this.cmbFloor.SelectedValue);
            string strPost = JsonConvert.SerializeObject(room);
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Room/AddRoom", strPost, "Post", ref strErr);
            if(result.Data[0].Success)
            {
                MessageBox.Show(result.Data[0].Remark);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.Data[0].Remark);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Floor/QueryFloor", strPost, "Get", ref strErr);


            this.cmbFloor.DataSource = result.DTData;
            this.cmbFloor.DisplayMember = "楼层";
            this.cmbFloor.ValueMember = "FloorID";
            this.cmbFloor.SelectedIndex = -1;
        }
    }
}
