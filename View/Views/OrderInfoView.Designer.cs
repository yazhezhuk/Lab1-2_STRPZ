using System.ComponentModel;

namespace View.Views
{
    partial class OrderInfoView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectedGoodsLbx = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedWarehouseTbx = new System.Windows.Forms.TextBox();
            this.orderCalculateBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectedGoodsLbx
            // 
            this.selectedGoodsLbx.FormattingEnabled = true;
            this.selectedGoodsLbx.Location = new System.Drawing.Point(3, 109);
            this.selectedGoodsLbx.Name = "selectedGoodsLbx";
            this.selectedGoodsLbx.Size = new System.Drawing.Size(167, 95);
            this.selectedGoodsLbx.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected goods info";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(396, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selected warehouse Info:";
            // 
            // selectedWarehouseTbx
            // 
            this.selectedWarehouseTbx.Location = new System.Drawing.Point(396, 109);
            this.selectedWarehouseTbx.Multiline = true;
            this.selectedWarehouseTbx.Name = "selectedWarehouseTbx";
            this.selectedWarehouseTbx.Size = new System.Drawing.Size(146, 103);
            this.selectedWarehouseTbx.TabIndex = 3;
            // 
            // orderCalculateBtn
            // 
            this.orderCalculateBtn.Location = new System.Drawing.Point(126, 301);
            this.orderCalculateBtn.Name = "orderCalculateBtn";
            this.orderCalculateBtn.Size = new System.Drawing.Size(146, 30);
            this.orderCalculateBtn.TabIndex = 4;
            this.orderCalculateBtn.Text = "Calculate order time";
            this.orderCalculateBtn.UseVisualStyleBackColor = true;
            // 
            // OrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.orderCalculateBtn);
            this.Controls.Add(this.selectedWarehouseTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedGoodsLbx);
            this.Name = "OrderInfo";
            this.Size = new System.Drawing.Size(786, 433);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button orderCalculateBtn;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox selectedWarehouseTbx;

        private System.Windows.Forms.ListBox selectedGoodsLbx;

        #endregion
    }
}