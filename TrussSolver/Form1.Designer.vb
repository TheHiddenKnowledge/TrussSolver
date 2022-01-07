<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Nodes = New System.Windows.Forms.DataGridView()
        Me.n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.p = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Calculate = New System.Windows.Forms.Button()
        Me.Forces = New System.Windows.Forms.ListBox()
        Me.Answer = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoadExcel = New System.Windows.Forms.Button()
        Me.SaveExcel = New System.Windows.Forms.Button()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.Help = New System.Windows.Forms.Button()
        Me.Figure = New System.Windows.Forms.PictureBox()
        Me.Minimize = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        CType(Me.Nodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Figure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Nodes
        '
        Me.Nodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Nodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.Nodes.BackgroundColor = System.Drawing.Color.MistyRose
        Me.Nodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Nodes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Nodes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Nodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Nodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.n, Me.c, Me.t, Me.p, Me.f})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.MistyRose
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Nodes.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nodes.Location = New System.Drawing.Point(25, 53)
        Me.Nodes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Nodes.Name = "Nodes"
        Me.Nodes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.MistyRose
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Nodes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Nodes.RowHeadersWidth = 51
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.MistyRose
        Me.Nodes.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Nodes.RowTemplate.Height = 29
        Me.Nodes.Size = New System.Drawing.Size(623, 308)
        Me.Nodes.TabIndex = 4
        '
        'n
        '
        Me.n.HeaderText = "Node"
        Me.n.MinimumWidth = 6
        Me.n.Name = "n"
        '
        'c
        '
        Me.c.HeaderText = "Connections"
        Me.c.MinimumWidth = 6
        Me.c.Name = "c"
        '
        't
        '
        Me.t.HeaderText = "Support Type"
        Me.t.Items.AddRange(New Object() {"None", "Pin", "Roller"})
        Me.t.MinimumWidth = 6
        Me.t.Name = "t"
        Me.t.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.t.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'p
        '
        Me.p.HeaderText = "Position"
        Me.p.MinimumWidth = 6
        Me.p.Name = "p"
        '
        'f
        '
        Me.f.HeaderText = "Forces"
        Me.f.MinimumWidth = 6
        Me.f.Name = "f"
        '
        'Calculate
        '
        Me.Calculate.BackColor = System.Drawing.Color.DarkSalmon
        Me.Calculate.FlatAppearance.BorderColor = System.Drawing.Color.DarkSalmon
        Me.Calculate.FlatAppearance.BorderSize = 0
        Me.Calculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.Calculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Calculate.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Calculate.Location = New System.Drawing.Point(479, 399)
        Me.Calculate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Calculate.Name = "Calculate"
        Me.Calculate.Size = New System.Drawing.Size(169, 61)
        Me.Calculate.TabIndex = 5
        Me.Calculate.Text = "Calculate"
        Me.Calculate.UseVisualStyleBackColor = False
        '
        'Forces
        '
        Me.Forces.BackColor = System.Drawing.Color.MistyRose
        Me.Forces.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Forces.Cursor = System.Windows.Forms.Cursors.Default
        Me.Forces.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Forces.FormattingEnabled = True
        Me.Forces.ItemHeight = 24
        Me.Forces.Location = New System.Drawing.Point(680, 86)
        Me.Forces.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Forces.Name = "Forces"
        Me.Forces.Size = New System.Drawing.Size(114, 264)
        Me.Forces.TabIndex = 6
        '
        'Answer
        '
        Me.Answer.BackColor = System.Drawing.Color.MistyRose
        Me.Answer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Answer.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Answer.FormattingEnabled = True
        Me.Answer.ItemHeight = 24
        Me.Answer.Location = New System.Drawing.Point(802, 86)
        Me.Answer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Answer.Name = "Answer"
        Me.Answer.Size = New System.Drawing.Size(114, 264)
        Me.Answer.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DarkSalmon
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(719, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 34)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Force Names"
        '
        'LoadExcel
        '
        Me.LoadExcel.BackColor = System.Drawing.Color.DarkSalmon
        Me.LoadExcel.FlatAppearance.BorderColor = System.Drawing.Color.DarkSalmon
        Me.LoadExcel.FlatAppearance.BorderSize = 0
        Me.LoadExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.LoadExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.LoadExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LoadExcel.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.LoadExcel.Location = New System.Drawing.Point(252, 400)
        Me.LoadExcel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LoadExcel.Name = "LoadExcel"
        Me.LoadExcel.Size = New System.Drawing.Size(169, 61)
        Me.LoadExcel.TabIndex = 10
        Me.LoadExcel.Text = "Load"
        Me.LoadExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.LoadExcel.UseVisualStyleBackColor = False
        '
        'SaveExcel
        '
        Me.SaveExcel.BackColor = System.Drawing.Color.DarkSalmon
        Me.SaveExcel.FlatAppearance.BorderColor = System.Drawing.Color.DarkSalmon
        Me.SaveExcel.FlatAppearance.BorderSize = 0
        Me.SaveExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.SaveExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.SaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveExcel.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.SaveExcel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SaveExcel.Location = New System.Drawing.Point(25, 400)
        Me.SaveExcel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SaveExcel.Name = "SaveExcel"
        Me.SaveExcel.Size = New System.Drawing.Size(169, 61)
        Me.SaveExcel.TabIndex = 11
        Me.SaveExcel.Text = "Save"
        Me.SaveExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.SaveExcel.UseVisualStyleBackColor = False
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFile"
        '
        'Help
        '
        Me.Help.BackColor = System.Drawing.Color.DarkSalmon
        Me.Help.FlatAppearance.BorderColor = System.Drawing.Color.DarkSalmon
        Me.Help.FlatAppearance.BorderSize = 0
        Me.Help.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.Help.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Help.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Help.Location = New System.Drawing.Point(712, 399)
        Me.Help.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(169, 61)
        Me.Help.TabIndex = 12
        Me.Help.Text = "Help"
        Me.Help.UseVisualStyleBackColor = False
        '
        'Figure
        '
        Me.Figure.BackColor = System.Drawing.Color.MistyRose
        Me.Figure.Location = New System.Drawing.Point(941, 53)
        Me.Figure.Name = "Figure"
        Me.Figure.Size = New System.Drawing.Size(482, 407)
        Me.Figure.TabIndex = 13
        Me.Figure.TabStop = False
        '
        'Minimize
        '
        Me.Minimize.BackColor = System.Drawing.Color.DarkSalmon
        Me.Minimize.FlatAppearance.BorderColor = System.Drawing.Color.DarkSalmon
        Me.Minimize.FlatAppearance.BorderSize = 0
        Me.Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Minimize.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Minimize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Minimize.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Minimize.Location = New System.Drawing.Point(1323, -1)
        Me.Minimize.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Minimize.Name = "Minimize"
        Me.Minimize.Size = New System.Drawing.Size(53, 48)
        Me.Minimize.TabIndex = 14
        Me.Minimize.Text = "-"
        Me.Minimize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Minimize.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.DarkSalmon
        Me.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.DarkSalmon
        Me.ExitButton.FlatAppearance.BorderSize = 0
        Me.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MistyRose
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitButton.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.ExitButton.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ExitButton.Location = New System.Drawing.Point(1384, -1)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(53, 48)
        Me.ExitButton.TabIndex = 15
        Me.ExitButton.Text = "x"
        Me.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSalmon
        Me.ClientSize = New System.Drawing.Size(1435, 494)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.Minimize)
        Me.Controls.Add(Me.Figure)
        Me.Controls.Add(Me.Help)
        Me.Controls.Add(Me.SaveExcel)
        Me.Controls.Add(Me.LoadExcel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Answer)
        Me.Controls.Add(Me.Forces)
        Me.Controls.Add(Me.Calculate)
        Me.Controls.Add(Me.Nodes)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1628, 545)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Ultimate Truss Solver"
        Me.TransparencyKey = System.Drawing.Color.Gray
        CType(Me.Nodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Figure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Nodes As DataGridView
    Friend WithEvents Calculate As Button
    Friend WithEvents n As DataGridViewTextBoxColumn
    Friend WithEvents c As DataGridViewTextBoxColumn
    Friend WithEvents t As DataGridViewComboBoxColumn
    Friend WithEvents p As DataGridViewTextBoxColumn
    Friend WithEvents f As DataGridViewTextBoxColumn
    Friend WithEvents Forces As ListBox
    Friend WithEvents Answer As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LoadExcel As Button
    Friend WithEvents SaveExcel As Button
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents Help As Button
    Friend WithEvents Figure As PictureBox
    Friend WithEvents Minimize As Button
    Friend WithEvents ExitButton As Button
End Class
