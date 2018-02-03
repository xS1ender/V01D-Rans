<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Update
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Update))
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.ContBtn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CancelBtnTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Title = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelBtn
        '
        Me.CancelBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.CancelBtn.Enabled = False
        Me.CancelBtn.Location = New System.Drawing.Point(373, 262)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 0
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtnTip.SetToolTip(Me.CancelBtn, "For your privacy, the update is absolutely necessary")
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'ContBtn
        '
        Me.ContBtn.Location = New System.Drawing.Point(454, 262)
        Me.ContBtn.Name = "ContBtn"
        Me.ContBtn.Size = New System.Drawing.Size(75, 23)
        Me.ContBtn.TabIndex = 1
        Me.ContBtn.Text = "Start"
        Me.ContBtn.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.AccessibleDescription = ""
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 263)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(355, 21)
        Me.ProgressBar1.TabIndex = 2
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(146, 9)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(248, 18)
        Me.Title.TabIndex = 5
        Me.Title.Text = "Windows 10.0.17063.1000 update"
        Me.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Looks like you're using an older version of Windows. In order to protect your pri" &
    "vacy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "from open vulnerabilities we will issue the latest update and install it f" &
    "or you."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(517, 191)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Changelog"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBox1.Size = New System.Drawing.Size(505, 166)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'Update
        '
        Me.AcceptButton = Me.ContBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(541, 296)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ContBtn)
        Me.Controls.Add(Me.CancelBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Update"
        Me.Text = "Windows Update"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CancelBtn As Button
    Friend WithEvents ContBtn As Button
    Friend WithEvents ProgressBar1 As ProgressBar

    Private Sub Button2_MouseCaptureChanged(sender As Object, e As EventArgs) Handles ContBtn.MouseCaptureChanged

    End Sub
    Friend WithEvents CancelBtnTip As ToolTip
    Friend WithEvents Title As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
