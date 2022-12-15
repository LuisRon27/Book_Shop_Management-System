Public Class Frm_User


    Private WithEvents pic As New PictureBox
    Private WithEvents lblbookid As New Label
    Private WithEvents lblbookname As New Label
    Private WithEvents lblprice As New Label

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt__search.TextChanged

        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.Controls.Clear()

        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select img,bookid,bookname, author,price,tax,totalprice,status From bookmaster WHERE status='' and bookid like '%" & txt__search.Text & "%' or bookname like '%" & txt__search.Text & "%'"
        lectordatos = acciones.ExecuteReader


        If lectordatos.HasRows Then

            While lectordatos.Read
                load_controls()

            End While
        End If

        'lectordatos.Dispose()

        lectordatos.Close()
    End Sub




    Private Sub Frm_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.RowTemplate.Height = 28
        lbl_TransactionDate.Text = Date.Now.ToString("yyyy-MM-dd")
        Auto_GenerateTrasnsNo()
        load_books()

    End Sub


    Sub Auto_GenerateTrasnsNo()

        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "Select * From bookinventory order by ID desc"
            lectordatos = acciones.ExecuteReader
            lectordatos.Read()

            If lectordatos.HasRows Then
                lbl_TransactionNo.Text = lectordatos.Item("transno").ToString + 1
            Else
                lbl_TransactionNo.Text = Date.Now.ToString("yyyyMM") & "001"


            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        lectordatos.Close()

    End Sub

    Sub total()
        Dim sum As Double = 0
        For k As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
            sum = sum + DataGridView1.Rows(k).Cells(6).Value


        Next

        lbl_GrandTotal.Text = Format(CDec(sum), "#,##0.00")

    End Sub

    Sub load_controls()

        Dim len As Long = lectordatos.GetBytes(0, 0, Nothing, 0, 0)
        Dim array(CInt(len)) As Byte
        lectordatos.GetBytes(0, 0, array, 0, CInt(len))

        pic = New PictureBox
        pic.Width = 120
        pic.Height = 150
        pic.BackgroundImageLayout = ImageLayout.Stretch
        pic.Tag = lectordatos.Item("bookid").ToString


        lblbookid = New Label
        With lblbookid
            .ForeColor = Color.Black
            .BackColor = Color.Wheat
            .TextAlign = ContentAlignment.MiddleLeft
            .Dock = DockStyle.Top
            .Font = New Font("Segoe UI", 8, FontStyle.Bold)
            .Tag = lectordatos.Item("bookid").ToString
        End With

        lblbookname = New Label
        With lblbookname
            .ForeColor = Color.Black
            .BackColor = Color.Wheat
            .TextAlign = ContentAlignment.MiddleLeft
            .Dock = DockStyle.Top
            .Font = New Font("Segoe UI", 8, FontStyle.Bold)
            .Tag = lectordatos.Item("bookid").ToString
        End With

        lblprice = New Label
        With lblprice
            .ForeColor = Color.Orange
            .BackColor = Color.Wheat
            .TextAlign = ContentAlignment.MiddleLeft
            .Dock = DockStyle.Bottom
            .Font = New Font("Segoe UI", 12, FontStyle.Bold)
            .Tag = lectordatos.Item("bookid").ToString
        End With

        Dim ms As New System.IO.MemoryStream(array)
        Dim bitmap As New System.Drawing.Bitmap(ms)
        pic.BackgroundImage = bitmap
        lblbookid.Text = lectordatos.Item("bookid").ToString
        lblbookname.Text = lectordatos.Item("bookname").ToString
        lblprice.Text = lectordatos.Item("totalprice").ToString

        pic.Controls.Add(lblbookid)
        pic.Controls.Add(lblbookname)
        pic.Controls.Add(lblprice)

        FlowLayoutPanel1.Controls.Add(pic)

        AddHandler pic.Click, AddressOf selectimg_click
        AddHandler lblbookid.Click, AddressOf selectimg_click
        AddHandler lblbookname.Click, AddressOf selectimg_click
        AddHandler lblprice.Click, AddressOf selectimg_click

        Dim status As String = lectordatos("status")

        ' Si el valor de la columna "estatus" es "sell", elimina el control del FlowLayoutPanel
        If status = "SELL" Then
            FlowLayoutPanel1.Controls.Remove(pic)
        End If


    End Sub

    Public Sub selectimg_click(sender As Object, e As EventArgs)

        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "Select  bookid, bookname, author, price, tax, totalprice From bookmaster WHERE bookid like '%" & sender.tag.ToString & "%'"
            lectordatos = acciones.ExecuteReader

            While lectordatos.Read = True


                DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, lectordatos.Item("bookid"), lectordatos.Item("bookname"), lectordatos.Item("author"), lectordatos.Item("price"), lectordatos.Item("tax"), lectordatos.Item("totalprice"))




            End While

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        lectordatos.Close()

    End Sub

    Public Sub load_books()


        FlowLayoutPanel1.AutoScroll = True

        FlowLayoutPanel1.Controls.Clear()

        acciones.Connection = conexionSql
        acciones.CommandType = CommandType.Text
        acciones.CommandText = "Select img,bookid,bookname, author,price,tax,totalprice,status From bookmaster"
        lectordatos = acciones.ExecuteReader


        If lectordatos.HasRows Then

            While lectordatos.Read



                load_controls()

            End While
        End If

        lectordatos.Dispose()

        lectordatos.Close()


    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click

        If MsgBox("Esta seguro que Desea Cerrar Sesion?", MsgBoxStyle.Question + vbYesNo) = vbYes Then

            Me.Close()
            frm_Login.txt_passwordlogin.Clear()
            frm_Login.Show()

        Else
            Return

        End If

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        total()
    End Sub

    Private Sub btn_pay_Click(sender As Object, e As EventArgs) Handles btn_pay.Click

        If lbl_GrandTotal.Text > txt_enteramount.Text Then
            MsgBox("insufficient amount", vbExclamation)
            Return

        Else

            Try
                acciones.Connection = conexionSql
                acciones.CommandType = CommandType.Text
                acciones.CommandText = "INSERT INTO bookinventory (transno, transdate, transmonth,bookid,bookname,author,price,tax,totalprice,grandtotal)VALUES(@transno,@transdate,@transmonth,@bookid,@bookname,@author,@price,@tax,@totalprice,@grandtotal)"
                For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                    acciones.Parameters.Clear()
                    acciones.Parameters.AddWithValue("@transno", lbl_TransactionNo.Text)
                    acciones.Parameters.AddWithValue("@transdate", lbl_TransactionDate.Text)
                    acciones.Parameters.AddWithValue("@transmonth", Date.Now.ToString("MM"))

                    acciones.Parameters.AddWithValue("@bookid", DataGridView1.Rows(j).Cells(1).Value)
                    acciones.Parameters.AddWithValue("@bookname", DataGridView1.Rows(j).Cells(2).Value)
                    acciones.Parameters.AddWithValue("@author", DataGridView1.Rows(j).Cells(3).Value)
                    acciones.Parameters.AddWithValue("@price", DataGridView1.Rows(j).Cells(4).Value)
                    acciones.Parameters.AddWithValue("@tax", DataGridView1.Rows(j).Cells(5).Value)
                    acciones.Parameters.AddWithValue("@totalprice", DataGridView1.Rows(j).Cells(6).Value)

                    acciones.Parameters.AddWithValue("@grandtotal", lbl_GrandTotal.Text)
                    acciones.ExecuteNonQuery()
                    MsgBox("Tranaction save Success!", vbOKOnly + vbInformation)



                Next

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            update_bookstock()
            clear()

        End If


    End Sub


    Sub clear()


        DataGridView1.Rows.Clear()
        load_books()
        Auto_GenerateTrasnsNo()
        txt_enteramount.Clear()
        txt__search.Clear()
        lbl_GrandTotal.Text = "0.00"

    End Sub


    Sub update_bookstock()

        Try

            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "UPDATE bookmaster SET status = @status where bookid = @bookid"

            For j As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                acciones.Parameters.Clear()
                acciones.Parameters.AddWithValue("@status", "SELL")
                acciones.Parameters.AddWithValue("@bookid", DataGridView1.Rows(j).Cells(1).Value)


                i = acciones.ExecuteNonQuery()
            Next




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_managebook_Click(sender As Object, e As EventArgs) Handles btn_managebook.Click
        clear()

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        frm_cancel.ShowDialog()

    End Sub


    Private Sub btn_report_Click(sender As Object, e As EventArgs) Handles btn_report.Click
        frm_report.ShowDialog()
    End Sub
End Class