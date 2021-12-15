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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Addnode = New System.Windows.Forms.Button()
        Me.Deletenode = New System.Windows.Forms.Button()
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
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.Nodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Addnode
        '
        Me.Addnode.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Addnode.Location = New System.Drawing.Point(22, 444)
        Me.Addnode.Name = "Addnode"
        Me.Addnode.Size = New System.Drawing.Size(150, 76)
        Me.Addnode.TabIndex = 0
        Me.Addnode.Text = "Add Node"
        Me.Addnode.UseVisualStyleBackColor = True
        '
        'Deletenode
        '
        Me.Deletenode.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Deletenode.Location = New System.Drawing.Point(224, 444)
        Me.Deletenode.Name = "Deletenode"
        Me.Deletenode.Size = New System.Drawing.Size(150, 76)
        Me.Deletenode.TabIndex = 2
        Me.Deletenode.Text = "Delete Node"
        Me.Deletenode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Deletenode.UseVisualStyleBackColor = True
        '
        'Nodes
        '
        Me.Nodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Nodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Nodes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Nodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Nodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.n, Me.c, Me.t, Me.p, Me.f})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Nodes.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nodes.Location = New System.Drawing.Point(22, 59)
        Me.Nodes.Name = "Nodes"
        Me.Nodes.RowHeadersWidth = 51
        Me.Nodes.RowTemplate.Height = 29
        Me.Nodes.Size = New System.Drawing.Size(554, 342)
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
        Me.Calculate.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Calculate.Location = New System.Drawing.Point(426, 444)
        Me.Calculate.Name = "Calculate"
        Me.Calculate.Size = New System.Drawing.Size(150, 76)
        Me.Calculate.TabIndex = 5
        Me.Calculate.Text = "Calculate Forces"
        Me.Calculate.UseVisualStyleBackColor = True
        '
        'Forces
        '
        Me.Forces.FormattingEnabled = True
        Me.Forces.ItemHeight = 20
        Me.Forces.Location = New System.Drawing.Point(605, 96)
        Me.Forces.Name = "Forces"
        Me.Forces.Size = New System.Drawing.Size(102, 424)
        Me.Forces.TabIndex = 6
        '
        'Answer
        '
        Me.Answer.FormattingEnabled = True
        Me.Answer.ItemHeight = 20
        Me.Answer.Location = New System.Drawing.Point(713, 96)
        Me.Answer.Name = "Answer"
        Me.Answer.Size = New System.Drawing.Size(102, 424)
        Me.Answer.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(609, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Force Names"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(719, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Force Values"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1428, 549)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Answer)
        Me.Controls.Add(Me.Forces)
        Me.Controls.Add(Me.Calculate)
        Me.Controls.Add(Me.Nodes)
        Me.Controls.Add(Me.Deletenode)
        Me.Controls.Add(Me.Addnode)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1450, 600)
        Me.Name = "Form1"
        Me.Text = "Ultimate Truss Solver"
        CType(Me.Nodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Addnode As Button
    Friend WithEvents Deletenode As Button
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
    Friend WithEvents Label2 As Label
End Class
