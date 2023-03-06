Imports MySql.Data.MySqlClient
Public Class Form2
    Dim kodesd
    Private Sub Form2(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil_data_siswa()
        nomor()
        munculnisn()
        tampil_data_absen()
        count.Text = DataGridView1.Rows.Count - 1
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_home.Click
        Btn_home.Visible = True
        Btn_Master.Visible = True
        Btn_Absensi.Visible = True
        Btn_Siswa.Visible = True

        If Label10.Text = "chandra" Then
            Panel_Siswa.Visible = False
            Panel_pengurus.Visible = False
            Panel_Absensi.Visible = False
            PanelHome.Visible = True
            pnl_manajer.Visible = False
            pnl_manajer_absen.Visible = False
        Else
            PanelHome.Visible = True
            pnl_manajer.Visible = False
            pnl_manajer_absen.Visible = False
            Panel_Siswa.Visible = False
            Panel_pengurus.Visible = False
            Panel_Absensi.Visible = False

        End If
    End Sub
    Private Sub Btn_Absensi_Click(sender As Object, e As EventArgs) Handles Btn_Master.Click
        Btn_home.Visible = True
        Btn_Master.Visible = True
        Btn_Absensi.Visible = True
        Btn_Siswa.Visible = True

        If Label10.Text = "chandra" Then
            Panel_Siswa.Visible = False
            Panel_pengurus.Visible = False
            Panel_Absensi.Visible = True
            PanelHome.Visible = False
            pnl_manajer.Visible = False
            pnl_manajer_absen.Visible = False
        Else
            PanelHome.Visible = False
            pnl_manajer.Visible = True
            pnl_manajer_absen.Visible = False
            Panel_Siswa.Visible = False
            Panel_pengurus.Visible = False
            Panel_Absensi.Visible = False

            tampil_data_siswa_manajer()
        End If

        tampil_data_siswa()
    End Sub
    Private Sub Btn_Pengurus_Click(sender As Object, e As EventArgs) Handles Btn_Absensi.Click
        Btn_home.Visible = True
        Btn_Master.Visible = True
        Btn_Absensi.Visible = True
        Btn_Siswa.Visible = True


        If Label10.Text = "chandra" Then
            Panel_pengurus.Visible = True
            Panel_Absensi.Visible = False
            PanelHome.Visible = False
            Panel_Siswa.Visible = False

            pnl_manajer.Visible = False
            pnl_manajer_absen.Visible = False
        Else
            PanelHome.Visible = False
            pnl_manajer.Visible = False
            pnl_manajer_absen.Visible = True
            Panel_pengurus.Visible = False
            Panel_Absensi.Visible = False

            Panel_Siswa.Visible = False
            tampil_data_absen_manajer()
        End If
        munculnisn()
        tampil_data_absen()
    End Sub
    Private Sub Btn_Siswa_Click(sender As Object, e As EventArgs) Handles Btn_Siswa.Click
        Btn_home.Visible = True
        Btn_Master.Visible = True
        Btn_Absensi.Visible = True
        Btn_Siswa.Visible = True
        Panel_Siswa.Show()
        Panel_pengurus.Hide()
        Panel_Absensi.Hide()
        PanelHome.Hide()
    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()

        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.ComboBox1.Text = "" Then
            MsgBox(" Silahkan Isi Data dengan lengkap")
        Else

            Dim simpan As String
            MsgBox("Data Berhasil Di Simpan")
            simpan = "insert into tbl_master (No,NISN,Nama_Siswa,Nama_Sekolah,Jenis_Kelamin) values('" &
           Me.TextBox6.Text & "','" & Me.TextBox1.Text & "','" & Me.TextBox2.Text & "','" & Me.TextBox3.Text & "','" & Me.ComboBox1.Text & "')"
            cmd = New MySqlCommand(simpan, con) ' untuk menghubungkan ke database dan table lalu simpan
            cmd.ExecuteNonQuery() ' mengeksekusi datanya
            tampil_data_siswa()
            nomor()

        End If
    End Sub


    Sub tampil_data_siswa()
        Call koneksi()
        '------- Untuk menampilkan data di datagrid -----------
        da = New MySqlDataAdapter("select * from tbl_master order by NISN", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_master")
        Me.DataGridView1.DataSource = (ds.Tables("tbl_master"))
        '-------------- diatas codingnya ---------------
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di update")
        Else

            ' ------- Coding update data --------
            MsgBox(" Data Di Update")
            Dim edit As String
            edit = "update tbl_master set No ='" _
            & Me.TextBox6.Text & "' , Nama_Siswa = '" _
            & Me.TextBox2.Text & "',Nama_Sekolah ='" _
            & Me.TextBox3.Text & "',Jenis_Kelamin ='" _
            & Me.ComboBox1.Text & "',NISN ='" _
            & Me.TextBox1.Text & "'where No = '" & Me.TextBox6.Text & "'"
            cmd = New MySqlCommand(edit, con) ' untuk menghubungkan ke database dan table lalu Update
            cmd.ExecuteNonQuery() ' mengeksekusi datanya
            tampil_data_siswa()
            nomor()
        End If
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        On Error Resume Next
        ' fungsi untuk menclik data yang akan dipilih
        kodesd = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox6.Text = kodesd
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        Me.Button1.Enabled = True
        Me.Button2.Enabled = True
        Me.Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.TextBox1.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di hapus")

        Else
            ' ------- Coding update data --------
            If MessageBox.Show(" Apakah Anda Yakin Menghapus Data ini ?", "",
           MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String
                hapus = "delete from tbl_master where No = '" & Me.TextBox6.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                tampil_data_siswa()
                nomor()
            Else
            End If
        End If
    End Sub

    Sub nomor()
        Call koneksi()
        Dim DR As DataRow
        Dim s As String
        'mengambil kode dari field ID, kemudian dicari nilai yg paling besar (max)
        'kemudian hasilnya d tampung d field buatan dgn nama Nomor
        DR = SQLTable("select max(right(No,1)) as nomor from tbl_master").Rows(0)
        'jika berisi null atau tdk ditemukan
        If DR.IsNull("Nomor") Then
            s = "1" 'member nilai awal
        Else
            s = "" & Format(DR("Nomor") + 1, "0")
        End If
        TextBox6.Text = s
        TextBox6.Enabled = False
    End Sub


    Sub munculnisn()
        Call koneksi()
        ComboBox2.Items.Clear()
        cmd = New MySqlCommand("Select * from tbl_master", con)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox2.Items.Add(rd.Item(2))
        Loop
    End Sub

    Private Sub ComboBox2_Click(sender As Object, e As EventArgs) Handles ComboBox2.Click

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call koneksi()
        cmd = New MySqlCommand("Select * from tbl_master where Nama_Siswa='" & ComboBox2.Text & "'", con)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            TextBox5.Text = rd!NISN
            TextBox4.Text = rd!Nama_Sekolah
            TextBox7.Text = rd!Jenis_Kelamin

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Call koneksi()
        Dim tglsaya As String

        Dim jammasuk As DateTime = DateTime.Now
        Dim jamterlambat As DateTime = DateTime.Parse("08:00 AM")

        tglsaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")


        If Me.TextBox7.Text = "" Or Me.TextBox5.Text = "" Or Me.TextBox4.Text = "" Or Me.ComboBox3.Text = "" Then
            MsgBox(" Silahkan Isi Data dengan lengkap")
        ElseIf (jammasuk <= jamterlambat) Then
            MsgBox("Anda Tepat Waktu")
        Else
            MsgBox("Anda Terlambat")

        End If
        Dim simpan As String
        MsgBox("Data Berhasil Di Simpan")
        simpan = "insert into tbl_absensi values('" & tglsaya & "','" & Me.TextBox5.Text & "','" &
       Me.ComboBox2.Text & "','" & Me.TextBox4.Text & "','" & Me.TextBox7.Text & "','" & Me.ComboBox3.Text & "','" & Me.Label28.Text & "','" & Me.Label29.Text & "')"
        cmd = New MySqlCommand(simpan, con) ' untuk menghubungkan ke database dan table lalu simpan
        cmd.ExecuteNonQuery() ' mengeksekusi datanya
        nomor()
        tampil_data_absen()
    End Sub

    Sub tampil_data_absen()
        Call koneksi()
        '------- Untuk menampilkan data di datagrid -----------
        da = New MySqlDataAdapter("select * from tbl_absensi", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_absensi")
        Me.DataGridView2.DataSource = (ds.Tables("tbl_absensi"))
        '-------------- diatas codingnya ---------------
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call koneksi()
        Dim tglsaya As String
        tglsaya = Format(DateTimePicker1.Value, "yyyy-MM-dd")

        If Me.TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di update")
        Else

            ' ------- Coding update data --------
            MsgBox(" Data Di Update")
            Dim edit As String
            edit = "update tbl_absensi set Tanggal ='" _
            & DateTimePicker1.Value & "' , Nisn = '" _
            & Me.ComboBox2.Text & "',Nama_Siswa ='" _
            & Me.TextBox5.Text & "',Nama_Sekolah ='" _
            & Me.TextBox4.Text & "',Jenis_Kelamin ='" _
            & Me.TextBox7.Text & "',Keterangan = '" & Me.ComboBox3.Text & "'where Nisn = '" & Me.ComboBox2.Text & "'"
            cmd = New MySqlCommand(edit, con) ' untuk menghubungkan ke database dan table lalu Update
            cmd.ExecuteNonQuery() ' mengeksekusi datanya
            tampil_data_absen()
            nomor()
        End If
    End Sub

    Private Sub Panel_pengurus_Paint(sender As Object, e As PaintEventArgs) Handles Panel_pengurus.Paint

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        On Error Resume Next
        ' fungsi untuk menclik data yang akan dipilih
        kodesd = DataGridView2.Rows(e.RowIndex).Cells(0).Value
        DateTimePicker1.Text = kodesd
        ComboBox2.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value
        TextBox5.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value
        TextBox7.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value
        ComboBox3.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value
        Me.Button8.Enabled = False
        Me.Button7.Enabled = True
        Me.Button6.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call koneksi()

        If Me.ComboBox2.Text = "" Then
            MsgBox(" Maaf datanya tidak ada yang di hapus")

        Else
            ' ------- Coding update data --------
            If MessageBox.Show(" Apakah Anda Yakin Menghapus Data ini ?", "",
           MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String
                hapus = "delete from tbl_absensi where Nisn = '" & Me.ComboBox2.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                tampil_data_siswa()
                nomor()
                tampil_data_absen()
            Else
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        refresh_absen()
    End Sub

    Sub refresh_absen()
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""

    End Sub
    Sub refresh_master()
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        refresh_master()
    End Sub

    Sub tampil_data_siswa_manajer()
        Call koneksi()
        '------- Untuk menampilkan data di datagrid -----------
        da = New MySqlDataAdapter("select * from tbl_master order by NISN", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_master")
        Me.DataGridView3.DataSource = (ds.Tables("tbl_master"))
        '-------------- diatas codingnya ---------------
    End Sub

    Sub tampil_data_absen_manajer()
        Call koneksi()
        '------- Untuk menampilkan data di datagrid -----------
        da = New MySqlDataAdapter("select * from tbl_absensi", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tbl_absensi")
        Me.DataGridView4.DataSource = (ds.Tables("tbl_absensi"))
        '-------------- diatas codingnya ---------------
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        AxCrystalReport1.ReportFileName = "report1.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1


    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'AxCrystalReport1.ReportFileName = "report2.rpt"
        'AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        'AxCrystalReport1.RetrieveDataFiles()
        'AxCrystalReport1.Action = 1

        AxCrystalReport3.SelectionFormula = "{tbl_absensi.Tanggal} in date ('" & DTP1.Value & "') to date ('" & DTP2.Value & "')"
        AxCrystalReport3.ReportFileName = "laporan2.rpt"
        AxCrystalReport3.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport3.RetrieveDataFiles()
        AxCrystalReport3.Action = 1
    End Sub

    Private Sub AxCrystalReport1_Enter(sender As Object, e As EventArgs) Handles AxCrystalReport1.Enter

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        AxCrystalReport3.SelectionFormula = "totext({tbl_absensi.Nisn})='" & nisn.Text & "'"
        AxCrystalReport3.ReportFileName = "report4.rpt"
        AxCrystalReport3.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport3.RetrieveDataFiles()
        AxCrystalReport3.Action = 1
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Call koneksi()
        da = New MySqlDataAdapter("select * from tbl_absensi where Nama_Siswa like '%" _
 & Me.TextBox8.Text & "%'", con)
        ds = New DataSet
        ' ds.Clear()
        da.Fill(ds, "tbl_absensi")
        DataGridView2.DataSource = (ds.Tables("tbl_absensi"))
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        Call koneksi()
        da = New MySqlDataAdapter("select * from tbl_absensi where Nama_Siswa like '%" _
 & Me.TextBox9.Text & "%'", con)
        ds = New DataSet
        ' ds.Clear()
        da.Fill(ds, "tbl_absensi")
        DataGridView3.DataSource = (ds.Tables("tbl_absensi"))
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Call koneksi()
        da = New MySqlDataAdapter("select * from tbl_absensi where Nama_Siswa like '%" _
 & Me.TextBox10.Text & "%'", con)
        ds = New DataSet
        ' ds.Clear()
        da.Fill(ds, "tbl_absensi")
        DataGridView4.DataSource = (ds.Tables("tbl_absensi"))
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label28.Text = TimeOfDay
        Label29.Text = TimeOfDay
    End Sub
End Class