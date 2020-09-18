using KnowledgeModel.Car;
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

namespace KnowledgeDesk.CommonFrm.Car
{
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void AddCar_Load(object sender, EventArgs e)
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

        private void cmbFloor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "FloorID=" + cmbFloor.SelectedValue.ToString();
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Room/QueryRoomByFloorID", strPost, "Get", ref strErr);


            this.cmbRoom.DataSource = result.DTData;
            this.cmbRoom.DisplayMember = "RoomName";
            this.cmbRoom.ValueMember = "RoomID";
            this.cmbRoom.SelectedIndex = -1;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCarQuestion.Text.Trim()))
            {
                MessageBox.Show("请填写牌面！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtAnswer.Text.Trim()))
            {
                MessageBox.Show("请填写答案！");
                return;
            }
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            CarModel car = new CarModel();
            car.CarQuestion = this.txtCarQuestion.Text.Trim();
            car.CarAnswer = this.txtAnswer.Text.Trim();
            car.FloorID =Convert.ToInt32(this.cmbFloor.SelectedValue);
            car.RoomID = Convert.ToInt32(this.cmbRoom.SelectedValue);
            car.CreateUser = "Admin";
            car.CreateTime = DateTime.Now;
            car.IsStop = 0;
            car.EmployeeID = 1;
            string strPost = JsonConvert.SerializeObject(car);
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Car/AddCar", strPost, "Post", ref strErr);
            if (result.Data[0].Success)
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
    }
}
