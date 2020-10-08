using KnowledgeModel.AnswerInfo;
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

namespace KnowledgeDesk.CommonFrm.AnswerInfo
{
    public partial class Answer : Form
    {
        public int IsRandom = 0;
        private string strResult = "";
        public Answer()
        {
            InitializeComponent();
        }

        private void Answer_Load(object sender, EventArgs e)
        {
            //获取题目
            GetQuestion();

        }

        private void GetQuestion()
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            string strPost = "EmployeeID=1&IsRandom=" + IsRandom.ToString();
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/GetCarAnswer", strPost, "Get", ref strErr);
            DataTable dt = result.DTData;
            this.lbFloor.Text = dt.Rows[0]["FloorName"].ToString();
            this.lbRoom.Text = dt.Rows[0]["RoomName"].ToString();
            this.txtQuestion.Text = dt.Rows[0]["CarQuestion"].ToString();
            this.txtReal.Text = dt.Rows[0]["CarAnswer"].ToString();
            this.lbCarID.Text = dt.Rows[0]["CarID"].ToString();
            this.lbPoints.Text = dt.Rows[0]["Points"].ToString();
            //设置宽度  414
            this.Width = 414;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //新增答题情况
            AnswerInfoModel model = new AnswerInfoModel();
            model.AnswerContent = this.txtAnswer.Text;
            model.CarID =Convert.ToInt32(this.lbCarID.Text);
            model.CreateTime = DateTime.Now;
            model.CreateUser = "admin";
            model.EmployeeID = 1;
            string strPost = JsonConvert.SerializeObject(model);
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/AnswerInfo/AddAnswerInfo", strPost, "Post", ref strErr);
            if (result.Data[0].Success)
            {
                this.lbAnswerID.Text = result.Data[0].DocumentNo;
                this.Width = 802;
                this.btnCommit.Enabled = false;
                this.btnNext.Enabled = true;
            }
            else
            {
                MessageBox.Show("操作失败，请重新提交");
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //验证是否有结论

            //更新答题结果
            AnswerInfoModel model = new AnswerInfoModel();
            model.AnswerResult = strResult;
            model.AnswerInfoID = Convert.ToInt32(this.lbAnswerID.Text);
            string strPost = JsonConvert.SerializeObject(model);
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            ExecResult result = webapi.ExecuteResultList("http://119.29.105.131:8099/api/AnswerInfo/UpdateAnswerInfo", strPost, "Post", ref strErr);
            if (result.Data[0].Success)
            {
                //更新卡牌分数
                CarModel car = new CarModel();
                car.CarID = Convert.ToInt32(this.lbCarID.Text);
                switch (strResult)
                {
                    case "未掌握":
                        car.Points = 0.6M;
                        break;
                    case "模糊":
                        car.Points = 0.8M;
                        break;
                    case "完全掌握":
                        car.Points = Convert.ToDecimal(this.lbPoints.Text)+0.1M;
                        break;

                }
                car.CarQuestion = this.txtQuestion.Text;
                car.CarAnswer = this.txtReal.Text;
                string strPostCar = JsonConvert.SerializeObject(car);
                ExecResult resultCar = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/UpdateCar", strPostCar, "Post", ref strErr);
                if (resultCar.Data[0].Success)
                {
                    //设置宽度
                    this.Width = 414;
                }
                else
                {
                    MessageBox.Show("操作失败，请重试");
                    return;
                }
            }

            this.txtAnswer.Text = "";
            this.txtQuestion.Text = "";
            this.txtReal.Text = "";
            this.btnCommit.Enabled = true;
            this.btnNext.Enabled = false;
            this.rbnlike.Checked = false;
            this.rbnno.Checked = false;
            this.rbnyes.Checked = false;
            GetQuestion();
        }

        private void rbnno_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                strResult = rb.Text;
            }
        }

        private void rbnlike_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                strResult = rb.Text;
            }
        }

        private void rbnyes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                strResult = rb.Text;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            CarModel car = new CarModel();
            car.CarID = Convert.ToInt32(this.lbCarID.Text);
            car.Points = 0.6M;
            string strPostCar = JsonConvert.SerializeObject(car);
            ExecResult resultCar = webapi.ExecuteResultList("http://119.29.105.131:8099/api/Car/UpdateCar", strPostCar, "Post", ref strErr);
            if (resultCar.Data[0].Success)
            {
                //设置宽度
                this.Width = 414;
            }
            else
            {
                MessageBox.Show("操作失败，请重试");
                return;
            }
            this.txtAnswer.Text = "";
            this.txtQuestion.Text = "";
            this.txtReal.Text = "";
            this.btnCommit.Enabled = true;
            this.btnNext.Enabled = false;
            this.rbnlike.Checked = false;
            this.rbnno.Checked = false;
            this.rbnyes.Checked = false;
            GetQuestion();
        }
    }
}
