namespace Diplom
{
    partial class main
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
            System.Windows.Forms.Label category_IdLabel;
            System.Windows.Forms.Label cost_SummLabel;
            System.Windows.Forms.Label cost_DateLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Guna.Charts.WinForms.LPoint lPoint2 = new Guna.Charts.WinForms.LPoint();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.diplomDataSet = new Diplom.DiplomDataSet();
            this.costsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.costsTableAdapter = new Diplom.DiplomDataSetTableAdapters.CostsTableAdapter();
            this.tableAdapterManager = new Diplom.DiplomDataSetTableAdapters.TableAdapterManager();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.costsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cost_SummTextBox = new System.Windows.Forms.TextBox();
            this.cost_DateTextBox = new System.Windows.Forms.TextBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.diplomDataSet1 = new Diplom.DiplomDataSet1();
            this.costsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.costsTableAdapter1 = new Diplom.DiplomDataSet1TableAdapters.CostsTableAdapter();
            this.tableAdapterManager1 = new Diplom.DiplomDataSet1TableAdapters.TableAdapterManager();
            this.diplomDataSet2 = new Diplom.DiplomDataSet2();
            this.costsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.costsTableAdapter2 = new Diplom.DiplomDataSet2TableAdapters.CostsTableAdapter();
            this.tableAdapterManager2 = new Diplom.DiplomDataSet2TableAdapters.TableAdapterManager();
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costSummDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaPieDataset1 = new Guna.Charts.WinForms.GunaPieDataset();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.costsBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            category_IdLabel = new System.Windows.Forms.Label();
            cost_SummLabel = new System.Windows.Forms.Label();
            cost_DateLabel = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diplomDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // category_IdLabel
            // 
            category_IdLabel.AutoSize = true;
            category_IdLabel.Location = new System.Drawing.Point(131, 371);
            category_IdLabel.Name = "category_IdLabel";
            category_IdLabel.Size = new System.Drawing.Size(63, 13);
            category_IdLabel.TabIndex = 10;
            category_IdLabel.Text = "Категория:";
            category_IdLabel.Click += new System.EventHandler(this.category_IdLabel_Click);
            // 
            // cost_SummLabel
            // 
            cost_SummLabel.AutoSize = true;
            cost_SummLabel.Location = new System.Drawing.Point(78, 397);
            cost_SummLabel.Name = "cost_SummLabel";
            cost_SummLabel.Size = new System.Drawing.Size(112, 13);
            cost_SummLabel.TabIndex = 11;
            cost_SummLabel.Text = "Потраченная сумма:";
            // 
            // cost_DateLabel
            // 
            cost_DateLabel.AutoSize = true;
            cost_DateLabel.Location = new System.Drawing.Point(154, 423);
            cost_DateLabel.Name = "cost_DateLabel";
            cost_DateLabel.Size = new System.Drawing.Size(36, 13);
            cost_DateLabel.TabIndex = 12;
            cost_DateLabel.Text = "Дата:";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 22F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(248, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Учет финансов";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(731, 91);
            this.guna2Panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.label2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(685, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // diplomDataSet
            // 
            this.diplomDataSet.DataSetName = "DiplomDataSet";
            this.diplomDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // costsBindingSource
            // 
            this.costsBindingSource.DataMember = "Costs";
            this.costsBindingSource.DataSource = this.diplomDataSet;
            // 
            // costsTableAdapter
            // 
            this.costsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoriesTableAdapter = null;
            this.tableAdapterManager.CostsTableAdapter = this.costsTableAdapter;
            this.tableAdapterManager.RolesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Diplom.DiplomDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UsersTableAdapter = null;
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.ColumnHeadersHeight = 15;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryNameDataGridViewTextBoxColumn,
            this.costSummDataGridViewTextBoxColumn,
            this.costDateDataGridViewTextBoxColumn});
            this.guna2DataGridView1.DataSource = this.costsBindingSource3;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(81, 144);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.Size = new System.Drawing.Size(547, 150);
            this.guna2DataGridView1.TabIndex = 10;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 15;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // costsBindingSource1
            // 
            this.costsBindingSource1.DataMember = "Costs";
            this.costsBindingSource1.DataSource = this.diplomDataSet;
            // 
            // cost_SummTextBox
            // 
            this.cost_SummTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.costsBindingSource3, "Cost_Summ", true));
            this.cost_SummTextBox.Location = new System.Drawing.Point(201, 394);
            this.cost_SummTextBox.Name = "cost_SummTextBox";
            this.cost_SummTextBox.Size = new System.Drawing.Size(100, 20);
            this.cost_SummTextBox.TabIndex = 12;
            // 
            // cost_DateTextBox
            // 
            this.cost_DateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.costsBindingSource3, "Cost_Date", true));
            this.cost_DateTextBox.Location = new System.Drawing.Point(201, 420);
            this.cost_DateTextBox.Name = "cost_DateTextBox";
            this.cost_DateTextBox.Size = new System.Drawing.Size(100, 20);
            this.cost_DateTextBox.TabIndex = 13;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.guna2CirclePictureBox1.Image = global::Diplom.Properties.Resources.DeWatermark_ai_1716395980170__1_;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(-15, 8);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(125, 71);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 7;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // diplomDataSet1
            // 
            this.diplomDataSet1.DataSetName = "DiplomDataSet1";
            this.diplomDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // costsBindingSource2
            // 
            this.costsBindingSource2.DataMember = "Costs";
            this.costsBindingSource2.DataSource = this.diplomDataSet1;
            // 
            // costsTableAdapter1
            // 
            this.costsTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.CategoriesTableAdapter = null;
            this.tableAdapterManager1.CostsTableAdapter = this.costsTableAdapter1;
            this.tableAdapterManager1.RolesTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Diplom.DiplomDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.UsersTableAdapter = null;
            // 
            // diplomDataSet2
            // 
            this.diplomDataSet2.DataSetName = "DiplomDataSet2";
            this.diplomDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // costsBindingSource3
            // 
            this.costsBindingSource3.DataMember = "Costs";
            this.costsBindingSource3.DataSource = this.diplomDataSet2;
            // 
            // costsTableAdapter2
            // 
            this.costsTableAdapter2.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.CategoriesTableAdapter = null;
            this.tableAdapterManager2.CostsTableAdapter = this.costsTableAdapter2;
            this.tableAdapterManager2.RolesTableAdapter = null;
            this.tableAdapterManager2.UpdateOrder = Diplom.DiplomDataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager2.UsersTableAdapter = null;
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "Category_Name";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            this.categoryNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costSummDataGridViewTextBoxColumn
            // 
            this.costSummDataGridViewTextBoxColumn.DataPropertyName = "Cost_Summ";
            this.costSummDataGridViewTextBoxColumn.HeaderText = "Потраченная сумма";
            this.costSummDataGridViewTextBoxColumn.Name = "costSummDataGridViewTextBoxColumn";
            this.costSummDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costDateDataGridViewTextBoxColumn
            // 
            this.costDateDataGridViewTextBoxColumn.DataPropertyName = "Cost_Date";
            this.costDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.costDateDataGridViewTextBoxColumn.Name = "costDateDataGridViewTextBoxColumn";
            this.costDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gunaPieDataset1
            // 
            lPoint2.Y = 1D;
            this.gunaPieDataset1.DataPoints.AddRange(new Guna.Charts.WinForms.LPoint[] {
            lPoint2});
            this.gunaPieDataset1.Label = "Pie1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(224)))), ((int)(((byte)(170)))));
            this.label4.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(649, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "—";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.costsBindingSource3, "Category_Name", true));
            this.comboBox1.DataSource = this.costsBindingSource3;
            this.comboBox1.DisplayMember = "Category_Name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 368);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // costsBindingSource4
            // 
            this.costsBindingSource4.DataMember = "Costs";
            this.costsBindingSource4.DataSource = this.diplomDataSet2;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(245)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(719, 551);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(cost_DateLabel);
            this.Controls.Add(this.cost_DateTextBox);
            this.Controls.Add(cost_SummLabel);
            this.Controls.Add(this.cost_SummTextBox);
            this.Controls.Add(category_IdLabel);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diplomDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diplomDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costsBindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource costsBindingSource;
        private DiplomDataSet diplomDataSet;
        private DiplomDataSetTableAdapters.CostsTableAdapter costsTableAdapter;
        private DiplomDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.BindingSource costsBindingSource1;
        private System.Windows.Forms.TextBox cost_DateTextBox;
        private System.Windows.Forms.TextBox cost_SummTextBox;
        private DiplomDataSet1 diplomDataSet1;
        private System.Windows.Forms.BindingSource costsBindingSource2;
        private DiplomDataSet1TableAdapters.CostsTableAdapter costsTableAdapter1;
        private DiplomDataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private DiplomDataSet2 diplomDataSet2;
        private System.Windows.Forms.BindingSource costsBindingSource3;
        private DiplomDataSet2TableAdapters.CostsTableAdapter costsTableAdapter2;
        private DiplomDataSet2TableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costSummDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDateDataGridViewTextBoxColumn;
        private Guna.Charts.WinForms.GunaPieDataset gunaPieDataset1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource costsBindingSource4;
    }
}