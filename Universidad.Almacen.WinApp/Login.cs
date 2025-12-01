using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Services;
using Universidad.Almacen.Entidad.Entities;
using System.Windows.Forms;

namespace Universidad.Almacen.WinApp
{
    public partial class Login : MaterialForm
    {
        private readonly UsuarioRolService _usuarioRolService;
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txt_usuario.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }
        private static byte[] ComputeHash(string password)
        {
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txt_usuario.Text.Trim();
                string clave = txt_pass.Text;
                
                if (string.IsNullOrWhiteSpace(username))
                {
                    MessageBox.Show("Ingrese su usuario.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_usuario.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(clave))
                {
                    MessageBox.Show("Ingrese su clave.", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_pass.Focus();
                    return;
                }
                var hassPass = ComputeHash(clave);
                var result = _usuarioRolService.ValidarUsuario(username, hassPass);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
