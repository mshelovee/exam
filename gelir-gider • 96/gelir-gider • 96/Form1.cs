using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gelir_gider___96
{
    public partial class Form1 : Form
    {
        BindingList<Islem> islemler = new BindingList<Islem>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Islem islem1 = new Islem(1, "Maaş", new DateTime(2023, 11, 05), "Eylül Maaş", "32.000", true);
            Islem islem2 = new Islem(2, "Fatura", new DateTime(2023, 09, 05), "Elektrik", "700", false);
            Islem islem3 = new Islem(3, "Ek Gelir", new DateTime(2023, 09, 05), "Mesai", "3.000", true);
            Islem islem4 = new Islem(4, "Market", new DateTime(2023, 08, 05), "Ek Gider", "900", false);
            Islem islem5 = new Islem(5, "Ek Gider", new DateTime(2023, 08, 05), "Hastane", "600", false);

            islemler.Add(islem1);
            islemler.Add(islem2);
            islemler.Add(islem3);
            islemler.Add(islem4);
            islemler.Add(islem5);

            dataGridViewIslem.DataSource = islemler; //islemler listesini datagrid içine ekler
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string tanim = txtTanim.Text;
            DateTime tarih = DateTime.Now;
            string tur = cmbTur.Text;
            string miktar = numMiktar.Value.ToString();
            bool gelir = cbGelir.Checked;
            Islem islem = new Islem(id, tanim, tarih, tur, miktar, gelir);

            islemler.Add(islem);

            txtId.Clear();    //txtId.Text = "";
            txtTanim.Clear();
            cbGelir.Checked = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewIslem.SelectedRows.Count > 0)
            {
                Islem islem = (Islem)dataGridViewIslem.SelectedRows[0].DataBoundItem;

                islem.Tanim = txtTanim.Text;
                islem.Tarih = dtTarih.Value;
                islem.Tur = cmbTur.Text;
                islem.Miktar = numMiktar.Value.ToString();
                islem.Gelir = cbGelir.Checked;

                dataGridViewIslem.Refresh();  //datagridview yeniden yüklenir.
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Islem islem = (Islem)dataGridViewIslem.SelectedRows[0].DataBoundItem;

            if (dataGridViewIslem.SelectedRows.Count > 0)
            {
                DialogResult sonuc = MessageBox.Show(islem.Tanim + " Silinsin mi?", "İşlem Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if(sonuc == DialogResult.Yes)
                {
                    islemler.Remove(islem);
                }
            }
        }

        private void dataGridViewIslem_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewIslem.SelectedRows.Count > 0)
            {
                //DataGridView üzerindeki seçili satırı Islem türünde alır.
                //Islem türüne dönüştürmek için (Islem) dönüşümü yapılır.

                Islem islem = (Islem)dataGridViewIslem.SelectedRows[0].DataBoundItem;

                txtId.Text = islem.Id.ToString();
                txtTanim.Text = islem.Tanim.ToString();
                dtTarih.Value = islem.Tarih;
                cmbTur.Text = islem.Tur;
                cbGelir.Checked = islem.Gelir;
                
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
