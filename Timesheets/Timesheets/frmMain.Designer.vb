<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblHeading1 = New System.Windows.Forms.Label()
        Me.lblHoursWorked = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.chkDateSpecific = New System.Windows.Forms.CheckBox()
        Me.lblHeading4 = New System.Windows.Forms.Label()
        Me.musBar = New System.Windows.Forms.MenuStrip()
        Me.musFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.muiOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.muiSaveCSV = New System.Windows.Forms.ToolStripMenuItem()
        Me.muiSaveSummaryPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.musSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.muiChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.musHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.muiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgSaveCSV = New System.Windows.Forms.SaveFileDialog()
        Me.dlgSavePDF = New System.Windows.Forms.SaveFileDialog()
        Me.chtHours = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabHours = New System.Windows.Forms.TabPage()
        Me.lblHeading5 = New System.Windows.Forms.Label()
        Me.lblSelectedUser = New System.Windows.Forms.Label()
        Me.tabGraph = New System.Windows.Forms.TabPage()
        Me.lstFlag = New System.Windows.Forms.ListView()
        Me.chdName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chdDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblHeading3 = New System.Windows.Forms.Label()
        Me.lstSelectUser = New System.Windows.Forms.ListBox()
        Me.musBar.SuspendLayout()
        CType(Me.chtHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.tabHours.SuspendLayout()
        Me.tabGraph.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(470, 35)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(133, 25)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Timesheets"
        '
        'lblHeading1
        '
        Me.lblHeading1.AutoSize = True
        Me.lblHeading1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading1.Location = New System.Drawing.Point(25, 97)
        Me.lblHeading1.Name = "lblHeading1"
        Me.lblHeading1.Size = New System.Drawing.Size(82, 18)
        Me.lblHeading1.TabIndex = 18
        Me.lblHeading1.Text = "Employees"
        Me.lblHeading1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHoursWorked
        '
        Me.lblHoursWorked.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoursWorked.Location = New System.Drawing.Point(148, 181)
        Me.lblHoursWorked.Name = "lblHoursWorked"
        Me.lblHoursWorked.Size = New System.Drawing.Size(308, 39)
        Me.lblHoursWorked.TabIndex = 46
        Me.lblHoursWorked.Text = "0"
        Me.lblHoursWorked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Enabled = False
        Me.dtpStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(392, 84)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(107, 21)
        Me.dtpStartDate.TabIndex = 4
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Enabled = False
        Me.dtpEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(582, 84)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(110, 21)
        Me.dtpEndDate.TabIndex = 5
        '
        'chkDateSpecific
        '
        Me.chkDateSpecific.AutoSize = True
        Me.chkDateSpecific.Enabled = False
        Me.chkDateSpecific.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDateSpecific.Location = New System.Drawing.Point(270, 84)
        Me.chkDateSpecific.Name = "chkDateSpecific"
        Me.chkDateSpecific.Size = New System.Drawing.Size(106, 19)
        Me.chkDateSpecific.TabIndex = 3
        Me.chkDateSpecific.Text = "Range of Days"
        Me.chkDateSpecific.UseVisualStyleBackColor = True
        '
        'lblHeading4
        '
        Me.lblHeading4.AutoSize = True
        Me.lblHeading4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading4.Location = New System.Drawing.Point(529, 85)
        Me.lblHeading4.Name = "lblHeading4"
        Me.lblHeading4.Size = New System.Drawing.Size(21, 15)
        Me.lblHeading4.TabIndex = 47
        Me.lblHeading4.Text = "To"
        '
        'musBar
        '
        Me.musBar.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.musBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.musFile, Me.musSettings, Me.musHelp})
        Me.musBar.Location = New System.Drawing.Point(0, 0)
        Me.musBar.Name = "musBar"
        Me.musBar.Size = New System.Drawing.Size(960, 24)
        Me.musBar.TabIndex = 8
        Me.musBar.Text = "MenuStrip1"
        '
        'musFile
        '
        Me.musFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.muiOpen, Me.muiSaveCSV, Me.muiSaveSummaryPDF})
        Me.musFile.Name = "musFile"
        Me.musFile.Size = New System.Drawing.Size(37, 20)
        Me.musFile.Text = "File"
        '
        'muiOpen
        '
        Me.muiOpen.Name = "muiOpen"
        Me.muiOpen.Size = New System.Drawing.Size(169, 22)
        Me.muiOpen.Text = "Open"
        '
        'muiSaveCSV
        '
        Me.muiSaveCSV.Enabled = False
        Me.muiSaveCSV.Name = "muiSaveCSV"
        Me.muiSaveCSV.Size = New System.Drawing.Size(169, 22)
        Me.muiSaveCSV.Text = "Export CSV"
        '
        'muiSaveSummaryPDF
        '
        Me.muiSaveSummaryPDF.Enabled = False
        Me.muiSaveSummaryPDF.Name = "muiSaveSummaryPDF"
        Me.muiSaveSummaryPDF.Size = New System.Drawing.Size(169, 22)
        Me.muiSaveSummaryPDF.Text = "Export PDF Report"
        '
        'musSettings
        '
        Me.musSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.muiChangePassword})
        Me.musSettings.Name = "musSettings"
        Me.musSettings.Size = New System.Drawing.Size(61, 20)
        Me.musSettings.Text = "Settings"
        '
        'muiChangePassword
        '
        Me.muiChangePassword.Name = "muiChangePassword"
        Me.muiChangePassword.Size = New System.Drawing.Size(168, 22)
        Me.muiChangePassword.Text = "Change Password"
        '
        'musHelp
        '
        Me.musHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.muiAbout})
        Me.musHelp.Name = "musHelp"
        Me.musHelp.Size = New System.Drawing.Size(44, 20)
        Me.musHelp.Text = "Help"
        '
        'muiAbout
        '
        Me.muiAbout.Name = "muiAbout"
        Me.muiAbout.Size = New System.Drawing.Size(107, 22)
        Me.muiAbout.Text = "About"
        '
        'dlgSaveCSV
        '
        Me.dlgSaveCSV.Filter = "Comma Separated Values File | *.csv"
        '
        'dlgSavePDF
        '
        Me.dlgSavePDF.Filter = "Portable Document File | *.pdf"
        '
        'chtHours
        '
        Me.chtHours.BorderSkin.BackColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisX.Title = "Employees"
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.Title = "Number of hours worked"
        ChartArea1.Name = "ctaMain"
        Me.chtHours.ChartAreas.Add(ChartArea1)
        Me.chtHours.Location = New System.Drawing.Point(8, 8)
        Me.chtHours.Name = "chtHours"
        Series1.ChartArea = "ctaMain"
        Series1.IsValueShownAsLabel = True
        Series1.Name = "srsMain"
        Me.chtHours.Series.Add(Series1)
        Me.chtHours.Size = New System.Drawing.Size(588, 308)
        Me.chtHours.TabIndex = 49
        Title1.Name = "tleMain"
        Title1.Text = "Number of hours worked by employees"
        Me.chtHours.Titles.Add(Title1)
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabHours)
        Me.tabControl.Controls.Add(Me.tabGraph)
        Me.tabControl.Enabled = False
        Me.tabControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl.Location = New System.Drawing.Point(126, 117)
        Me.tabControl.Margin = New System.Windows.Forms.Padding(2)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(612, 380)
        Me.tabControl.TabIndex = 1
        '
        'tabHours
        '
        Me.tabHours.Controls.Add(Me.lblHeading5)
        Me.tabHours.Controls.Add(Me.lblSelectedUser)
        Me.tabHours.Controls.Add(Me.lblHoursWorked)
        Me.tabHours.Location = New System.Drawing.Point(4, 24)
        Me.tabHours.Margin = New System.Windows.Forms.Padding(2)
        Me.tabHours.Name = "tabHours"
        Me.tabHours.Padding = New System.Windows.Forms.Padding(2)
        Me.tabHours.Size = New System.Drawing.Size(604, 352)
        Me.tabHours.TabIndex = 0
        Me.tabHours.Text = "Hours"
        Me.tabHours.UseVisualStyleBackColor = True
        '
        'lblHeading5
        '
        Me.lblHeading5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading5.Location = New System.Drawing.Point(148, 103)
        Me.lblHeading5.Name = "lblHeading5"
        Me.lblHeading5.Size = New System.Drawing.Size(308, 39)
        Me.lblHeading5.TabIndex = 48
        Me.lblHeading5.Text = "Hours worked by"
        Me.lblHeading5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSelectedUser
        '
        Me.lblSelectedUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedUser.Location = New System.Drawing.Point(148, 142)
        Me.lblSelectedUser.Name = "lblSelectedUser"
        Me.lblSelectedUser.Size = New System.Drawing.Size(308, 39)
        Me.lblSelectedUser.TabIndex = 47
        Me.lblSelectedUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tabGraph
        '
        Me.tabGraph.Controls.Add(Me.chtHours)
        Me.tabGraph.Location = New System.Drawing.Point(4, 24)
        Me.tabGraph.Margin = New System.Windows.Forms.Padding(2)
        Me.tabGraph.Name = "tabGraph"
        Me.tabGraph.Padding = New System.Windows.Forms.Padding(2)
        Me.tabGraph.Size = New System.Drawing.Size(604, 352)
        Me.tabGraph.TabIndex = 1
        Me.tabGraph.Text = "Graph"
        Me.tabGraph.UseVisualStyleBackColor = True
        '
        'lstFlag
        '
        Me.lstFlag.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chdName, Me.chdDate})
        Me.lstFlag.Enabled = False
        Me.lstFlag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFlag.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstFlag.Location = New System.Drawing.Point(748, 117)
        Me.lstFlag.Margin = New System.Windows.Forms.Padding(2)
        Me.lstFlag.Name = "lstFlag"
        Me.lstFlag.Size = New System.Drawing.Size(198, 380)
        Me.lstFlag.TabIndex = 2
        Me.lstFlag.UseCompatibleStateImageBehavior = False
        Me.lstFlag.View = System.Windows.Forms.View.Details
        '
        'chdName
        '
        Me.chdName.Text = "Name"
        Me.chdName.Width = 90
        '
        'chdDate
        '
        Me.chdDate.Text = "Date"
        Me.chdDate.Width = 86
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(366, 29)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(2)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(100, 36)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 52
        Me.picLogo.TabStop = False
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "Comma Separated Values File | *.csv"
        '
        'btnLogout
        '
        Me.btnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(859, 32)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(86, 47)
        Me.btnLogout.TabIndex = 6
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'lblHeading3
        '
        Me.lblHeading3.AutoSize = True
        Me.lblHeading3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading3.Location = New System.Drawing.Point(773, 97)
        Me.lblHeading3.Name = "lblHeading3"
        Me.lblHeading3.Size = New System.Drawing.Size(149, 18)
        Me.lblHeading3.TabIndex = 55
        Me.lblHeading3.Text = "Who did not scan out"
        Me.lblHeading3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstSelectUser
        '
        Me.lstSelectUser.Enabled = False
        Me.lstSelectUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSelectUser.FormattingEnabled = True
        Me.lstSelectUser.ItemHeight = 15
        Me.lstSelectUser.Location = New System.Drawing.Point(16, 117)
        Me.lstSelectUser.Name = "lstSelectUser"
        Me.lstSelectUser.Size = New System.Drawing.Size(101, 379)
        Me.lstSelectUser.TabIndex = 56
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 512)
        Me.Controls.Add(Me.lstSelectUser)
        Me.Controls.Add(Me.lblHeading3)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.lstFlag)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.lblHeading4)
        Me.Controls.Add(Me.chkDateSpecific)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.lblHeading1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.musBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.musBar
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timesheets"
        Me.musBar.ResumeLayout(False)
        Me.musBar.PerformLayout()
        CType(Me.chtHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl.ResumeLayout(False)
        Me.tabHours.ResumeLayout(False)
        Me.tabGraph.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblHeading1 As Label
    Friend WithEvents lblHoursWorked As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents chkDateSpecific As CheckBox
    Friend WithEvents lblHeading4 As Label
    Friend WithEvents musBar As MenuStrip
    Friend WithEvents musFile As ToolStripMenuItem
    Friend WithEvents muiSaveCSV As ToolStripMenuItem
    Friend WithEvents muiSaveSummaryPDF As ToolStripMenuItem
    Friend WithEvents dlgSaveCSV As SaveFileDialog
    Friend WithEvents musHelp As ToolStripMenuItem
    Friend WithEvents dlgSavePDF As SaveFileDialog
    Friend WithEvents chtHours As DataVisualization.Charting.Chart
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabHours As TabPage
    Friend WithEvents tabGraph As TabPage
    Friend WithEvents lstFlag As ListView
    Friend WithEvents chdName As ColumnHeader
    Private WithEvents chdDate As ColumnHeader
    Friend WithEvents muiAbout As ToolStripMenuItem
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents muiOpen As ToolStripMenuItem
    Friend WithEvents dlgOpen As OpenFileDialog
    Friend WithEvents btnLogout As Button
    Friend WithEvents lblHeading3 As Label
    Friend WithEvents lblHeading5 As Label
    Friend WithEvents lblSelectedUser As Label
    Friend WithEvents musSettings As ToolStripMenuItem
    Friend WithEvents muiChangePassword As ToolStripMenuItem
    Friend WithEvents lstSelectUser As ListBox
End Class
