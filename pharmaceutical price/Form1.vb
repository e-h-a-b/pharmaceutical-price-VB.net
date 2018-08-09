Imports System.Threading

Public Class Form1

    Dim yu, uy
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        DataGridView1.Rows.Add({TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox3.Text})
        For i = 0 To DataGridView1.RowCount - 1
            Dim gh, hg, hh As New Double
            gh = DataGridView1.Rows(i).Cells(1).Value
            hg = DataGridView1.Rows(i).Cells(2).Value
            hh = DataGridView1.Rows(i).Cells(3).Value

            DataGridView1.Rows(i).Cells(5).Value = hh * hg
            DataGridView1.Rows(i).Cells(4).Value = (gh + hg) * DataGridView1.Rows(i).Cells(3).Value
        Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView1.Rows

            DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString
            DataGridView1.RowHeadersWidth = 80
            n1 += 1
        Next
        uy = 0
        For y = 0 To DataGridView1.RowCount - 1

            yu = yu + DataGridView1.Rows(y).Cells(4).Value
            uy = uy + DataGridView1.Rows(y).Cells(5).Value
            Label4.Text = yu

            Label6.Text = uy
        Next
    End Sub
    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is  _
        Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        For m = 0 To 1000
            DataGridView1.Rows.Add({TextBox1.Text, TextBox2.Text, TextBox3.Text})
            For i = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells(3).Value = DataGridView1.Rows(i).Cells(1).Value * DataGridView1.Rows(i).Cells(2).Value
            Next
            Dim ro As DataGridViewRow
            Dim n1 As Integer = 0
            For Each ro In DataGridView1.Rows

                DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString
                DataGridView1.RowHeadersWidth = 80
                n1 += 1
            Next
        Next
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TextBox5.Text = "C:\Users\" + GetUserName() + "\Desktop\default.txt"
        TextBox5.Text = Application.StartupPath & "\default.txt"
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        SaveGridData(DataGridView1, TextBox5.Text)

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Label4.Text = 0

        Label6.Text = 0
        yu = 0
        uy = 0
        LoadGridData(DataGridView1, TextBox5.Text)
        Thread.Sleep(1000)
        For i = 0 To DataGridView1.RowCount - 1
            Dim gh, hg, hh As New Double
            gh = DataGridView1.Rows(i).Cells(1).Value
            hg = DataGridView1.Rows(i).Cells(2).Value
            hh = DataGridView1.Rows(i).Cells(3).Value

            DataGridView1.Rows(i).Cells(5).Value = hh * hg
            DataGridView1.Rows(i).Cells(4).Value = (gh + hg) * DataGridView1.Rows(i).Cells(3).Value
            Label10.Text = i
        Next
        For y = 0 To DataGridView1.RowCount - 1

            yu = yu + DataGridView1.Rows(y).Cells(4).Value
            uy = uy + DataGridView1.Rows(y).Cells(5).Value
            Label4.Text = yu

            Label6.Text = uy
        Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView1.Rows

            DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString
            DataGridView1.RowHeadersWidth = 80
            n1 += 1
        Next
    End Sub




    Private Sub SaveGridData(ByRef ThisGrid As DataGridView, ByVal Filename As String)

        ThisGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        ThisGrid.SelectAll()

        IO.File.WriteAllText(Filename, ThisGrid.GetClipboardContent().GetText.TrimEnd)

        ThisGrid.ClearSelection()

    End Sub
    Private Sub LoadGridData(ByRef ThisGrid As DataGridView, ByVal Filename As String)
        ThisGrid.Rows.Clear()


        For Each THisLine In My.Computer.FileSystem.ReadAllText(Filename).Split(Environment.NewLine)

            ThisGrid.Rows.Add(Split(THisLine, "	"))

        Next

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Label4.Text = 0

        Label6.Text = 0
        yu = 0
        uy = 0
        For y = 0 To DataGridView1.RowCount - 1

            yu = yu + DataGridView1.Rows(y).Cells(4).Value
            uy = uy + DataGridView1.Rows(y).Cells(5).Value
            Label4.Text = yu

            Label6.Text = uy
        Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView1.Rows

            DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString
            DataGridView1.RowHeadersWidth = 80
            n1 += 1
        Next
    End Sub
End Class
