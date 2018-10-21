namespace Milestone_2_Project
{
    partial class Form1
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
            this.BlueRedTile = new System.Windows.Forms.CheckBox();
            this.GreenTile = new System.Windows.Forms.CheckBox();
            this.PurpleTile = new System.Windows.Forms.CheckBox();
            this.YellowTile = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // BlueRedTile
            // 
            this.BlueRedTile.AutoSize = true;
            this.BlueRedTile.Location = new System.Drawing.Point(241, 114);
            this.BlueRedTile.Name = "BlueRedTile";
            this.BlueRedTile.Size = new System.Drawing.Size(113, 21);
            this.BlueRedTile.TabIndex = 0;
            this.BlueRedTile.Text = "Change Tiles";
            this.BlueRedTile.UseVisualStyleBackColor = true;
            this.BlueRedTile.CheckedChanged += new System.EventHandler(this.BlueRedTile_CheckedChanged);
            // 
            // GreenTile
            // 
            this.GreenTile.AutoSize = true;
            this.GreenTile.Location = new System.Drawing.Point(241, 170);
            this.GreenTile.Name = "GreenTile";
            this.GreenTile.Size = new System.Drawing.Size(102, 21);
            this.GreenTile.TabIndex = 1;
            this.GreenTile.Text = "Normal Tile";
            this.GreenTile.UseVisualStyleBackColor = true;
            this.GreenTile.CheckedChanged += new System.EventHandler(this.GreenTile_CheckedChanged);
            // 
            // PurpleTile
            // 
            this.PurpleTile.AutoSize = true;
            this.PurpleTile.Location = new System.Drawing.Point(241, 226);
            this.PurpleTile.Name = "PurpleTile";
            this.PurpleTile.Size = new System.Drawing.Size(95, 21);
            this.PurpleTile.TabIndex = 2;
            this.PurpleTile.Text = "Death Tile";
            this.PurpleTile.UseVisualStyleBackColor = true;
            this.PurpleTile.CheckedChanged += new System.EventHandler(this.PurpleTile_CheckedChanged);
            // 
            // YellowTile
            // 
            this.YellowTile.AutoSize = true;
            this.YellowTile.Location = new System.Drawing.Point(241, 282);
            this.YellowTile.Name = "YellowTile";
            this.YellowTile.Size = new System.Drawing.Size(91, 21);
            this.YellowTile.TabIndex = 3;
            this.YellowTile.Text = "Move Tile";
            this.YellowTile.UseVisualStyleBackColor = true;
            this.YellowTile.CheckedChanged += new System.EventHandler(this.YellowTile_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Milestone_2_Project.Properties.Resources.BlueTile;
            this.pictureBox1.Location = new System.Drawing.Point(159, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Milestone_2_Project.Properties.Resources.GreenTile;
            this.pictureBox2.Location = new System.Drawing.Point(159, 141);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Milestone_2_Project.Properties.Resources.RedTile;
            this.pictureBox3.Location = new System.Drawing.Point(103, 85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Milestone_2_Project.Properties.Resources.YellowTile;
            this.pictureBox4.Location = new System.Drawing.Point(159, 253);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Milestone_2_Project.Properties.Resources.PurpleTile;
            this.pictureBox5.Location = new System.Drawing.Point(159, 197);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(12, 9);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(265, 25);
            this.Label.TabIndex = 9;
            this.Label.Text = "Select Tiles to NOT show:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 362);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.YellowTile);
            this.Controls.Add(this.PurpleTile);
            this.Controls.Add(this.GreenTile);
            this.Controls.Add(this.BlueRedTile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox BlueRedTile;
        private System.Windows.Forms.CheckBox GreenTile;
        private System.Windows.Forms.CheckBox PurpleTile;
        private System.Windows.Forms.CheckBox YellowTile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label Label;
    }
}