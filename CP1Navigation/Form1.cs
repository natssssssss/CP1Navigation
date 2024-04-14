using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CP1Navigation
{
    public partial class Form1 : Form
    {
        private bool menuExpand = false;
        private bool submenusExpanded = false;
        private int menuContainerDefaultHeight;
        bool sidebarExpand = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 135)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 52)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
        }

        private void menu_Click(object sender, EventArgs e)
        {
            foreach (Control control in menuContainer.Controls)
            {
                if (control is Button && control.Top > menu.Bottom)
                {
                    control.Visible = !submenusExpanded;
                }
            }

            submenusExpanded = !submenusExpanded;

            if (submenusExpanded)
            {
                menuContainer.Height += 25; 
            }
            else
            {
                menuContainer.Height = menuContainerDefaultHeight;
            }

            menuTransition.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuContainerDefaultHeight = menuContainer.Height;
        }
        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 36)
                { 
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 230)
                {
                    sidebar.Width = 230;
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }
    }
}
