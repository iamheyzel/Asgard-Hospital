namespace Asgard_Hospital
{
    partial class SignIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.user_name = new System.Windows.Forms.Label();
            this.createbtn = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.first_name = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(239, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 54);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sign Up";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // user_name
            // 
            this.user_name.AutoSize = true;
            this.user_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.ForeColor = System.Drawing.Color.White;
            this.user_name.Location = new System.Drawing.Point(86, 221);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(116, 25);
            this.user_name.TabIndex = 10;
            this.user_name.Text = "User Name:";
            // 
            // createbtn
            // 
            this.createbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createbtn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.createbtn.Location = new System.Drawing.Point(248, 328);
            this.createbtn.Name = "createbtn";
            this.createbtn.Size = new System.Drawing.Size(133, 42);
            this.createbtn.TabIndex = 12;
            this.createbtn.Text = "Create";
            this.createbtn.UseVisualStyleBackColor = true;
            this.createbtn.Click += new System.EventHandler(this.resetbtn_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.AutoSize = true;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.Color.White;
            this.txtpassword.Location = new System.Drawing.Point(98, 270);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(104, 25);
            this.txtpassword.TabIndex = 13;
            this.txtpassword.Text = "Password:";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.White;
            this.email.Location = new System.Drawing.Point(136, 178);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(66, 25);
            this.email.TabIndex = 15;
            this.email.Text = "Email:";
            // 
            // first_name
            // 
            this.first_name.AutoSize = true;
            this.first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.first_name.ForeColor = System.Drawing.Color.White;
            this.first_name.Location = new System.Drawing.Point(136, 132);
            this.first_name.Name = "first_name";
            this.first_name.Size = new System.Drawing.Size(70, 25);
            this.first_name.TabIndex = 16;
            this.first_name.Text = "Name:";
            // 
            // textEmail
            // 
            this.textEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmail.Location = new System.Drawing.Point(221, 173);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(214, 30);
            this.textEmail.TabIndex = 17;
            // 
            // textUserName
            // 
            this.textUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserName.Location = new System.Drawing.Point(221, 216);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(214, 30);
            this.textUserName.TabIndex = 18;
            // 
            // textPass
            // 
            this.textPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPass.Location = new System.Drawing.Point(221, 265);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(214, 30);
            this.textPass.TabIndex = 20;
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.Location = new System.Drawing.Point(221, 129);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(214, 30);
            this.textName.TabIndex = 21;
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(621, 439);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textUserName);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.email);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.createbtn);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignIn";
            this.Load += new System.EventHandler(this.SignIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label user_name;
        private System.Windows.Forms.Button createbtn;
        private System.Windows.Forms.Label txtpassword;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label first_name;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textName;
    }
}