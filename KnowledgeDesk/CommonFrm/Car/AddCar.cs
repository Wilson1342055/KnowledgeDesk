using KnowledgeModel.Car;
using KnowledgeModel.Common;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace KnowledgeDesk.CommonFrm.Car
{
    public partial class AddCar : Form
    {
        public int CarID = 0;
        public AddCar()
        {
            InitializeComponent();
        }

        private void AddCar_Load(object sender, EventArgs e)
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1";
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Floor/QueryFloor", strPost, "Get", ref strErr);


            this.cmbFloor.DataSource = result.DTData;
            this.cmbFloor.DisplayMember = "楼层";
            this.cmbFloor.ValueMember = "FloorID";
            this.cmbFloor.SelectedIndex = -1;

            if(CarID>0)
            {
                strPost = "CarID="+CarID.ToString();
                result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/QueryCarByID", strPost, "Get", ref strErr);
                this.txtCarQuestion.Text = result.DTData.Rows[0]["CarQuestion"].ToString();
                this.txtAnswer.Text= result.DTData.Rows[0]["CarAnswer"].ToString();
                this.cmbFloor.SelectedValue=Convert.ToInt32(result.DTData.Rows[0]["FloorID"]);
                this.cmbRoom.SelectedValue = Convert.ToInt32(result.DTData.Rows[0]["RoomID"]);
                this.lbPoints.Text = result.DTData.Rows[0]["Points"].ToString();
            }
        }

        private void cmbFloor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "FloorID=" + cmbFloor.SelectedValue.ToString();
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Room/QueryRoomByFloorID", strPost, "Get", ref strErr);


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
            if (CarID == 0)
            {
                car.CreateUser = "Admin";
                car.CreateTime = DateTime.Now;
                car.IsStop = 0;
                car.EmployeeID = 1;
                car.Points = 0.8M;
            }
            else
            {
                car.CarID = CarID;
                car.Points = Convert.ToDecimal(this.lbPoints.Text);
            }
            string strPost = JsonConvert.SerializeObject(car);
            ExecResult result = null;
            if (CarID == 0)
            {
                result= webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/AddCar", strPost, "Post", ref strErr);
            }
            else
            {
                result= webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/UpdateCar", strPost, "Post", ref strErr);
            }
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
