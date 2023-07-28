<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioModificar
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
        Me.gboxDatosDelAlumnos = New System.Windows.Forms.GroupBox()
        Me.flpDatosDelAlumno = New System.Windows.Forms.FlowLayoutPanel()
        Me.labNombre = New System.Windows.Forms.Label()
        Me.tbNombre = New System.Windows.Forms.TextBox()
        Me.labApellido = New System.Windows.Forms.Label()
        Me.tbApellido = New System.Windows.Forms.TextBox()
        Me.labDNI = New System.Windows.Forms.Label()
        Me.tbDNI = New System.Windows.Forms.TextBox()
        Me.labDireccion = New System.Windows.Forms.Label()
        Me.tbDireccion = New System.Windows.Forms.TextBox()
        Me.labTelefono = New System.Windows.Forms.Label()
        Me.tbTelefono = New System.Windows.Forms.TextBox()
        Me.labLocalidad = New System.Windows.Forms.Label()
        Me.cbLocalidad = New System.Windows.Forms.ComboBox()
        Me.labFoto = New System.Windows.Forms.Label()
        Me.panelFoto = New System.Windows.Forms.Panel()
        Me.btnFoto = New System.Windows.Forms.Button()
        Me.tbFoto = New System.Windows.Forms.TextBox()
        Me.labEmail = New System.Windows.Forms.Label()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.panelBotones = New System.Windows.Forms.Panel()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gboxDatosDelAlumnos.SuspendLayout()
        Me.flpDatosDelAlumno.SuspendLayout()
        Me.panelFoto.SuspendLayout()
        Me.panelBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboxDatosDelAlumnos
        '
        Me.gboxDatosDelAlumnos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboxDatosDelAlumnos.Controls.Add(Me.flpDatosDelAlumno)
        Me.gboxDatosDelAlumnos.Location = New System.Drawing.Point(12, 12)
        Me.gboxDatosDelAlumnos.Name = "gboxDatosDelAlumnos"
        Me.gboxDatosDelAlumnos.Size = New System.Drawing.Size(518, 217)
        Me.gboxDatosDelAlumnos.TabIndex = 2
        Me.gboxDatosDelAlumnos.TabStop = False
        Me.gboxDatosDelAlumnos.Text = "Datos Del Alumno"
        '
        'flpDatosDelAlumno
        '
        Me.flpDatosDelAlumno.Controls.Add(Me.labNombre)
        Me.flpDatosDelAlumno.Controls.Add(Me.tbNombre)
        Me.flpDatosDelAlumno.Controls.Add(Me.labApellido)
        Me.flpDatosDelAlumno.Controls.Add(Me.tbApellido)
        Me.flpDatosDelAlumno.Controls.Add(Me.labDNI)
        Me.flpDatosDelAlumno.Controls.Add(Me.tbDNI)
        Me.flpDatosDelAlumno.Controls.Add(Me.labDireccion)
        Me.flpDatosDelAlumno.Controls.Add(Me.tbDireccion)
        Me.flpDatosDelAlumno.Controls.Add(Me.labTelefono)
        Me.flpDatosDelAlumno.Controls.Add(Me.tbTelefono)
        Me.flpDatosDelAlumno.Controls.Add(Me.labLocalidad)
        Me.flpDatosDelAlumno.Controls.Add(Me.cbLocalidad)
        Me.flpDatosDelAlumno.Controls.Add(Me.labFoto)
        Me.flpDatosDelAlumno.Controls.Add(Me.panelFoto)
        Me.flpDatosDelAlumno.Controls.Add(Me.labEmail)
        Me.flpDatosDelAlumno.Controls.Add(Me.tbEmail)
        Me.flpDatosDelAlumno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpDatosDelAlumno.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpDatosDelAlumno.Location = New System.Drawing.Point(3, 16)
        Me.flpDatosDelAlumno.Name = "flpDatosDelAlumno"
        Me.flpDatosDelAlumno.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.flpDatosDelAlumno.Size = New System.Drawing.Size(512, 198)
        Me.flpDatosDelAlumno.TabIndex = 0
        '
        'labNombre
        '
        Me.labNombre.AutoSize = True
        Me.labNombre.Location = New System.Drawing.Point(13, 0)
        Me.labNombre.Name = "labNombre"
        Me.labNombre.Size = New System.Drawing.Size(44, 13)
        Me.labNombre.TabIndex = 0
        Me.labNombre.Text = "Nombre"
        '
        'tbNombre
        '
        Me.tbNombre.Location = New System.Drawing.Point(13, 16)
        Me.tbNombre.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tbNombre.MaxLength = 45
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.Size = New System.Drawing.Size(231, 20)
        Me.tbNombre.TabIndex = 1
        '
        'labApellido
        '
        Me.labApellido.AutoSize = True
        Me.labApellido.Location = New System.Drawing.Point(13, 39)
        Me.labApellido.Name = "labApellido"
        Me.labApellido.Size = New System.Drawing.Size(44, 13)
        Me.labApellido.TabIndex = 2
        Me.labApellido.Text = "Apellido"
        '
        'tbApellido
        '
        Me.tbApellido.Location = New System.Drawing.Point(13, 55)
        Me.tbApellido.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tbApellido.MaxLength = 45
        Me.tbApellido.Name = "tbApellido"
        Me.tbApellido.Size = New System.Drawing.Size(231, 20)
        Me.tbApellido.TabIndex = 3
        '
        'labDNI
        '
        Me.labDNI.AutoSize = True
        Me.labDNI.Location = New System.Drawing.Point(13, 78)
        Me.labDNI.Name = "labDNI"
        Me.labDNI.Size = New System.Drawing.Size(26, 13)
        Me.labDNI.TabIndex = 4
        Me.labDNI.Text = "DNI"
        '
        'tbDNI
        '
        Me.tbDNI.Location = New System.Drawing.Point(13, 94)
        Me.tbDNI.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tbDNI.MaxLength = 8
        Me.tbDNI.Name = "tbDNI"
        Me.tbDNI.Size = New System.Drawing.Size(231, 20)
        Me.tbDNI.TabIndex = 5
        '
        'labDireccion
        '
        Me.labDireccion.AutoSize = True
        Me.labDireccion.Location = New System.Drawing.Point(13, 117)
        Me.labDireccion.Name = "labDireccion"
        Me.labDireccion.Size = New System.Drawing.Size(52, 13)
        Me.labDireccion.TabIndex = 6
        Me.labDireccion.Text = "Dirección"
        '
        'tbDireccion
        '
        Me.tbDireccion.Location = New System.Drawing.Point(13, 133)
        Me.tbDireccion.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tbDireccion.MaxLength = 45
        Me.tbDireccion.Name = "tbDireccion"
        Me.tbDireccion.Size = New System.Drawing.Size(231, 20)
        Me.tbDireccion.TabIndex = 7
        '
        'labTelefono
        '
        Me.labTelefono.AutoSize = True
        Me.labTelefono.Location = New System.Drawing.Point(13, 156)
        Me.labTelefono.Name = "labTelefono"
        Me.labTelefono.Size = New System.Drawing.Size(49, 13)
        Me.labTelefono.TabIndex = 8
        Me.labTelefono.Text = "Telefono"
        '
        'tbTelefono
        '
        Me.tbTelefono.Location = New System.Drawing.Point(13, 172)
        Me.tbTelefono.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.tbTelefono.MaxLength = 10
        Me.tbTelefono.Name = "tbTelefono"
        Me.tbTelefono.Size = New System.Drawing.Size(231, 20)
        Me.tbTelefono.TabIndex = 9
        '
        'labLocalidad
        '
        Me.labLocalidad.AutoSize = True
        Me.labLocalidad.Location = New System.Drawing.Point(267, 0)
        Me.labLocalidad.Name = "labLocalidad"
        Me.labLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.labLocalidad.TabIndex = 10
        Me.labLocalidad.Text = "Localidad"
        '
        'cbLocalidad
        '
        Me.cbLocalidad.FormattingEnabled = True
        Me.cbLocalidad.Items.AddRange(New Object() {"Posadas", "Candelaria", "Garupa"})
        Me.cbLocalidad.Location = New System.Drawing.Point(267, 16)
        Me.cbLocalidad.Name = "cbLocalidad"
        Me.cbLocalidad.Size = New System.Drawing.Size(231, 21)
        Me.cbLocalidad.TabIndex = 11
        '
        'labFoto
        '
        Me.labFoto.AutoSize = True
        Me.labFoto.Location = New System.Drawing.Point(267, 40)
        Me.labFoto.Name = "labFoto"
        Me.labFoto.Size = New System.Drawing.Size(28, 13)
        Me.labFoto.TabIndex = 12
        Me.labFoto.Text = "Foto"
        '
        'panelFoto
        '
        Me.panelFoto.Controls.Add(Me.btnFoto)
        Me.panelFoto.Controls.Add(Me.tbFoto)
        Me.panelFoto.Location = New System.Drawing.Point(267, 56)
        Me.panelFoto.Name = "panelFoto"
        Me.panelFoto.Size = New System.Drawing.Size(231, 21)
        Me.panelFoto.TabIndex = 13
        '
        'btnFoto
        '
        Me.btnFoto.Location = New System.Drawing.Point(205, 0)
        Me.btnFoto.Name = "btnFoto"
        Me.btnFoto.Size = New System.Drawing.Size(26, 21)
        Me.btnFoto.TabIndex = 11
        Me.btnFoto.Text = "..."
        Me.btnFoto.UseVisualStyleBackColor = True
        '
        'tbFoto
        '
        Me.tbFoto.Location = New System.Drawing.Point(0, 1)
        Me.tbFoto.MaxLength = 45
        Me.tbFoto.Name = "tbFoto"
        Me.tbFoto.ReadOnly = True
        Me.tbFoto.Size = New System.Drawing.Size(199, 20)
        Me.tbFoto.TabIndex = 10
        '
        'labEmail
        '
        Me.labEmail.AutoSize = True
        Me.labEmail.Location = New System.Drawing.Point(267, 80)
        Me.labEmail.Name = "labEmail"
        Me.labEmail.Size = New System.Drawing.Size(32, 13)
        Me.labEmail.TabIndex = 14
        Me.labEmail.Text = "Email"
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(267, 96)
        Me.tbEmail.MaxLength = 45
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(231, 20)
        Me.tbEmail.TabIndex = 15
        '
        'panelBotones
        '
        Me.panelBotones.Controls.Add(Me.btnModificar)
        Me.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelBotones.Location = New System.Drawing.Point(0, 235)
        Me.panelBotones.Name = "panelBotones"
        Me.panelBotones.Size = New System.Drawing.Size(542, 40)
        Me.panelBotones.TabIndex = 3
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(12, 5)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 0
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "Imagen"
        Me.OpenFileDialog1.Filter = "JPG|*.jpg|PNG|*.png|JPEG|*.jpeg"
        '
        'FormularioModificar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 275)
        Me.Controls.Add(Me.panelBotones)
        Me.Controls.Add(Me.gboxDatosDelAlumnos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormularioModificar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Alumnos"
        Me.gboxDatosDelAlumnos.ResumeLayout(False)
        Me.flpDatosDelAlumno.ResumeLayout(False)
        Me.flpDatosDelAlumno.PerformLayout()
        Me.panelFoto.ResumeLayout(False)
        Me.panelFoto.PerformLayout()
        Me.panelBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gboxDatosDelAlumnos As GroupBox
    Friend WithEvents flpDatosDelAlumno As FlowLayoutPanel
    Friend WithEvents labNombre As Label
    Friend WithEvents tbNombre As TextBox
    Friend WithEvents labApellido As Label
    Friend WithEvents tbApellido As TextBox
    Friend WithEvents labDNI As Label
    Friend WithEvents tbDNI As TextBox
    Friend WithEvents labDireccion As Label
    Friend WithEvents tbDireccion As TextBox
    Friend WithEvents labTelefono As Label
    Friend WithEvents tbTelefono As TextBox
    Friend WithEvents labLocalidad As Label
    Friend WithEvents cbLocalidad As ComboBox
    Friend WithEvents labFoto As Label
    Friend WithEvents panelFoto As Panel
    Friend WithEvents btnFoto As Button
    Friend WithEvents tbFoto As TextBox
    Friend WithEvents labEmail As Label
    Friend WithEvents tbEmail As TextBox
    Friend WithEvents panelBotones As Panel
    Friend WithEvents btnModificar As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
