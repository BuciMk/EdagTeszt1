using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace EdagTeszt1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listView.ItemsSource = null;
            FolderBrowserDialog mappaDialog = new FolderBrowserDialog();

            if (mappaDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                eleresiCimBox.Text = mappaDialog.SelectedPath;
                listView.Items.Clear();
                //var fajlok = Directory.GetFiles(mappaDialog.SelectedPath);
                var mappak = Directory.GetDirectories(mappaDialog.SelectedPath);
                List<File> file = new List<File>();
                listView.ItemsSource = file;
                DirectoryInfo di = new DirectoryInfo(mappaDialog.SelectedPath);
                FileInfo[] info = di.GetFiles();

                foreach (var dir in mappak)
                {
                    file.Add(new File() { Nev = dir.Remove(0, dir.LastIndexOf('\\')), Kiterjesztes = "Mappa", MshSzama = "" });
                }

                foreach (var inf in info)
                {
                    file.Add(new File() { Nev = inf.Name.Remove(inf.Name.LastIndexOf('.')), Kiterjesztes = inf.Extension, Meret = inf.Length / 1024 + " KB", MshSzama = MassalhangzoSzamolas(inf.Name) });
                }

            }
        }

        private string MassalhangzoSzamolas(string nev)
        {
            char[] massalhangzokListaja = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
            int mshMennyi = 0;
            nev = nev.ToUpper();

            foreach (var ch in nev)
            {
                if (massalhangzokListaja.Contains(ch))
                {
                    mshMennyi++;
                }
            }

            return mshMennyi.ToString();
        }


    }
}
