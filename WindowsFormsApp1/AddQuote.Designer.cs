﻿namespace MegaDesk2
{
    partial class AddQuote
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
            this.components = new System.ComponentModel.Container();
            this.addQuoteButton = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDeskWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDeskDepth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textNumberOfDrawers = new System.Windows.Forms.TextBox();
            this.desktopMaterialDropDown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rushOrderDropDown = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // addQuoteButton
            // 
            this.addQuoteButton.BackColor = System.Drawing.Color.Navy;
            this.addQuoteButton.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.addQuoteButton.ForeColor = System.Drawing.Color.Snow;
            this.addQuoteButton.Location = new System.Drawing.Point(297, 264);
            this.addQuoteButton.Name = "addQuoteButton";
            this.addQuoteButton.Size = new System.Drawing.Size(231, 38);
            this.addQuoteButton.TabIndex = 0;
            this.addQuoteButton.Text = "Add Quote";
            this.addQuoteButton.UseVisualStyleBackColor = false;
            this.addQuoteButton.Click += new System.EventHandler(this.addQuote);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(407, 51);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(121, 20);
            this.textName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(342, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // textDeskWidth
            // 
            this.textDeskWidth.Location = new System.Drawing.Point(407, 83);
            this.textDeskWidth.Name = "textDeskWidth";
            this.textDeskWidth.Size = new System.Drawing.Size(121, 20);
            this.textDeskWidth.TabIndex = 3;
            this.textDeskWidth.Validating += new System.ComponentModel.CancelEventHandler(this.checkWidthValue);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(255, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Desk Width (in)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(255, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Desk Depth (in)";
            // 
            // textDeskDepth
            // 
            this.textDeskDepth.Location = new System.Drawing.Point(407, 117);
            this.textDeskDepth.Name = "textDeskDepth";
            this.textDeskDepth.Size = new System.Drawing.Size(121, 20);
            this.textDeskDepth.TabIndex = 5;
            this.textDeskDepth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkDepthValue);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(217, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number Of Drawers";
            // 
            // textNumberOfDrawers
            // 
            this.textNumberOfDrawers.Location = new System.Drawing.Point(407, 154);
            this.textNumberOfDrawers.Name = "textNumberOfDrawers";
            this.textNumberOfDrawers.Size = new System.Drawing.Size(121, 20);
            this.textNumberOfDrawers.TabIndex = 7;
            this.textNumberOfDrawers.Validating += new System.ComponentModel.CancelEventHandler(this.checkDrawerValue);
            // 
            // desktopMaterialDropDown
            // 
            this.desktopMaterialDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.desktopMaterialDropDown.FormattingEnabled = true;
            this.desktopMaterialDropDown.Items.AddRange(new object[] {
            "Oak ",
            "Laminate ",
            "Pine ",
            "Rosewood ",
            "Veneer"});
            this.desktopMaterialDropDown.Location = new System.Drawing.Point(407, 190);
            this.desktopMaterialDropDown.Name = "desktopMaterialDropDown";
            this.desktopMaterialDropDown.Size = new System.Drawing.Size(121, 21);
            this.desktopMaterialDropDown.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(238, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Desktop Material";
            // 
            // rushOrderDropDown
            // 
            this.rushOrderDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rushOrderDropDown.FormattingEnabled = true;
            this.rushOrderDropDown.Items.AddRange(new object[] {
            "0",
            "3 ",
            "5 ",
            "7 "});
            this.rushOrderDropDown.Location = new System.Drawing.Point(407, 227);
            this.rushOrderDropDown.Name = "rushOrderDropDown";
            this.rushOrderDropDown.Size = new System.Drawing.Size(121, 21);
            this.rushOrderDropDown.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(282, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rush Order?";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.BackColor = System.Drawing.Color.Transparent;
            this.labelError.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Maroon;
            this.labelError.Location = new System.Drawing.Point(403, 20);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(204, 20);
            this.labelError.TabIndex = 14;
            this.labelError.Text = "Please fill in all feilds";
            this.labelError.Visible = false;
            // 
            // AddQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MegaDesk2.Properties.Resources.damian_zaleski_RYyr_k3Ysqg_unsplash1;
            this.ClientSize = new System.Drawing.Size(633, 319);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rushOrderDropDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.desktopMaterialDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textNumberOfDrawers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDeskDepth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDeskWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.addQuoteButton);
            this.Name = "AddQuote";
            this.Text = "Add Quote";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addQuoteButton;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDeskWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDeskDepth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNumberOfDrawers;
        private System.Windows.Forms.ComboBox desktopMaterialDropDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox rushOrderDropDown;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelError;
    }
}