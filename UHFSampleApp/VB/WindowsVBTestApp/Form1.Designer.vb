<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.cmbPrinters = New System.Windows.Forms.ComboBox()
        Me.btnEncode = New System.Windows.Forms.Button()
        Me.txttag = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.trackBarDuty = New System.Windows.Forms.TrackBar()
        Me.label1 = New System.Windows.Forms.Label()
        Me.trackBarPower = New System.Windows.Forms.TrackBar()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.lblmsg = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnNewForm = New System.Windows.Forms.Button()
        Me.lblConnection = New System.Windows.Forms.Label()
        Me.txtTagsList = New System.Windows.Forms.RichTextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.btnConnect = New System.Windows.Forms.Button()
        CType(Me.trackBarDuty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBarPower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPrinters
        '
        Me.cmbPrinters.FormattingEnabled = True
        Me.cmbPrinters.Location = New System.Drawing.Point(97, 232)
        Me.cmbPrinters.Name = "cmbPrinters"
        Me.cmbPrinters.Size = New System.Drawing.Size(162, 21)
        Me.cmbPrinters.TabIndex = 63
        '
        'btnEncode
        '
        Me.btnEncode.Location = New System.Drawing.Point(183, 410)
        Me.btnEncode.Name = "btnEncode"
        Me.btnEncode.Size = New System.Drawing.Size(60, 23)
        Me.btnEncode.TabIndex = 62
        Me.btnEncode.Text = "Encode"
        Me.btnEncode.UseVisualStyleBackColor = True
        '
        'txttag
        '
        Me.txttag.Location = New System.Drawing.Point(11, 412)
        Me.txttag.Name = "txttag"
        Me.txttag.Size = New System.Drawing.Size(100, 20)
        Me.txttag.TabIndex = 61
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(14, 360)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(29, 13)
        Me.label2.TabIndex = 60
        Me.label2.Text = "Duty"
        '
        'trackBarDuty
        '
        Me.trackBarDuty.LargeChange = 1
        Me.trackBarDuty.Location = New System.Drawing.Point(98, 351)
        Me.trackBarDuty.Maximum = 95
        Me.trackBarDuty.Minimum = 5
        Me.trackBarDuty.Name = "trackBarDuty"
        Me.trackBarDuty.Size = New System.Drawing.Size(208, 45)
        Me.trackBarDuty.TabIndex = 59
        Me.trackBarDuty.TickFrequency = 10
        Me.trackBarDuty.Value = 90
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(14, 321)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(66, 13)
        Me.label1.TabIndex = 58
        Me.label1.Text = "Power Slider"
        '
        'trackBarPower
        '
        Me.trackBarPower.LargeChange = 1
        Me.trackBarPower.Location = New System.Drawing.Point(97, 311)
        Me.trackBarPower.Maximum = 31
        Me.trackBarPower.Name = "trackBarPower"
        Me.trackBarPower.Size = New System.Drawing.Size(208, 45)
        Me.trackBarPower.TabIndex = 57
        Me.trackBarPower.TickFrequency = 10
        Me.trackBarPower.Value = 31
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(117, 410)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(60, 23)
        Me.btnRead.TabIndex = 56
        Me.btnRead.Text = "Read"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'lblmsg
        '
        Me.lblmsg.AutoSize = True
        Me.lblmsg.Location = New System.Drawing.Point(11, 206)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Size = New System.Drawing.Size(26, 13)
        Me.lblmsg.TabIndex = 55
        Me.lblmsg.Text = "msg"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(265, 230)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(112, 23)
        Me.btnPrint.TabIndex = 54
        Me.btnPrint.Text = "Print Encode Zebra"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnNewForm
        '
        Me.btnNewForm.Location = New System.Drawing.Point(14, 129)
        Me.btnNewForm.Name = "btnNewForm"
        Me.btnNewForm.Size = New System.Drawing.Size(78, 23)
        Me.btnNewForm.TabIndex = 53
        Me.btnNewForm.Text = "Form2"
        Me.btnNewForm.UseVisualStyleBackColor = True
        '
        'lblConnection
        '
        Me.lblConnection.AutoSize = True
        Me.lblConnection.Location = New System.Drawing.Point(14, 240)
        Me.lblConnection.Name = "lblConnection"
        Me.lblConnection.Size = New System.Drawing.Size(60, 13)
        Me.lblConnection.TabIndex = 52
        Me.lblConnection.Text = "connection"
        '
        'txtTagsList
        '
        Me.txtTagsList.Location = New System.Drawing.Point(132, 15)
        Me.txtTagsList.Name = "txtTagsList"
        Me.txtTagsList.Size = New System.Drawing.Size(245, 175)
        Me.txtTagsList.TabIndex = 51
        Me.txtTagsList.Text = ""
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(22, 99)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(41, 13)
        Me.lblCount.TabIndex = 50
        Me.lblCount.Text = "Count :"
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(17, 56)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(75, 23)
        Me.btnScan.TabIndex = 49
        Me.btnScan.Text = "Start Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(17, 13)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 48
        Me.btnConnect.Text = "connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 447)
        Me.Controls.Add(Me.cmbPrinters)
        Me.Controls.Add(Me.btnEncode)
        Me.Controls.Add(Me.txttag)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.trackBarDuty)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.trackBarPower)
        Me.Controls.Add(Me.btnRead)
        Me.Controls.Add(Me.lblmsg)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnNewForm)
        Me.Controls.Add(Me.lblConnection)
        Me.Controls.Add(Me.txtTagsList)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnConnect)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.trackBarDuty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBarPower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cmbPrinters As System.Windows.Forms.ComboBox
    Private WithEvents btnEncode As System.Windows.Forms.Button
    Private WithEvents txttag As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents trackBarDuty As System.Windows.Forms.TrackBar
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents trackBarPower As System.Windows.Forms.TrackBar
    Private WithEvents btnRead As System.Windows.Forms.Button
    Private WithEvents lblmsg As System.Windows.Forms.Label
    Private WithEvents btnPrint As System.Windows.Forms.Button
    Private WithEvents btnNewForm As System.Windows.Forms.Button
    Private WithEvents lblConnection As System.Windows.Forms.Label
    Private WithEvents txtTagsList As System.Windows.Forms.RichTextBox
    Private WithEvents lblCount As System.Windows.Forms.Label
    Private WithEvents btnScan As System.Windows.Forms.Button
    Private WithEvents btnConnect As System.Windows.Forms.Button

End Class
