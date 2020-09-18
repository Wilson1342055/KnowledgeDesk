namespace KnowledgeDesk.CommonFrm.AnswerInfo
{
    partial class Answer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbFloor = new System.Windows.Forms.Label();
            this.lbRoom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReal = new System.Windows.Forms.TextBox();
            this.rbnno = new System.Windows.Forms.RadioButton();
            this.rbnlike = new System.Windows.Forms.RadioButton();
            this.rbnyes = new System.Windows.Forms.RadioButton();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbCarID = new System.Windows.Forms.Label();
            this.lbAnswerID = new System.Windows.Forms.Label();
            this.lbPoints = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbFloor
            // 
            this.lbFloor.AutoSize = true;
            this.lbFloor.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFloor.Location = new System.Drawing.Point(83, 24);
            this.lbFloor.Name = "lbFloor";
            this.lbFloor.Size = new System.Drawing.Size(58, 24);
            this.lbFloor.TabIndex = 0;
            this.lbFloor.Text = "楼层";
            // 
            // lbRoom
            // 
            this.lbRoom.AutoSize = true;
            this.lbRoom.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRoom.Location = new System.Drawing.Point(262, 24);
            this.lbRoom.Name = "lbRoom";
            this.lbRoom.Size = new System.Drawing.Size(58, 24);
            this.lbRoom.TabIndex = 1;
            this.lbRoom.Text = "房间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "问题：";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(87, 69);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(291, 111);
            this.txtQuestion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "回答：";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(87, 198);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(291, 163);
            this.txtAnswer.TabIndex = 5;
            // 
            // btnNo
            // 
            this.btnNo.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNo.Location = new System.Drawing.Point(87, 387);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(81, 33);
            this.btnNo.TabIndex = 6;
            this.btnNo.Text = "不会";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // btnCommit
            // 
            this.btnCommit.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCommit.Location = new System.Drawing.Point(188, 387);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(81, 33);
            this.btnCommit.TabIndex = 7;
            this.btnCommit.Text = "提交";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(397, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "答案：";
            // 
            // txtReal
            // 
            this.txtReal.Location = new System.Drawing.Point(471, 198);
            this.txtReal.Multiline = true;
            this.txtReal.Name = "txtReal";
            this.txtReal.Size = new System.Drawing.Size(291, 163);
            this.txtReal.TabIndex = 9;
            // 
            // rbnno
            // 
            this.rbnno.AutoSize = true;
            this.rbnno.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbnno.Location = new System.Drawing.Point(471, 387);
            this.rbnno.Name = "rbnno";
            this.rbnno.Size = new System.Drawing.Size(87, 24);
            this.rbnno.TabIndex = 10;
            this.rbnno.TabStop = true;
            this.rbnno.Text = "未掌握";
            this.rbnno.UseVisualStyleBackColor = true;
            this.rbnno.CheckedChanged += new System.EventHandler(this.rbnno_CheckedChanged);
            // 
            // rbnlike
            // 
            this.rbnlike.AutoSize = true;
            this.rbnlike.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbnlike.Location = new System.Drawing.Point(573, 387);
            this.rbnlike.Name = "rbnlike";
            this.rbnlike.Size = new System.Drawing.Size(67, 24);
            this.rbnlike.TabIndex = 11;
            this.rbnlike.TabStop = true;
            this.rbnlike.Text = "模糊";
            this.rbnlike.UseVisualStyleBackColor = true;
            this.rbnlike.CheckedChanged += new System.EventHandler(this.rbnlike_CheckedChanged);
            // 
            // rbnyes
            // 
            this.rbnyes.AutoSize = true;
            this.rbnyes.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbnyes.Location = new System.Drawing.Point(655, 387);
            this.rbnyes.Name = "rbnyes";
            this.rbnyes.Size = new System.Drawing.Size(107, 24);
            this.rbnyes.TabIndex = 12;
            this.rbnyes.TabStop = true;
            this.rbnyes.Text = "完全掌握";
            this.rbnyes.UseVisualStyleBackColor = true;
            this.rbnyes.CheckedChanged += new System.EventHandler(this.rbnyes_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(297, 387);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(81, 33);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "下一题";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbCarID
            // 
            this.lbCarID.AutoSize = true;
            this.lbCarID.Location = new System.Drawing.Point(471, 69);
            this.lbCarID.Name = "lbCarID";
            this.lbCarID.Size = new System.Drawing.Size(35, 12);
            this.lbCarID.TabIndex = 14;
            this.lbCarID.Text = "CarID";
            this.lbCarID.Visible = false;
            // 
            // lbAnswerID
            // 
            this.lbAnswerID.AutoSize = true;
            this.lbAnswerID.Location = new System.Drawing.Point(471, 95);
            this.lbAnswerID.Name = "lbAnswerID";
            this.lbAnswerID.Size = new System.Drawing.Size(53, 12);
            this.lbAnswerID.TabIndex = 15;
            this.lbAnswerID.Text = "AnswerID";
            this.lbAnswerID.Visible = false;
            // 
            // lbPoints
            // 
            this.lbPoints.AutoSize = true;
            this.lbPoints.Location = new System.Drawing.Point(471, 120);
            this.lbPoints.Name = "lbPoints";
            this.lbPoints.Size = new System.Drawing.Size(41, 12);
            this.lbPoints.TabIndex = 16;
            this.lbPoints.Text = "Points";
            this.lbPoints.Visible = false;
            // 
            // Answer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 458);
            this.Controls.Add(this.lbPoints);
            this.Controls.Add(this.lbAnswerID);
            this.Controls.Add(this.lbCarID);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.rbnyes);
            this.Controls.Add(this.rbnlike);
            this.Controls.Add(this.rbnno);
            this.Controls.Add(this.txtReal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbRoom);
            this.Controls.Add(this.lbFloor);
            this.Name = "Answer";
            this.Text = "答题";
            this.Load += new System.EventHandler(this.Answer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFloor;
        private System.Windows.Forms.Label lbRoom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReal;
        private System.Windows.Forms.RadioButton rbnno;
        private System.Windows.Forms.RadioButton rbnlike;
        private System.Windows.Forms.RadioButton rbnyes;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbCarID;
        private System.Windows.Forms.Label lbAnswerID;
        private System.Windows.Forms.Label lbPoints;
    }
}