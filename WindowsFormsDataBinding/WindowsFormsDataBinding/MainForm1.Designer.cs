﻿namespace WindowsFormsDataBinding
{
    partial class MainForm1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.carInventoryGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveCar = new System.Windows.Forms.Button();
            this.txtCarToRemove = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDisplayMakes = new System.Windows.Forms.Button();
            this.txtMakeToView = new System.Windows.Forms.TextBox();
            this.btnIDGreaterThenFive = new System.Windows.Forms.Button();
            this.btnChangeMakes = new System.Windows.Forms.Button();
            this.dataGridYugosView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).BeginInit();
            this.SuspendLayout();
            // 
            // carInventoryGridView
            // 
            this.carInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carInventoryGridView.Location = new System.Drawing.Point(39, 114);
            this.carInventoryGridView.Name = "carInventoryGridView";
            this.carInventoryGridView.Size = new System.Drawing.Size(638, 284);
            this.carInventoryGridView.TabIndex = 0;
            this.carInventoryGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Here is what we have in stock";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveCar);
            this.groupBox1.Controls.Add(this.txtCarToRemove);
            this.groupBox1.Location = new System.Drawing.Point(39, 418);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter ID of Car to Delete";
            // 
            // btnRemoveCar
            // 
            this.btnRemoveCar.Location = new System.Drawing.Point(21, 58);
            this.btnRemoveCar.Name = "btnRemoveCar";
            this.btnRemoveCar.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCar.TabIndex = 1;
            this.btnRemoveCar.Text = "Delete!";
            this.btnRemoveCar.UseVisualStyleBackColor = true;
            this.btnRemoveCar.Click += new System.EventHandler(this.btnRemoveCar_Click);
            // 
            // txtCarToRemove
            // 
            this.txtCarToRemove.Location = new System.Drawing.Point(21, 20);
            this.txtCarToRemove.Name = "txtCarToRemove";
            this.txtCarToRemove.Size = new System.Drawing.Size(161, 20);
            this.txtCarToRemove.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDisplayMakes);
            this.groupBox2.Controls.Add(this.txtMakeToView);
            this.groupBox2.Location = new System.Drawing.Point(338, 418);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enter Make to View";
            // 
            // btnDisplayMakes
            // 
            this.btnDisplayMakes.Location = new System.Drawing.Point(6, 58);
            this.btnDisplayMakes.Name = "btnDisplayMakes";
            this.btnDisplayMakes.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayMakes.TabIndex = 1;
            this.btnDisplayMakes.Text = "View!";
            this.btnDisplayMakes.UseVisualStyleBackColor = true;
            this.btnDisplayMakes.Click += new System.EventHandler(this.btnDisplayMakes_Click);
            // 
            // txtMakeToView
            // 
            this.txtMakeToView.Location = new System.Drawing.Point(6, 19);
            this.txtMakeToView.Name = "txtMakeToView";
            this.txtMakeToView.Size = new System.Drawing.Size(218, 20);
            this.txtMakeToView.TabIndex = 0;
            // 
            // btnIDGreaterThenFive
            // 
            this.btnIDGreaterThenFive.Location = new System.Drawing.Point(710, 418);
            this.btnIDGreaterThenFive.Name = "btnIDGreaterThenFive";
            this.btnIDGreaterThenFive.Size = new System.Drawing.Size(75, 23);
            this.btnIDGreaterThenFive.TabIndex = 4;
            this.btnIDGreaterThenFive.Text = "ID > 5";
            this.btnIDGreaterThenFive.UseVisualStyleBackColor = true;
            this.btnIDGreaterThenFive.Click += new System.EventHandler(this.btnIDGreaterThenFive_Click);
            // 
            // btnChangeMakes
            // 
            this.btnChangeMakes.Location = new System.Drawing.Point(710, 476);
            this.btnChangeMakes.Name = "btnChangeMakes";
            this.btnChangeMakes.Size = new System.Drawing.Size(152, 23);
            this.btnChangeMakes.TabIndex = 5;
            this.btnChangeMakes.Text = "Aktualizacja marki";
            this.btnChangeMakes.UseVisualStyleBackColor = true;
            this.btnChangeMakes.Click += new System.EventHandler(this.btnChangeMakes_Click);
            // 
            // dataGridYugosView
            // 
            this.dataGridYugosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridYugosView.Location = new System.Drawing.Point(744, 114);
            this.dataGridYugosView.Name = "dataGridYugosView";
            this.dataGridYugosView.Size = new System.Drawing.Size(626, 284);
            this.dataGridYugosView.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(744, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Only Yugos";
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 565);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridYugosView);
            this.Controls.Add(this.btnChangeMakes);
            this.Controls.Add(this.btnIDGreaterThenFive);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.carInventoryGridView);
            this.Name = "MainForm1";
            this.Text = "Windows Forms Data Binding";
            this.Load += new System.EventHandler(this.MainForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carInventoryGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridYugosView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView carInventoryGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveCar;
        private System.Windows.Forms.TextBox txtCarToRemove;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDisplayMakes;
        private System.Windows.Forms.TextBox txtMakeToView;
        private System.Windows.Forms.Button btnIDGreaterThenFive;
        private System.Windows.Forms.Button btnChangeMakes;
        private System.Windows.Forms.DataGridView dataGridYugosView;
        private System.Windows.Forms.Label label2;
    }
}

