namespace TestAssistant
{
    partial class Mainform
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TS_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.TS_help = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_about = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSL_connect = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSL_space = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSL_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_connect = new System.Windows.Forms.ToolStripButton();
            this.tsb_frock = new System.Windows.Forms.ToolStripButton();
            this.tsb_order = new System.Windows.Forms.ToolStripButton();
            this.tsb_record = new System.Windows.Forms.ToolStripButton();
            this.tsb_exit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_frock = new System.Windows.Forms.ComboBox();
            this.cb_object = new System.Windows.Forms.ComboBox();
            this.lb_object = new System.Windows.Forms.Label();
            this.tb_frock = new System.Windows.Forms.TextBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.tb_order = new System.Windows.Forms.TextBox();
            this.tb_person = new System.Windows.Forms.TextBox();
            this.lb_order = new System.Windows.Forms.Label();
            this.lb_frock = new System.Windows.Forms.Label();
            this.lb_person = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_record = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lv_frock = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_stop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Menu,
            this.TS_help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TS_Menu
            // 
            this.TS_Menu.Name = "TS_Menu";
            this.TS_Menu.Size = new System.Drawing.Size(44, 21);
            this.TS_Menu.Text = "菜单";
            // 
            // TS_help
            // 
            this.TS_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_about});
            this.TS_help.Name = "TS_help";
            this.TS_help.Size = new System.Drawing.Size(44, 21);
            this.TS_help.Text = "帮助";
            // 
            // TSMI_about
            // 
            this.TSMI_about.Name = "TSMI_about";
            this.TSMI_about.Size = new System.Drawing.Size(100, 22);
            this.TSMI_about.Text = "关于";
            this.TSMI_about.Click += new System.EventHandler(this.TSMI_about_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSL_connect,
            this.tSL_space,
            this.tSL_time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSL_connect
            // 
            this.tSL_connect.Name = "tSL_connect";
            this.tSL_connect.Size = new System.Drawing.Size(44, 17);
            this.tSL_connect.Text = "未连接";
            // 
            // tSL_space
            // 
            this.tSL_space.Name = "tSL_space";
            this.tSL_space.Size = new System.Drawing.Size(1092, 17);
            this.tSL_space.Spring = true;
            // 
            // tSL_time
            // 
            this.tSL_time.Name = "tSL_time";
            this.tSL_time.Size = new System.Drawing.Size(33, 17);
            this.tSL_time.Text = "time";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_connect,
            this.tsb_frock,
            this.tsb_order,
            this.tsb_record,
            this.tsb_exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 70);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_connect
            // 
            this.tsb_connect.AutoSize = false;
            this.tsb_connect.Image = ((System.Drawing.Image)(resources.GetObject("tsb_connect.Image")));
            this.tsb_connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_connect.Name = "tsb_connect";
            this.tsb_connect.Size = new System.Drawing.Size(60, 67);
            this.tsb_connect.Text = "通信参数";
            this.tsb_connect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_connect.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsb_frock
            // 
            this.tsb_frock.AutoSize = false;
            this.tsb_frock.Image = ((System.Drawing.Image)(resources.GetObject("tsb_frock.Image")));
            this.tsb_frock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_frock.Name = "tsb_frock";
            this.tsb_frock.Size = new System.Drawing.Size(60, 67);
            this.tsb_frock.Text = "工装列表";
            this.tsb_frock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_frock.Visible = false;
            this.tsb_frock.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsb_order
            // 
            this.tsb_order.AutoSize = false;
            this.tsb_order.Image = ((System.Drawing.Image)(resources.GetObject("tsb_order.Image")));
            this.tsb_order.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_order.Name = "tsb_order";
            this.tsb_order.Size = new System.Drawing.Size(60, 67);
            this.tsb_order.Text = "订单列表";
            this.tsb_order.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_order.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tsb_record
            // 
            this.tsb_record.AutoSize = false;
            this.tsb_record.Image = ((System.Drawing.Image)(resources.GetObject("tsb_record.Image")));
            this.tsb_record.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_record.Name = "tsb_record";
            this.tsb_record.Size = new System.Drawing.Size(60, 67);
            this.tsb_record.Text = "记录列表";
            this.tsb_record.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_record.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tsb_exit
            // 
            this.tsb_exit.AutoSize = false;
            this.tsb_exit.Image = ((System.Drawing.Image)(resources.GetObject("tsb_exit.Image")));
            this.tsb_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_exit.Name = "tsb_exit";
            this.tsb_exit.Size = new System.Drawing.Size(60, 67);
            this.tsb_exit.Text = "退    出";
            this.tsb_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_exit.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cb_frock);
            this.groupBox1.Controls.Add(this.cb_object);
            this.groupBox1.Controls.Add(this.lb_object);
            this.groupBox1.Controls.Add(this.tb_frock);
            this.groupBox1.Controls.Add(this.bt_start);
            this.groupBox1.Controls.Add(this.tb_order);
            this.groupBox1.Controls.Add(this.tb_person);
            this.groupBox1.Controls.Add(this.lb_order);
            this.groupBox1.Controls.Add(this.lb_frock);
            this.groupBox1.Controls.Add(this.lb_person);
            this.groupBox1.Location = new System.Drawing.Point(9, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 204);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新建订单任务";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(17, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "清空测试列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_frock
            // 
            this.cb_frock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_frock.FormattingEnabled = true;
            this.cb_frock.Location = new System.Drawing.Point(77, 218);
            this.cb_frock.Name = "cb_frock";
            this.cb_frock.Size = new System.Drawing.Size(99, 20);
            this.cb_frock.TabIndex = 10;
            // 
            // cb_object
            // 
            this.cb_object.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_object.FormattingEnabled = true;
            this.cb_object.Location = new System.Drawing.Point(86, 22);
            this.cb_object.Name = "cb_object";
            this.cb_object.Size = new System.Drawing.Size(147, 20);
            this.cb_object.TabIndex = 9;
            this.cb_object.DropDown += new System.EventHandler(this.cb_object_DropDown);
            // 
            // lb_object
            // 
            this.lb_object.AutoSize = true;
            this.lb_object.Location = new System.Drawing.Point(15, 25);
            this.lb_object.Name = "lb_object";
            this.lb_object.Size = new System.Drawing.Size(71, 12);
            this.lb_object.TabIndex = 8;
            this.lb_object.Text = "串口服务器:";
            // 
            // tb_frock
            // 
            this.tb_frock.Location = new System.Drawing.Point(86, 52);
            this.tb_frock.Name = "tb_frock";
            this.tb_frock.Size = new System.Drawing.Size(147, 21);
            this.tb_frock.TabIndex = 10;
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(135, 152);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(93, 27);
            this.bt_start.TabIndex = 13;
            this.bt_start.Text = "开始测试";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // tb_order
            // 
            this.tb_order.Location = new System.Drawing.Point(86, 112);
            this.tb_order.Name = "tb_order";
            this.tb_order.Size = new System.Drawing.Size(148, 21);
            this.tb_order.TabIndex = 12;
            // 
            // tb_person
            // 
            this.tb_person.Location = new System.Drawing.Point(85, 82);
            this.tb_person.Name = "tb_person";
            this.tb_person.Size = new System.Drawing.Size(149, 21);
            this.tb_person.TabIndex = 11;
            // 
            // lb_order
            // 
            this.lb_order.AutoSize = true;
            this.lb_order.Location = new System.Drawing.Point(13, 115);
            this.lb_order.Name = "lb_order";
            this.lb_order.Size = new System.Drawing.Size(71, 12);
            this.lb_order.TabIndex = 2;
            this.lb_order.Text = "生产订单号:";
            // 
            // lb_frock
            // 
            this.lb_frock.AutoSize = true;
            this.lb_frock.Location = new System.Drawing.Point(15, 55);
            this.lb_frock.Name = "lb_frock";
            this.lb_frock.Size = new System.Drawing.Size(59, 12);
            this.lb_frock.TabIndex = 1;
            this.lb_frock.Text = "使用工装:";
            // 
            // lb_person
            // 
            this.lb_person.AutoSize = true;
            this.lb_person.Location = new System.Drawing.Point(15, 85);
            this.lb_person.Name = "lb_person";
            this.lb_person.Size = new System.Drawing.Size(59, 12);
            this.lb_person.TabIndex = 0;
            this.lb_person.Text = "测试人员:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lv_record);
            this.groupBox2.Location = new System.Drawing.Point(268, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(904, 538);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "正在测试列表";
            // 
            // lv_record
            // 
            this.lv_record.AllowColumnReorder = true;
            this.lv_record.BackColor = System.Drawing.SystemColors.Window;
            this.lv_record.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader12,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lv_record.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_record.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lv_record.FullRowSelect = true;
            this.lv_record.GridLines = true;
            this.lv_record.HideSelection = false;
            this.lv_record.Location = new System.Drawing.Point(3, 17);
            this.lv_record.MultiSelect = false;
            this.lv_record.Name = "lv_record";
            this.lv_record.Size = new System.Drawing.Size(898, 518);
            this.lv_record.TabIndex = 0;
            this.lv_record.UseCompatibleStateImageBehavior = false;
            this.lv_record.View = System.Windows.Forms.View.Details;
            this.lv_record.DoubleClick += new System.EventHandler(this.lv_record_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "工装名称";
            this.columnHeader12.Width = 168;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "生产订单号";
            this.columnHeader10.Width = 108;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "测试人";
            this.columnHeader11.Width = 48;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "工装物料号";
            this.columnHeader2.Width = 84;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "工装固件版本号";
            this.columnHeader3.Width = 216;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "产品SN编码";
            this.columnHeader4.Width = 156;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "产品固件版本号";
            this.columnHeader5.Width = 204;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "产品错误编码";
            this.columnHeader6.Width = 84;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "接收报文信息";
            this.columnHeader7.Width = 1590;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lv_frock);
            this.groupBox3.Location = new System.Drawing.Point(12, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 287);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "正在测试的订单";
            // 
            // lv_frock
            // 
            this.lv_frock.AllowColumnReorder = true;
            this.lv_frock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader13});
            this.lv_frock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_frock.FullRowSelect = true;
            this.lv_frock.GridLines = true;
            this.lv_frock.HideSelection = false;
            this.lv_frock.Location = new System.Drawing.Point(3, 17);
            this.lv_frock.MultiSelect = false;
            this.lv_frock.Name = "lv_frock";
            this.lv_frock.Size = new System.Drawing.Size(244, 267);
            this.lv_frock.TabIndex = 0;
            this.lv_frock.UseCompatibleStateImageBehavior = false;
            this.lv_frock.View = System.Windows.Forms.View.Details;
            this.lv_frock.DoubleClick += new System.EventHandler(this.lv_frock_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "工装名称";
            this.columnHeader8.Width = 141;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "订单号";
            this.columnHeader9.Width = 113;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "连接对象";
            this.columnHeader13.Width = 151;
            // 
            // bt_stop
            // 
            this.bt_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_stop.Location = new System.Drawing.Point(144, 601);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(93, 27);
            this.bt_stop.TabIndex = 7;
            this.bt_stop.Text = "停止测试";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产测试辅助上位机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Test_form_FormClosing);
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TS_Menu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem TS_help;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_connect;
        private System.Windows.Forms.ToolStripButton tsb_frock;
        private System.Windows.Forms.ToolStripButton tsb_order;
        private System.Windows.Forms.ToolStripButton tsb_record;
        private System.Windows.Forms.ToolStripButton tsb_exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.TextBox tb_order;
        private System.Windows.Forms.TextBox tb_person;
        private System.Windows.Forms.Label lb_order;
        private System.Windows.Forms.Label lb_frock;
        private System.Windows.Forms.Label lb_person;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_record;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lv_frock;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.ToolStripStatusLabel tSL_connect;
        private System.Windows.Forms.ToolStripStatusLabel tSL_space;
        private System.Windows.Forms.ToolStripStatusLabel tSL_time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ComboBox cb_object;
        private System.Windows.Forms.Label lb_object;
        private System.Windows.Forms.TextBox tb_frock;
        private System.Windows.Forms.ComboBox cb_frock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_about;
    }
}

