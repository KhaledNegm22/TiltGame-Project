
namespace WindowsFormsApp1
{
    partial class Game
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
            this.Next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Next.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Asset_1;
            this.Next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Next.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Next.FlatAppearance.BorderSize = 0;
            this.Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Next.Location = new System.Drawing.Point(647, 388);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(131, 67);
            this.Next.TabIndex = 0;
            this.Next.Text = ">>";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.UseWaitCursor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // previous
            // 
            this.previous.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.previous.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Asset_2;
            this.previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previous.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.previous.FlatAppearance.BorderSize = 0;
            this.previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous.Location = new System.Drawing.Point(12, 388);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(140, 67);
            this.previous.TabIndex = 1;
            this.previous.UseVisualStyleBackColor = false;
            this.previous.UseWaitCursor = true;
            this.previous.Click += new System.EventHandler(this.previos_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.a3e347fbb1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(790, 467);
            this.Controls.Add(this.previous);
            this.Controls.Add(this.Next);
            this.Name = "Game";
            this.Text = "Game";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button previous;
    }
}

