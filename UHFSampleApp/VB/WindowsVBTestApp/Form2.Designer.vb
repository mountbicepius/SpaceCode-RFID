<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTagsList = New System.Windows.Forms.RichTextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtTagsList
        '
        Me.txtTagsList.Location = New System.Drawing.Point(110, 12)
        Me.txtTagsList.Name = "txtTagsList"
        Me.txtTagsList.Size = New System.Drawing.Size(222, 175)
        Me.txtTagsList.TabIndex = 18
        Me.txtTagsList.Text = ""
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(357, 35)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(41, 13)
        Me.lblCount.TabIndex = 17
        Me.lblCount.Text = "Count :"
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(20, 54)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(75, 23)
        Me.btnScan.TabIndex = 16
        Me.btnScan.Text = "Start Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 261)
        Me.Controls.Add(Me.txtTagsList)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnScan)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtTagsList As System.Windows.Forms.RichTextBox
    Private WithEvents lblCount As System.Windows.Forms.Label
    Private WithEvents btnScan As System.Windows.Forms.Button
End Class
