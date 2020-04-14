namespace WCF_Server
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceStart = new System.Windows.Forms.Button();
            this.ServiceStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServiceStart
            // 
            this.ServiceStart.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ServiceStart.Location = new System.Drawing.Point(20, 30);
            this.ServiceStart.Name = "ServiceStart";
            this.ServiceStart.Size = new System.Drawing.Size(150, 30);
            this.ServiceStart.TabIndex = 0;
            this.ServiceStart.Text = "WCF Service Start";
            this.ServiceStart.UseVisualStyleBackColor = true;
            this.ServiceStart.Click += new System.EventHandler(this.ServerStart_Click);
            // 
            // ServiceStop
            // 
            this.ServiceStop.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ServiceStop.Location = new System.Drawing.Point(210, 30);
            this.ServiceStop.Name = "ServiceStop";
            this.ServiceStop.Size = new System.Drawing.Size(150, 30);
            this.ServiceStop.TabIndex = 1;
            this.ServiceStop.Text = "WCF Service Stop";
            this.ServiceStop.UseVisualStyleBackColor = true;
            this.ServiceStop.Click += new System.EventHandler(this.ServiceStop_Click);
            // 
            // ServerState
            // 
            this.ServerState.AutoSize = true;
            this.ServerState.Location = new System.Drawing.Point(160, 80);
            this.ServerState.Name = "ServerState";
            this.ServerState.Size = new System.Drawing.Size(0, 12);
            this.ServerState.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.ServerState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiceStop);
            this.Controls.Add(this.ServiceStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ServiceStart;
        private System.Windows.Forms.Button ServiceStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ServerState;
    }
}

