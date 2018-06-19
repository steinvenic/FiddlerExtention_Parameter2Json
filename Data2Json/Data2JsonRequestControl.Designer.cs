namespace Data2Json
{
    partial class Data2JsonRequestControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HeaderBox = new System.Windows.Forms.TextBox();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DataBox = new System.Windows.Forms.TextBox();
            this.DataLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UrlBox = new System.Windows.Forms.TextBox();
            this.UrlLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dataGridView1.Location = new System.Drawing.Point(3, 334);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(618, 208);
            this.dataGridView1.TabIndex = 0;
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.Width = 48;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HeaderBox);
            this.panel1.Controls.Add(this.HeaderLabel);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 85);
            this.panel1.TabIndex = 2;
            // 
            // HeaderBox
            // 
            this.HeaderBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HeaderBox.Location = new System.Drawing.Point(0, 15);
            this.HeaderBox.Multiline = true;
            this.HeaderBox.Name = "HeaderBox";
            this.HeaderBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HeaderBox.Size = new System.Drawing.Size(618, 70);
            this.HeaderBox.TabIndex = 1;
            this.HeaderBox.Click += new System.EventHandler(this.CopyHeaderContent);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.HeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(47, 12);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Header";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DataBox);
            this.panel2.Controls.Add(this.DataLabel);
            this.panel2.Location = new System.Drawing.Point(3, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 85);
            this.panel2.TabIndex = 3;
            // 
            // DataBox
            // 
            this.DataBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataBox.Location = new System.Drawing.Point(0, 15);
            this.DataBox.Multiline = true;
            this.DataBox.Name = "DataBox";
            this.DataBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataBox.Size = new System.Drawing.Size(618, 70);
            this.DataBox.TabIndex = 1;
            this.DataBox.Click += new System.EventHandler(this.CopyDataContent);
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataLabel.ForeColor = System.Drawing.Color.Orange;
            this.DataLabel.Location = new System.Drawing.Point(0, 0);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(33, 12);
            this.DataLabel.TabIndex = 0;
            this.DataLabel.Text = "Data";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.UrlBox);
            this.panel3.Controls.Add(this.UrlLabel);
            this.panel3.Location = new System.Drawing.Point(3, 220);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 80);
            this.panel3.TabIndex = 3;
            // 
            // UrlBox
            // 
            this.UrlBox.BackColor = System.Drawing.SystemColors.Window;
            this.UrlBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UrlBox.Location = new System.Drawing.Point(0, 15);
            this.UrlBox.Multiline = true;
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UrlBox.Size = new System.Drawing.Size(618, 101);
            this.UrlBox.TabIndex = 1;
            this.UrlBox.Click += new System.EventHandler(this.copyUrlContent);
            // 
            // UrlLabel
            // 
            this.UrlLabel.AutoSize = true;
            this.UrlLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UrlLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.UrlLabel.Location = new System.Drawing.Point(0, 0);
            this.UrlLabel.Name = "UrlLabel";
            this.UrlLabel.Size = new System.Drawing.Size(26, 12);
            this.UrlLabel.TabIndex = 0;
            this.UrlLabel.Text = "Url";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.hostLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hostLabel.Location = new System.Drawing.Point(35, 220);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(54, 12);
            this.hostLabel.TabIndex = 2;
            this.hostLabel.Text = "hostUrl";
            this.hostLabel.Click += new System.EventHandler(this.copyHostUrlContent);
            // 
            // Data2JsonRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Data2JsonRequestControl";
            this.Size = new System.Drawing.Size(627, 545);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox HeaderBox;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox DataBox;
        private System.Windows.Forms.Label DataLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox UrlBox;
        private System.Windows.Forms.Label UrlLabel;
        private System.Windows.Forms.Label hostLabel;
    }
}
