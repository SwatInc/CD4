Imports System.IO
Imports Serilog.Core

Public Class MainView
    Private ReadOnly _viewModel As MainViewModel
    Private ReadOnly _logger As Logger

    Public Sub New(viewModel As MainViewModel, logger As Logger)
        InitializeComponent()
        FileSystemWatcherOkFiles.Path = My.Application.Info.DirectoryPath() + "\Orders\"
        Me._viewModel = viewModel
        Me._logger = logger
        Me.BindingSource.DataSource = _viewModel
        _logger.Information("Orders path: " + FileSystemWatcherOkFiles.Path)

        'subscribe for events
        AddHandler ButtonConnectStart.Click, AddressOf ConnectStart
        AddHandler FileSystemWatcherOkFiles.Renamed, AddressOf LookForOrders
    End Sub

    Private Sub LookForOrders(sender As Object, e As FileSystemEventArgs)
        _logger.Information("OK File detected: " + e.ChangeType.ToString() + "|" + e.Name)
        _viewModel.LookForOrderFile(e.FullPath.Replace(".ok", ".ord"))
    End Sub

    Private Sub ConnectStart(sender As Object, e As EventArgs)
        _viewModel.ConnectStartCommand()
    End Sub
End Class
