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
        public int RoomID = 0;
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
            room.RoomID = RoomID;
            string strPost = JsonConvert.SerializeObject(room);
            ExecResult result = null;
            if (RoomID == 0)
            {
                result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/AddRoom", strPost, "Post", ref strErr);
            }
            else
            {
                result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/UpdateRoom", strPost, "Post", ref strErr);
            }
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
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Floor/QueryFloor", strPost, "Get", ref strErr);


            this.cmbFloor.DataSource = result.DTData;
            this.cmbFloor.DisplayMember = "楼层";
            this.cmbFloor.ValueMember = "FloorID";
            this.cmbFloor.SelectedIndex = -1;

            if(RoomID!=0)
            {
                strPost = "RoomID="+RoomID.ToString();
                ExecResult resultRoom = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/QueryRoomByID", strPost, "Get", ref strErr);
                this.txtRoomName.Text = resultRoom.DTData.Rows[0]["RoomName"].ToString();
                this.txtDes.Text= resultRoom.DTData.Rows[0]["RoomDesc"].ToString();
                this.cmbFloor.SelectedValue= Convert.ToInt32(resultRoom.DTData.Rows[0]["FloorID"]);
            }
        }
    }
}
