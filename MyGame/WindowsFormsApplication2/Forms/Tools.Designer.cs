namespace WindowsFormsApplication2
{
    partial class Tools
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
            this.rbTools = new System.Windows.Forms.GroupBox();
            this.rbSuperHard = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbMedium = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.rbSuperEasy = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbTools
            // 
            this.rbTools.Controls.Add(this.rbSuperHard);
            this.rbTools.Controls.Add(this.rbHard);
            this.rbTools.Controls.Add(this.rbMedium);
            this.rbTools.Controls.Add(this.rbEasy);
            this.rbTools.Controls.Add(this.rbSuperEasy);
            this.rbTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbTools.Location = new System.Drawing.Point(12, 12);
            this.rbTools.Name = "rbTools";
            this.rbTools.Size = new System.Drawing.Size(293, 226);
            this.rbTools.TabIndex = 0;
            this.rbTools.TabStop = false;
            this.rbTools.Text = "Уровен сложности";
            // 
            // rbSuperHard
            // 
            this.rbSuperHard.AutoSize = true;
            this.rbSuperHard.Location = new System.Drawing.Point(82, 187);
            this.rbSuperHard.Name = "rbSuperHard";
            this.rbSuperHard.Size = new System.Drawing.Size(109, 24);
            this.rbSuperHard.TabIndex = 4;
            this.rbSuperHard.Tag = "10";
            this.rbSuperHard.Text = "Для Ивана";
            this.rbSuperHard.UseVisualStyleBackColor = true;
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(82, 147);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(97, 24);
            this.rbHard.TabIndex = 3;
            this.rbHard.Tag = "5";
            this.rbHard.Text = "Сложный";
            this.rbHard.UseVisualStyleBackColor = true;
            // 
            // rbMedium
            // 
            this.rbMedium.AutoSize = true;
            this.rbMedium.Checked = true;
            this.rbMedium.Location = new System.Drawing.Point(82, 107);
            this.rbMedium.Name = "rbMedium";
            this.rbMedium.Size = new System.Drawing.Size(94, 24);
            this.rbMedium.TabIndex = 2;
            this.rbMedium.TabStop = true;
            this.rbMedium.Tag = "4";
            this.rbMedium.Text = "Средний";
            this.rbMedium.UseVisualStyleBackColor = true;
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Location = new System.Drawing.Point(82, 67);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(81, 24);
            this.rbEasy.TabIndex = 1;
            this.rbEasy.Tag = "3";
            this.rbEasy.Text = "Легкий";
            this.rbEasy.UseVisualStyleBackColor = true;
            // 
            // rbSuperEasy
            // 
            this.rbSuperEasy.AutoSize = true;
            this.rbSuperEasy.Location = new System.Drawing.Point(82, 27);
            this.rbSuperEasy.Name = "rbSuperEasy";
            this.rbSuperEasy.Size = new System.Drawing.Size(128, 24);
            this.rbSuperEasy.TabIndex = 0;
            this.rbSuperEasy.Tag = "2";
            this.rbSuperEasy.Text = "Супер легкий";
            this.rbSuperEasy.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.Location = new System.Drawing.Point(16, 248);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(140, 42);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ок";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.Location = new System.Drawing.Point(162, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 42);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 298);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbTools);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tools";
            this.Text = "Настройки";
            this.rbTools.ResumeLayout(false);
            this.rbTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox rbTools;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbSuperHard;
        private System.Windows.Forms.RadioButton rbHard;
        private System.Windows.Forms.RadioButton rbMedium;
        private System.Windows.Forms.RadioButton rbEasy;
        private System.Windows.Forms.RadioButton rbSuperEasy;
    }
}