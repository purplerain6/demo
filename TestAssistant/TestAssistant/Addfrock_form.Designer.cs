namespace TestAssistant
{
    partial class Addfrock_form
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
            this.cB_object = new System.Windows.Forms.ComboBox();
            this.lb_object = new System.Windows.Forms.Label();
            this.tb_frock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_addfrock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cB_object
            // 
            this.cB_object.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_object.FormattingEnabled = true;
            this.cB_object.Location = new System.Drawing.Point(105, 73);
            this.cB_object.Name = "cB_object";
            this.cB_object.Size = new System.Drawing.Size(171, 20);
            this.cB_object.TabIndex = 17;
            this.cB_object.DropDown += new System.EventHandler(this.cB_object_DropDown);
            // 
            // lb_object
            // 
            this.lb_object.AutoSize = true;
            this.lb_object.Location = new System.Drawing.Point(22, 76);
            this.lb_object.Name = "lb_object";
            this.lb_object.Size = new System.Drawing.Size(65, 12);
            this.lb_object.TabIndex = 16;
            this.lb_object.Text = "连接对象：";
            // 
            // tb_frock
            // 
            this.tb_frock.Location = new System.Drawing.Point(105, 32);
            this.tb_frock.Name = "tb_frock";
            this.tb_frock.Size = new System.Drawing.Size(171, 21);
            this.tb_frock.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "工装名称：";
            // 
            // bt_addfrock
            // 
            this.bt_addfrock.Location = new System.Drawing.Point(105, 126);
            this.bt_addfrock.Name = "bt_addfrock";
            this.bt_addfrock.Size = new System.Drawing.Size(75, 23);
            this.bt_addfrock.TabIndex = 29;
            this.bt_addfrock.Text = "添加工装";
            this.bt_addfrock.UseVisualStyleBackColor = true;
            this.bt_addfrock.Click += new System.EventHandler(this.bt_addfrock_Click);
            // 
            // Addfrock_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 177);
            this.Controls.Add(this.bt_addfrock);
            this.Controls.Add(this.tb_frock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cB_object);
            this.Controls.Add(this.lb_object);
            this.Name = "Addfrock_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加工装";
            this.Load += new System.EventHandler(this.Addfrock_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cB_object;
        private System.Windows.Forms.Label lb_object;
        private System.Windows.Forms.TextBox tb_frock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_addfrock;
    }
}