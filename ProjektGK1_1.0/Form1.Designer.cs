﻿namespace ProjektGK1_1._0
{
    partial class Form1
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
            this.layout_layout = new System.Windows.Forms.TableLayoutPanel();
            this.controls_panel = new System.Windows.Forms.Panel();
            this.con_parallel = new System.Windows.Forms.RadioButton();
            this.con_length = new System.Windows.Forms.RadioButton();
            this.move_edge = new System.Windows.Forms.RadioButton();
            this.delete_polygon = new System.Windows.Forms.RadioButton();
            this.delete_vertice = new System.Windows.Forms.RadioButton();
            this.move_polygon = new System.Windows.Forms.RadioButton();
            this.move_vertice = new System.Windows.Forms.RadioButton();
            this.add_polygon = new System.Windows.Forms.RadioButton();
            this.add_vertice = new System.Windows.Forms.RadioButton();
            this.clear_button = new System.Windows.Forms.Button();
            this.drawing_panel = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.layout_layout.SuspendLayout();
            this.controls_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing_panel)).BeginInit();
            this.SuspendLayout();
            // 
            // layout_layout
            // 
            this.layout_layout.ColumnCount = 2;
            this.layout_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.78186F));
            this.layout_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.21814F));
            this.layout_layout.Controls.Add(this.controls_panel, 1, 0);
            this.layout_layout.Controls.Add(this.drawing_panel, 0, 0);
            this.layout_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_layout.Location = new System.Drawing.Point(0, 0);
            this.layout_layout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.layout_layout.Name = "layout_layout";
            this.layout_layout.RowCount = 1;
            this.layout_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_layout.Size = new System.Drawing.Size(2315, 1332);
            this.layout_layout.TabIndex = 0;
            // 
            // controls_panel
            // 
            this.controls_panel.Controls.Add(this.label1);
            this.controls_panel.Controls.Add(this.con_parallel);
            this.controls_panel.Controls.Add(this.con_length);
            this.controls_panel.Controls.Add(this.move_edge);
            this.controls_panel.Controls.Add(this.delete_polygon);
            this.controls_panel.Controls.Add(this.delete_vertice);
            this.controls_panel.Controls.Add(this.move_polygon);
            this.controls_panel.Controls.Add(this.move_vertice);
            this.controls_panel.Controls.Add(this.add_polygon);
            this.controls_panel.Controls.Add(this.add_vertice);
            this.controls_panel.Controls.Add(this.clear_button);
            this.controls_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controls_panel.Location = new System.Drawing.Point(2012, 2);
            this.controls_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controls_panel.Name = "controls_panel";
            this.controls_panel.Size = new System.Drawing.Size(300, 1328);
            this.controls_panel.TabIndex = 1;
            // 
            // con_parallel
            // 
            this.con_parallel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.con_parallel.AutoSize = true;
            this.con_parallel.Location = new System.Drawing.Point(21, 353);
            this.con_parallel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.con_parallel.Name = "con_parallel";
            this.con_parallel.Size = new System.Drawing.Size(76, 21);
            this.con_parallel.TabIndex = 0;
            this.con_parallel.TabStop = true;
            this.con_parallel.Text = "Parallel";
            this.con_parallel.UseVisualStyleBackColor = true;
            this.con_parallel.CheckedChanged += new System.EventHandler(this.Con_parallel_CheckedChanged);
            // 
            // con_length
            // 
            this.con_length.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.con_length.AutoSize = true;
            this.con_length.Location = new System.Drawing.Point(21, 324);
            this.con_length.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.con_length.Name = "con_length";
            this.con_length.Size = new System.Drawing.Size(73, 21);
            this.con_length.TabIndex = 0;
            this.con_length.TabStop = true;
            this.con_length.Text = "Length";
            this.con_length.UseVisualStyleBackColor = true;
            this.con_length.CheckedChanged += new System.EventHandler(this.Con_length_CheckedChanged);
            // 
            // move_edge
            // 
            this.move_edge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.move_edge.AutoSize = true;
            this.move_edge.Location = new System.Drawing.Point(21, 210);
            this.move_edge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.move_edge.Name = "move_edge";
            this.move_edge.Size = new System.Drawing.Size(100, 21);
            this.move_edge.TabIndex = 1;
            this.move_edge.TabStop = true;
            this.move_edge.Text = "Move Edge";
            this.move_edge.UseVisualStyleBackColor = true;
            // 
            // delete_polygon
            // 
            this.delete_polygon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_polygon.AutoSize = true;
            this.delete_polygon.Location = new System.Drawing.Point(21, 238);
            this.delete_polygon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete_polygon.Name = "delete_polygon";
            this.delete_polygon.Size = new System.Drawing.Size(125, 21);
            this.delete_polygon.TabIndex = 1;
            this.delete_polygon.TabStop = true;
            this.delete_polygon.Text = "Delete Polygon";
            this.delete_polygon.UseVisualStyleBackColor = true;
            // 
            // delete_vertice
            // 
            this.delete_vertice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_vertice.AutoSize = true;
            this.delete_vertice.Location = new System.Drawing.Point(21, 263);
            this.delete_vertice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete_vertice.Name = "delete_vertice";
            this.delete_vertice.Size = new System.Drawing.Size(118, 21);
            this.delete_vertice.TabIndex = 1;
            this.delete_vertice.TabStop = true;
            this.delete_vertice.Text = "Delete Vertice";
            this.delete_vertice.UseVisualStyleBackColor = true;
            // 
            // move_polygon
            // 
            this.move_polygon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.move_polygon.AutoSize = true;
            this.move_polygon.Location = new System.Drawing.Point(21, 156);
            this.move_polygon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.move_polygon.Name = "move_polygon";
            this.move_polygon.Size = new System.Drawing.Size(118, 21);
            this.move_polygon.TabIndex = 1;
            this.move_polygon.TabStop = true;
            this.move_polygon.Text = "Move Polygon";
            this.move_polygon.UseVisualStyleBackColor = true;
            // 
            // move_vertice
            // 
            this.move_vertice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.move_vertice.AutoSize = true;
            this.move_vertice.Location = new System.Drawing.Point(21, 183);
            this.move_vertice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.move_vertice.Name = "move_vertice";
            this.move_vertice.Size = new System.Drawing.Size(111, 21);
            this.move_vertice.TabIndex = 1;
            this.move_vertice.TabStop = true;
            this.move_vertice.Text = "Move Vertice";
            this.move_vertice.UseVisualStyleBackColor = true;
            // 
            // add_polygon
            // 
            this.add_polygon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.add_polygon.AutoSize = true;
            this.add_polygon.Location = new System.Drawing.Point(21, 102);
            this.add_polygon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_polygon.Name = "add_polygon";
            this.add_polygon.Size = new System.Drawing.Size(109, 21);
            this.add_polygon.TabIndex = 1;
            this.add_polygon.TabStop = true;
            this.add_polygon.Text = "Add Polygon";
            this.add_polygon.UseVisualStyleBackColor = true;
            this.add_polygon.CheckedChanged += new System.EventHandler(this.Add_polygon_CheckedChanged);
            // 
            // add_vertice
            // 
            this.add_vertice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.add_vertice.AutoSize = true;
            this.add_vertice.Location = new System.Drawing.Point(21, 129);
            this.add_vertice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_vertice.Name = "add_vertice";
            this.add_vertice.Size = new System.Drawing.Size(102, 21);
            this.add_vertice.TabIndex = 1;
            this.add_vertice.TabStop = true;
            this.add_vertice.Text = "Add Vertice";
            this.add_vertice.UseVisualStyleBackColor = true;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(3, 9);
            this.clear_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(293, 63);
            this.clear_button.TabIndex = 0;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // drawing_panel
            // 
            this.drawing_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawing_panel.BackColor = System.Drawing.Color.White;
            this.drawing_panel.Location = new System.Drawing.Point(3, 2);
            this.drawing_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawing_panel.Name = "drawing_panel";
            this.drawing_panel.Size = new System.Drawing.Size(2003, 1328);
            this.drawing_panel.TabIndex = 2;
            this.drawing_panel.TabStop = false;
            this.drawing_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_panel_Paint);
            this.drawing_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseClick);
            this.drawing_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseDown);
            this.drawing_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseMove);
            this.drawing_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Constraints";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2315, 1332);
            this.Controls.Add(this.layout_layout);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.layout_layout.ResumeLayout(false);
            this.controls_panel.ResumeLayout(false);
            this.controls_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing_panel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout_layout;
        private System.Windows.Forms.Panel controls_panel;
        private System.Windows.Forms.RadioButton delete_vertice;
        private System.Windows.Forms.RadioButton move_polygon;
        private System.Windows.Forms.RadioButton move_vertice;
        private System.Windows.Forms.RadioButton add_polygon;
        private System.Windows.Forms.RadioButton add_vertice;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.PictureBox drawing_panel;
        private System.Windows.Forms.RadioButton delete_polygon;
        private System.Windows.Forms.RadioButton move_edge;
        private System.Windows.Forms.RadioButton con_parallel;
        private System.Windows.Forms.RadioButton con_length;
        private System.Windows.Forms.Label label1;
    }
}

