Imports System.IO

Public Class Frm_ManageBook
    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click


    End Sub

    Public Sub Load_Books()

        If DataGridView1.Rows.Count <> 0 Then
            DataGridView1.Rows.Clear()
        End If

        'llama a la funcion de carga de registros de alumnos

        acciones.Connection = conexionSql

        acciones.CommandType = CommandType.Text

        acciones.CommandText = "Select bookid, bookname, author, price, tax, totalprice from bookmaster"

        lectordatos = acciones.ExecuteReader

        While lectordatos.Read = True

            DataGridView1.Rows.Add(DataGridView1.Rows.Count + 1, lectordatos.Item("bookid"), lectordatos.Item("bookname"), lectordatos.Item("author"), lectordatos.Item("price"), lectordatos.Item("tax"), lectordatos.Item("totalprice"))

        End While

        lectordatos.Close()

    End Sub

    Public Sub clear()
        pic_bookimg.Image = Nothing
        txt_author.Clear()
        txt_bookname.Clear()
        txt_price.Clear()
        txt_totalprice.Clear()
        cbo_tax.SelectedIndex = -1

    End Sub
    Public Sub Auto_bookid()

        txt_bookID.Clear()

        Try

            acciones.Connection = conexionSql

            acciones.CommandType = CommandType.Text

            acciones.CommandText = "select * from bookmaster order by ID desc"

            lectordatos = acciones.ExecuteReader


            lectordatos.Read()

            If lectordatos.HasRows = True Then

                txt_bookID.Text = lectordatos.Item("bookid").ToString + 1
            Else
                txt_bookID.Text = Date.Now.ToString("yyyy") & "001"

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
        lectordatos.Close()

    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Close()

    End Sub

    Private Sub pic_bookimg_Click(sender As Object, e As EventArgs) Handles pic_bookimg.Click

        Dim pop As OpenFileDialog = New OpenFileDialog
        If pop.ShowDialog <> Windows.Forms.DialogResult.Cancel Then


            pic_bookimg.Image = Image.FromFile(pop.FileName)

        End If

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click

        If txt_bookname.Text = String.Empty Or txt_price.Text = String.Empty Or txt_totalprice.Text = String.Empty Or txt_author.Text = String.Empty Then

            MsgBox("Warnig: Missing Required Field?", vbExclamation)
            Return
        Else

            Try



                acciones.Connection = conexionSql
                acciones.CommandType = CommandType.Text
                acciones.CommandText = "INSERT INTO bookmaster (bookid, bookname,author,price,tax,totalprice,img, status)VALUES(@bookid, @bookname, @author, @price, @tax, @totalprice, @img,@status)"
                acciones.Parameters.Clear()
                acciones.Parameters.AddWithValue("@bookid", txt_bookID.Text)
                acciones.Parameters.AddWithValue("@bookname", txt_bookname.Text)
                acciones.Parameters.AddWithValue("@author", txt_author.Text)
                acciones.Parameters.AddWithValue("@price", CDec(txt_price.Text))
                acciones.Parameters.AddWithValue("@tax", cbo_tax.Text)
                acciones.Parameters.AddWithValue("@totalprice", CDec(txt_totalprice.Text))


                Dim filesize As New UInt32
                Dim mstream As New System.IO.MemoryStream
                pic_bookimg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim picture() As Byte = mstream.GetBuffer
                filesize = mstream.Length
                mstream.Close()

                acciones.Parameters.AddWithValue("@img", picture)
                acciones.Parameters.AddWithValue("@status", "DISPONIBLE")

                acciones.ExecuteNonQuery()


                MsgBox("DATOS GUARDADOS", vbOKOnly + vbInformation)



                'conexion.close


            Catch ex As Exception

                MsgBox(ex.ToString)

            End Try

            clear()
            Auto_bookid()
            Load_Books()


        End If

    End Sub

    Private Sub cbo_tax_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tax.SelectedIndexChanged

        Try

            txt_totalprice.Text = CDec(txt_price.Text * cbo_tax.Text / 100) + txt_price.Text

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Frm_ManageBook_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.RowTemplate.Height = 30
        Auto_bookid()
        Load_Books()
    End Sub

    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click

        acciones.Connection = conexionSql

        acciones.CommandType = CommandType.Text

        acciones.CommandText = "Select bookid, bookname, author, price, tax, totalprice, img from bookmaster Where bookid='" & txt_search.Text & "'"

        lectordatos = acciones.ExecuteReader

        While lectordatos.Read = True

            txt_bookID.Text = lectordatos.Item("bookid")
            txt_bookname.Text = lectordatos.Item("bookname")
            txt_author.Text = lectordatos.Item("author")
            txt_price.Text = lectordatos.Item("price")
            cbo_tax.Text = lectordatos.Item("tax")
            txt_totalprice.Text = lectordatos.Item("totalprice")

            Dim bytes As Byte() = lectordatos.Item("img")
            Dim ms As New MemoryStream(bytes)
            pic_bookimg.Image = Image.FromStream(ms)


        End While

        lectordatos.Close()

    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click

        Try



            acciones.Connection = conexionSql
            acciones.CommandType = CommandType.Text
            acciones.CommandText = "UPDATE bookmaster SET bookid =@bookid, bookname = @bookname, author = @author, price =@price ,tax =@tax, totalprice =@totalprice, img =@img where bookid = @bookid "
            acciones.Parameters.Clear()

            acciones.Parameters.AddWithValue("@bookname", txt_bookname.Text)
            acciones.Parameters.AddWithValue("@author", txt_author.Text)
            acciones.Parameters.AddWithValue("@price", CDec(txt_price.Text))
            acciones.Parameters.AddWithValue("@tax", cbo_tax.Text)
            acciones.Parameters.AddWithValue("@totalprice", CDec(txt_totalprice.Text))


            Dim filesize As New UInt32
            Dim mstream As New System.IO.MemoryStream
            pic_bookimg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim picture() As Byte = mstream.GetBuffer
            filesize = mstream.Length
            mstream.Close()

            acciones.Parameters.AddWithValue("@img", picture)
            acciones.Parameters.AddWithValue("@bookid", txt_bookID.Text)

            acciones.ExecuteNonQuery()


            MsgBox("DATOS GUARDADOS", vbOKOnly + vbInformation)



            'conexion.close


        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

        clear()
        Auto_bookid()
        Load_Books()

    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click

        If MsgBox("los datos seran eliminados, ¿desea continuar?", vbQuestion + vbYesNo) = vbYes Then

            Try



                acciones.Connection = conexionSql
                acciones.CommandType = CommandType.Text
                acciones.CommandText = "DELETE from bookmaster where bookid = @bookid "
                acciones.Parameters.Clear()


                acciones.Parameters.AddWithValue("@bookid", txt_bookID.Text)

                acciones.ExecuteNonQuery()


                MsgBox("DATOS BORRADOS CORRECTAMENTE", vbOKOnly + vbInformation)



                'conexion.close


            Catch ex As Exception

                MsgBox(ex.ToString)

            End Try

            clear()
            Auto_bookid()
            Load_Books()

        Else
            Return
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clear()

    End Sub
End Class