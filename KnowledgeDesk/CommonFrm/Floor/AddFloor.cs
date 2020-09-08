using KnowledgeModel.Common;
using KnowledgeModel.Floor;
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

namespace KnowledgeDesk.CommonFrm.Floor
{
    public partial class AddFloor : Form
    {
        public AddFloor()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtFloorName.Text.Trim()))
            {
                MessageBox.Show("请填写楼层名称！");
                return;
            }
            KnowledgeDesk.ActionHelper.WebAPIHelper webapi = new ActionHelper.WebAPIHelper();
            string strErr = "";
            FloorModel floor = new FloorModel();
            floor.FloorName = this.txtFloorName.Text.Trim();
            floor.FloorDesc = this.txtDes.Text.Trim();
            floor.CreateUser = "Admin";
            floor.CreateTime = DateTime.Now;
            string strPost = JsonConvert.SerializeObject(floor);
            ExecResult result = webapi.ExecuteResultList("http://localhost:54072/api/Floor/AddFloor", strPost, "Post", ref strErr);
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
    }
}
