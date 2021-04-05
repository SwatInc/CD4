
namespace CD4.AstmInterface.View
{
    partial class MainView
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
            this.radioButtonSerial = new System.Windows.Forms.RadioButton();
            this.radioButtonEthernet = new System.Windows.Forms.RadioButton();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.groupBoxEthernet = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // radioButtonSerial
            // 
            this.radioButtonSerial.AutoSize = true;
            this.radioButtonSerial.Location = new System.Drawing.Point(12, 12);
            this.radioButtonSerial.Name = "radioButtonSerial";
            this.radioButtonSerial.Size = new System.Drawing.Size(101, 19);
            this.radioButtonSerial.TabIndex = 0;
            this.radioButtonSerial.TabStop = true;
            this.radioButtonSerial.Text = "Serial [ RS232 ]";
            this.radioButtonSerial.UseVisualStyleBackColor = true;
            // 
            // radioButtonEthernet
            // 
            this.radioButtonEthernet.AutoSize = true;
            this.radioButtonEthernet.Location = new System.Drawing.Point(12, 37);
            this.radioButtonEthernet.Name = "radioButtonEthernet";
            this.radioButtonEthernet.Size = new System.Drawing.Size(69, 19);
            this.radioButtonEthernet.TabIndex = 1;
            this.radioButtonEthernet.TabStop = true;
            this.radioButtonEthernet.Text = "Ethernet";
            this.radioButtonEthernet.UseVisualStyleBackColor = true;
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Location = new System.Drawing.Point(80, 113);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(330, 124);
            this.groupBoxSerial.TabIndex = 2;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial Settings";
            // 
            // groupBoxEthernet
            // 
            this.groupBoxEthernet.Location = new System.Drawing.Point(416, 113);
            this.groupBoxEthernet.Name = "groupBoxEthernet";
            this.groupBoxEthernet.Size = new System.Drawing.Size(330, 124);
            this.groupBoxEthernet.TabIndex = 3;
            this.groupBoxEthernet.TabStop = false;
            this.groupBoxEthernet.Text = "Ethernet Settings";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 285);
            this.Controls.Add(this.groupBoxEthernet);
            this.Controls.Add(this.groupBoxSerial);
            this.Controls.Add(this.radioButtonEthernet);
            this.Controls.Add(this.radioButtonSerial);
            this.Name = "MainView";
            this.Text = "MainView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonSerial;
        private System.Windows.Forms.RadioButton radioButtonEthernet;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.GroupBox groupBoxEthernet;
    }
}