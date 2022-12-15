<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_usernamelogin = New System.Windows.Forms.TextBox()
        Me.txt_passwordlogin = New System.Windows.Forms.TextBox()
        Me.btn_login = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.pbvisible = New System.Windows.Forms.PictureBox()
        Me.pbocultar = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbvisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbocultar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 62)
        Me.Panel1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(31, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 21)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Manage Users"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(92, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "UserName"
        '
        'txt_usernamelogin
        '
        Me.txt_usernamelogin.BackColor = System.Drawing.Color.White
        Me.txt_usernamelogin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_usernamelogin.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_usernamelogin.Location = New System.Drawing.Point(179, 378)
        Me.txt_usernamelogin.Name = "txt_usernamelogin"
        Me.txt_usernamelogin.Size = New System.Drawing.Size(246, 20)
        Me.txt_usernamelogin.TabIndex = 3
        Me.txt_usernamelogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_passwordlogin
        '
        Me.txt_passwordlogin.BackColor = System.Drawing.Color.White
        Me.txt_passwordlogin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_passwordlogin.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_passwordlogin.Location = New System.Drawing.Point(184, 451)
        Me.txt_passwordlogin.Name = "txt_passwordlogin"
        Me.txt_passwordlogin.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_passwordlogin.Size = New System.Drawing.Size(246, 20)
        Me.txt_passwordlogin.TabIndex = 5
        Me.txt_passwordlogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_login
        '
        Me.btn_login.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btn_login.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_login.FlatAppearance.BorderSize = 0
        Me.btn_login.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btn_login.ForeColor = System.Drawing.Color.White
        Me.btn_login.Location = New System.Drawing.Point(184, 513)
        Me.btn_login.Name = "btn_login"
        Me.btn_login.Size = New System.Drawing.Size(197, 36)
        Me.btn_login.TabIndex = 10
        Me.btn_login.Text = "Login"
        Me.btn_login.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(100, 449)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Password"
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exit.FlatAppearance.BorderSize = 0
        Me.btn_exit.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btn_exit.ForeColor = System.Drawing.Color.White
        Me.btn_exit.Location = New System.Drawing.Point(184, 564)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(197, 36)
        Me.btn_exit.TabIndex = 13
        Me.btn_exit.Text = "Exit"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 683)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 11)
        Me.Panel2.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(182, 457)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "________________________________________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(410, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 20)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Login Here!"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(178, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(249, 20)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "________________________________________"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.Book_Shop_Management_System.My.Resources.Resources.user_person_people_6100
        Me.PictureBox3.Location = New System.Drawing.Point(240, 145)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 22
        Me.PictureBox3.TabStop = False
        '
        'pbvisible
        '
        Me.pbvisible.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbvisible.Image = Global.Book_Shop_Management_System.My.Resources.Resources.eye_visible_hide_hidden_show_icon_145988
        Me.pbvisible.Location = New System.Drawing.Point(432, 449)
        Me.pbvisible.Name = "pbvisible"
        Me.pbvisible.Size = New System.Drawing.Size(32, 32)
        Me.pbvisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbvisible.TabIndex = 20
        Me.pbvisible.TabStop = False
        '
        'pbocultar
        '
        Me.pbocultar.Image = Global.Book_Shop_Management_System.My.Resources.Resources.eye_slash_visible_hide_hidden_show_icon_145987
        Me.pbocultar.Location = New System.Drawing.Point(432, 449)
        Me.pbocultar.Name = "pbocultar"
        Me.pbocultar.Size = New System.Drawing.Size(32, 32)
        Me.pbocultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbocultar.TabIndex = 21
        Me.pbocultar.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Book_Shop_Management_System.My.Resources.Resources.minimazar
        Me.PictureBox2.Location = New System.Drawing.Point(475, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Book_Shop_Management_System.My.Resources.Resources.cerrar
        Me.PictureBox1.Location = New System.Drawing.Point(514, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'frm_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(566, 694)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.pbvisible)
        Me.Controls.Add(Me.pbocultar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btn_exit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_login)
        Me.Controls.Add(Me.txt_passwordlogin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_usernamelogin)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Login"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbvisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbocultar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_usernamelogin As TextBox
    Friend WithEvents txt_passwordlogin As TextBox
    Friend WithEvents btn_login As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_exit As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pbvisible As PictureBox
    Friend WithEvents pbocultar As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
