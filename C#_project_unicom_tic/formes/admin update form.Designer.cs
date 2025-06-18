namespace C__project_unicom_tic.formes
{
    partial class admin_update_form
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_add = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label_address = new System.Windows.Forms.Label();
            this.NIC_number = new System.Windows.Forms.Label();
            this.textBox_nic_number = new System.Windows.Forms.TextBox();
            this.label_nic_number = new System.Windows.Forms.Label();
            this.label_show = new System.Windows.Forms.Label();
            this.label_user_name = new System.Windows.Forms.Label();
            this.textBox_user_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(396, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(309, 258);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(425, 449);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 1;
            this.button_add.Text = "ADD";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(506, 449);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "UPDATE";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(587, 449);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 3;
            this.button_Delete.Text = "DILL_YOU";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(163, 181);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(216, 20);
            this.textBox_name.TabIndex = 6;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label_name
            // 
            this.label_name.Location = new System.Drawing.Point(160, 204);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(219, 23);
            this.label_name.TabIndex = 7;
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(57, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(163, 227);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(216, 20);
            this.textBox_Address.TabIndex = 9;
            this.textBox_Address.TextChanged += new System.EventHandler(this.textBox_Address_TextChanged);
            // 
            // label_address
            // 
            this.label_address.Location = new System.Drawing.Point(160, 250);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(219, 23);
            this.label_address.TabIndex = 10;
            this.label_address.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NIC_number
            // 
            this.NIC_number.Location = new System.Drawing.Point(57, 273);
            this.NIC_number.Name = "NIC_number";
            this.NIC_number.Size = new System.Drawing.Size(100, 23);
            this.NIC_number.TabIndex = 11;
            this.NIC_number.Text = "Nic_Number";
            this.NIC_number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_nic_number
            // 
            this.textBox_nic_number.Location = new System.Drawing.Point(163, 276);
            this.textBox_nic_number.Name = "textBox_nic_number";
            this.textBox_nic_number.Size = new System.Drawing.Size(216, 20);
            this.textBox_nic_number.TabIndex = 12;
            this.textBox_nic_number.TextChanged += new System.EventHandler(this.textBox_nic_number_TextChanged);
            // 
            // label_nic_number
            // 
            this.label_nic_number.Location = new System.Drawing.Point(160, 299);
            this.label_nic_number.Name = "label_nic_number";
            this.label_nic_number.Size = new System.Drawing.Size(219, 23);
            this.label_nic_number.TabIndex = 13;
            this.label_nic_number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_show
            // 
            this.label_show.Location = new System.Drawing.Point(38, 404);
            this.label_show.Name = "label_show";
            this.label_show.Size = new System.Drawing.Size(341, 167);
            this.label_show.TabIndex = 14;
            this.label_show.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_show.Click += new System.EventHandler(this.label_show_Click);
            // 
            // label_user_name
            // 
            this.label_user_name.Location = new System.Drawing.Point(147, 352);
            this.label_user_name.Name = "label_user_name";
            this.label_user_name.Size = new System.Drawing.Size(219, 23);
            this.label_user_name.TabIndex = 17;
            this.label_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_user_name.Click += new System.EventHandler(this.label_user_name_Click);
            // 
            // textBox_user_name
            // 
            this.textBox_user_name.Location = new System.Drawing.Point(163, 328);
            this.textBox_user_name.Name = "textBox_user_name";
            this.textBox_user_name.Size = new System.Drawing.Size(216, 20);
            this.textBox_user_name.TabIndex = 16;
            this.textBox_user_name.TextChanged += new System.EventHandler(this.textBox_user_name_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(53, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "User_Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(648, 76);
            this.label5.TabIndex = 20;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // admin_update_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_user_name);
            this.Controls.Add(this.textBox_user_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_show);
            this.Controls.Add(this.label_nic_number);
            this.Controls.Add(this.textBox_nic_number);
            this.Controls.Add(this.NIC_number);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.textBox_Address);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "admin_update_form";
            this.Text = "admin_update_form";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label NIC_number;
        private System.Windows.Forms.TextBox textBox_nic_number;
        private System.Windows.Forms.Label label_nic_number;
        private System.Windows.Forms.Label label_show;
        private System.Windows.Forms.Label label_user_name;
        private System.Windows.Forms.TextBox textBox_user_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}