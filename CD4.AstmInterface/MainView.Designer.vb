<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainView))
        Me.TextBoxIPAddress = New System.Windows.Forms.TextBox()
        Me.LabelIPAddress = New System.Windows.Forms.Label()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ButtonConnectStart = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxPort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelSocketStatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FileSystemWatcherOkFiles = New System.IO.FileSystemWatcher()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxCOMPort = New System.Windows.Forms.TextBox()
        Me.LabelCOM = New System.Windows.Forms.Label()
        Me.LabelModel = New System.Windows.Forms.Label()
        Me.LabelModeDisplay = New System.Windows.Forms.Label()
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.FileSystemWatcherOkFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxIPAddress
        '
        Me.TextBoxIPAddress.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "IpAddress", True))
        Me.TextBoxIPAddress.Location = New System.Drawing.Point(72, 29)
        Me.TextBoxIPAddress.Name = "TextBoxIPAddress"
        Me.TextBoxIPAddress.Size = New System.Drawing.Size(210, 22)
        Me.TextBoxIPAddress.TabIndex = 0
        '
        'LabelIPAddress
        '
        Me.LabelIPAddress.AutoSize = True
        Me.LabelIPAddress.Location = New System.Drawing.Point(8, 32)
        Me.LabelIPAddress.Name = "LabelIPAddress"
        Me.LabelIPAddress.Size = New System.Drawing.Size(60, 13)
        Me.LabelIPAddress.TabIndex = 2
        Me.LabelIPAddress.Text = "IP Address"
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.Location = New System.Drawing.Point(40, 58)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(28, 13)
        Me.LabelPort.TabIndex = 3
        Me.LabelPort.Text = "Port"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource, "IsServer", True))
        Me.CheckBox1.Location = New System.Drawing.Point(214, 58)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Is Server"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ButtonConnectStart
        '
        Me.ButtonConnectStart.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "ConnectStartButtoncaption", True))
        Me.ButtonConnectStart.Location = New System.Drawing.Point(280, 181)
        Me.ButtonConnectStart.Name = "ButtonConnectStart"
        Me.ButtonConnectStart.Size = New System.Drawing.Size(100, 23)
        Me.ButtonConnectStart.TabIndex = 8
        Me.ButtonConnectStart.Text = "ConnectStart"
        Me.ButtonConnectStart.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxPort)
        Me.GroupBox1.Controls.Add(Me.TextBoxIPAddress)
        Me.GroupBox1.Controls.Add(Me.LabelIPAddress)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.LabelPort)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 124)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Socket Configuration"
        '
        'TextBoxPort
        '
        Me.TextBoxPort.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "Port", True))
        Me.TextBoxPort.Location = New System.Drawing.Point(72, 55)
        Me.TextBoxPort.Name = "TextBoxPort"
        Me.TextBoxPort.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxPort.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Socket Status: "
        '
        'LabelSocketStatus
        '
        Me.LabelSocketStatus.AutoSize = True
        Me.LabelSocketStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "SocketStatus", True))
        Me.LabelSocketStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSocketStatus.Location = New System.Drawing.Point(97, 159)
        Me.LabelSocketStatus.Name = "LabelSocketStatus"
        Me.LabelSocketStatus.Size = New System.Drawing.Size(19, 13)
        Me.LabelSocketStatus.TabIndex = 15
        Me.LabelSocketStatus.Text = "---"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 191)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Encoding: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "DataEncoding", True))
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(93, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "utf-8"
        '
        'FileSystemWatcherOkFiles
        '
        Me.FileSystemWatcherOkFiles.EnableRaisingEvents = True
        Me.FileSystemWatcherOkFiles.Filter = "*.ok"
        Me.FileSystemWatcherOkFiles.SynchronizingObject = Me
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxCOMPort)
        Me.GroupBox2.Controls.Add(Me.LabelCOM)
        Me.GroupBox2.Location = New System.Drawing.Point(386, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 124)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Serial Configuration"
        '
        'TextBoxCOMPort
        '
        Me.TextBoxCOMPort.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "ComPort", True))
        Me.TextBoxCOMPort.Location = New System.Drawing.Point(78, 29)
        Me.TextBoxCOMPort.Name = "TextBoxCOMPort"
        Me.TextBoxCOMPort.Size = New System.Drawing.Size(61, 22)
        Me.TextBoxCOMPort.TabIndex = 3
        '
        'LabelCOM
        '
        Me.LabelCOM.AutoSize = True
        Me.LabelCOM.Location = New System.Drawing.Point(15, 32)
        Me.LabelCOM.Name = "LabelCOM"
        Me.LabelCOM.Size = New System.Drawing.Size(57, 13)
        Me.LabelCOM.TabIndex = 4
        Me.LabelCOM.Text = "COM Port"
        '
        'LabelModel
        '
        Me.LabelModel.AutoSize = True
        Me.LabelModel.Location = New System.Drawing.Point(32, 176)
        Me.LabelModel.Name = "LabelModel"
        Me.LabelModel.Size = New System.Drawing.Size(55, 13)
        Me.LabelModel.TabIndex = 17
        Me.LabelModel.Text = "Interface:"
        '
        'LabelModeDisplay
        '
        Me.LabelModeDisplay.AutoSize = True
        Me.LabelModeDisplay.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.CD4.AstmInterface.My.MySettings.Default, "EthernetOrSerial", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LabelModeDisplay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelModeDisplay.Location = New System.Drawing.Point(93, 176)
        Me.LabelModeDisplay.Name = "LabelModeDisplay"
        Me.LabelModeDisplay.Size = New System.Drawing.Size(35, 13)
        Me.LabelModeDisplay.TabIndex = 14
        Me.LabelModeDisplay.Text = Global.CD4.AstmInterface.My.MySettings.Default.EthernetOrSerial
        '
        'BindingSource
        '
        Me.BindingSource.DataSource = GetType(CD4.AstmInterface.MainViewModel)
        '
        'MainView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 211)
        Me.Controls.Add(Me.LabelModel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonConnectStart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelSocketStatus)
        Me.Controls.Add(Me.LabelModeDisplay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource, "MainViewTitle", True))
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainView"
        Me.Text = "Main View"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.FileSystemWatcherOkFiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxIPAddress As TextBox
    Friend WithEvents LabelIPAddress As Label
    Friend WithEvents LabelPort As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ButtonConnectStart As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BindingSource As BindingSource
    Friend WithEvents TextBoxPort As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelModeDisplay As Label
    Friend WithEvents LabelSocketStatus As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents FileSystemWatcherOkFiles As IO.FileSystemWatcher
    Friend WithEvents LabelModel As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBoxCOMPort As TextBox
    Friend WithEvents LabelCOM As Label
End Class
