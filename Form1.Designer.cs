namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            autoSolveButton = new Button();
            field = new TableLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            resetButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(field, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(747, 461);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(resetButton);
            panel1.Controls.Add(autoSolveButton);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 63);
            panel1.TabIndex = 0;
            // 
            // autoSolveButton
            // 
            autoSolveButton.BackColor = SystemColors.Control;
            autoSolveButton.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            autoSolveButton.Location = new Point(9, 9);
            autoSolveButton.Name = "autoSolveButton";
            autoSolveButton.Size = new Size(138, 36);
            autoSolveButton.TabIndex = 1;
            autoSolveButton.Text = "auto solve";
            autoSolveButton.UseVisualStyleBackColor = false;
            autoSolveButton.MouseClick += autoSolveButton_MouseClick;
            // 
            // field
            // 
            field.ColumnCount = 20;
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            field.Dock = DockStyle.Fill;
            field.Location = new Point(3, 72);
            field.Name = "field";
            field.RowCount = 10;
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            field.Size = new Size(741, 386);
            field.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // resetButton
            // 
            resetButton.BackColor = SystemColors.Control;
            resetButton.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            resetButton.Location = new Point(153, 9);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(103, 36);
            resetButton.TabIndex = 2;
            resetButton.Text = "reset";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 461);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel field;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private Button autoSolveButton;
        private Button resetButton;
    }
}