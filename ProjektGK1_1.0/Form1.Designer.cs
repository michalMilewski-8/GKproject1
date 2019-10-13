namespace ProjektGK1_1._0
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
            this.move_edge = new System.Windows.Forms.RadioButton();
            this.delete_polygon = new System.Windows.Forms.RadioButton();
            this.delete_vertice = new System.Windows.Forms.RadioButton();
            this.move_polygon = new System.Windows.Forms.RadioButton();
            this.move_vertice = new System.Windows.Forms.RadioButton();
            this.add_polygon = new System.Windows.Forms.RadioButton();
            this.add_vertice = new System.Windows.Forms.RadioButton();
            this.clear_button = new System.Windows.Forms.Button();
            this.drawing_panel = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.con_length = new System.Windows.Forms.RadioButton();
            this.con_parallel = new System.Windows.Forms.RadioButton();
            this.layout_layout.SuspendLayout();
            this.controls_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing_panel)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.layout_layout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layout_layout.Name = "layout_layout";
            this.layout_layout.RowCount = 1;
            this.layout_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_layout.Size = new System.Drawing.Size(1736, 1082);
            this.layout_layout.TabIndex = 0;
            // 
            // controls_panel
            // 
            this.controls_panel.Controls.Add(this.groupBox1);
            this.controls_panel.Controls.Add(this.move_edge);
            this.controls_panel.Controls.Add(this.delete_polygon);
            this.controls_panel.Controls.Add(this.delete_vertice);
            this.controls_panel.Controls.Add(this.move_polygon);
            this.controls_panel.Controls.Add(this.move_vertice);
            this.controls_panel.Controls.Add(this.add_polygon);
            this.controls_panel.Controls.Add(this.add_vertice);
            this.controls_panel.Controls.Add(this.clear_button);
            this.controls_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controls_panel.Location = new System.Drawing.Point(1508, 2);
            this.controls_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controls_panel.Name = "controls_panel";
            this.controls_panel.Size = new System.Drawing.Size(226, 1078);
            this.controls_panel.TabIndex = 1;
            // 
            // move_edge
            // 
            this.move_edge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.move_edge.AutoSize = true;
            this.move_edge.Location = new System.Drawing.Point(16, 171);
            this.move_edge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.move_edge.Name = "move_edge";
            this.move_edge.Size = new System.Drawing.Size(90, 19);
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
            this.delete_polygon.Location = new System.Drawing.Point(16, 193);
            this.delete_polygon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delete_polygon.Name = "delete_polygon";
            this.delete_polygon.Size = new System.Drawing.Size(111, 19);
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
            this.delete_vertice.Location = new System.Drawing.Point(16, 214);
            this.delete_vertice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.delete_vertice.Name = "delete_vertice";
            this.delete_vertice.Size = new System.Drawing.Size(104, 19);
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
            this.move_polygon.Location = new System.Drawing.Point(16, 127);
            this.move_polygon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.move_polygon.Name = "move_polygon";
            this.move_polygon.Size = new System.Drawing.Size(105, 19);
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
            this.move_vertice.Location = new System.Drawing.Point(16, 149);
            this.move_vertice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.move_vertice.Name = "move_vertice";
            this.move_vertice.Size = new System.Drawing.Size(98, 19);
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
            this.add_polygon.Location = new System.Drawing.Point(16, 83);
            this.add_polygon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.add_polygon.Name = "add_polygon";
            this.add_polygon.Size = new System.Drawing.Size(96, 19);
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
            this.add_vertice.Location = new System.Drawing.Point(16, 105);
            this.add_vertice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.add_vertice.Name = "add_vertice";
            this.add_vertice.Size = new System.Drawing.Size(89, 19);
            this.add_vertice.TabIndex = 1;
            this.add_vertice.TabStop = true;
            this.add_vertice.Text = "Add Vertice";
            this.add_vertice.UseVisualStyleBackColor = true;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(2, 7);
            this.clear_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(220, 51);
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
            this.drawing_panel.Location = new System.Drawing.Point(2, 2);
            this.drawing_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.drawing_panel.Name = "drawing_panel";
            this.drawing_panel.Size = new System.Drawing.Size(1502, 1078);
            this.drawing_panel.TabIndex = 2;
            this.drawing_panel.TabStop = false;
            this.drawing_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawing_panel_Paint);
            this.drawing_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseClick);
            this.drawing_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseDown);
            this.drawing_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseMove);
            this.drawing_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Drawing_panel_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.con_parallel);
            this.groupBox1.Controls.Add(this.con_length);
            this.groupBox1.Location = new System.Drawing.Point(16, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Constraints";
            // 
            // con_length
            // 
            this.con_length.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.con_length.AutoSize = true;
            this.con_length.Location = new System.Drawing.Point(13, 19);
            this.con_length.Name = "con_length";
            this.con_length.Size = new System.Drawing.Size(66, 19);
            this.con_length.TabIndex = 0;
            this.con_length.TabStop = true;
            this.con_length.Text = "Length";
            this.con_length.UseVisualStyleBackColor = true;
            // 
            // con_parallel
            // 
            this.con_parallel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.con_parallel.AutoSize = true;
            this.con_parallel.Location = new System.Drawing.Point(13, 44);
            this.con_parallel.Name = "con_parallel";
            this.con_parallel.Size = new System.Drawing.Size(70, 19);
            this.con_parallel.TabIndex = 0;
            this.con_parallel.TabStop = true;
            this.con_parallel.Text = "Parallel";
            this.con_parallel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1736, 1082);
            this.Controls.Add(this.layout_layout);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.layout_layout.ResumeLayout(false);
            this.controls_panel.ResumeLayout(false);
            this.controls_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing_panel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton con_parallel;
        private System.Windows.Forms.RadioButton con_length;
    }
}

