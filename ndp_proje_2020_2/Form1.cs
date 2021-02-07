
using G181210019;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G181210019
{
    public partial class Form1 : Form
    {
        int counter = 60; // Değişkenler oluşturuldu
        int random ;
        int tempValue = 0;
        int point = 0;
        
        Random rastgele = new Random(); // Rastgele

        AtikKutusu organicWasteBox = new AtikKutusu(); // Atık kutusundan nesneler oluşturuldu
        AtikKutusu paperBox = new AtikKutusu();
        AtikKutusu glassBin = new AtikKutusu();
        AtikKutusu metalBox = new AtikKutusu();

        List<Atik> wastes = new List<Atik> // Atık özellikleri girildi
        {
            new Atik { id = 1, size = 600,name = "Cam Şise", image = Image.FromFile("glassBottle.jpg") },
            new Atik { id = 2, size = 250,name = "Bardak", image = Image.FromFile("glass.jpg") },
            new Atik { id = 3, size = 250,name = "Gazete", image = Image.FromFile("newsPaper.jpg") },
            new Atik { id = 4, size = 200,name = "Dergi", image = Image.FromFile("magazine.jpg") },
            new Atik { id = 5, size = 150,name = "Domates", image = Image.FromFile("tomato.jpg") },
            new Atik { id = 6, size = 120,name = "Salatalık", image = Image.FromFile("cucumber.jpg") },
            new Atik { id = 7, size = 350,name = "Kola Kutusu", image = Image.FromFile("colaCan.jpeg") },
            new Atik { id = 8, size = 550,name = "Salça kutusu", image = Image.FromFile("tomatoPasteBox.jpg") }
        };
         
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            organicWasteBox.capacity = 700; // Kapasiteler
            paperBox.capacity = 1200;
            glassBin.capacity = 2200;
            metalBox.capacity = 2300;

            timer1.Interval = 1000; // Saniye

            lblPoint.Text = point.ToString(); // Puan

        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (lblTime.Text == "60") // 60 ise başlat
            {
                random = rastgele.Next(8);
                pictureBox.Image = wastes[random].Image; // Rastgele fotoğraf
                timer1.Start(); // zamanlama başlatıldı
            }
                
            if (lblTime.Text == "0") // Yenidenn başlatılıyorsa değerler sıfırlanır
            {
                counter = 60;
                organicWasteBox.Bosalt();
                paperBox.Bosalt();
                glassBin.Bosalt();
                metalBox.Bosalt();

                listBoxOrganic.Items.Clear();
                listBoxMetal.Items.Clear();
                listBoxPaper.Items.Clear();
                listBoxPipe.Items.Clear();

                progressBarPaper.Value = 0;
                progressBar_Metal.Value = 0;
                progressBar_Organic.Value = 0;
                progressBar_Piper.Value = 0;

                point = 0;
            }
                
        }

        private void button_Exit_Click(object sender, EventArgs e) // Çıkış
        {
            Application.Exit();
        }

        private void button_Organic_Click(object sender, EventArgs e) // Organik
        {
            if(counter>0 && counter<60)  // Sayac 0-60arasındaysa girer
            {
                if (wastes[random].id == 5 || wastes[random].id == 6) // id değeri uygunsa içeri girdi
                {
                    if (progressBar_Organic.Value >= 0 && progressBar_Organic.Value < 100) // progressbar değeri 0-100 arasındaysa içeri girdi
                    {
                        organicWasteBox.Ekle(wastes[random]); // Yüzde hesaplar ve kapasiteye ekleme yapıldı
                        listBoxOrganic.Items.Add(wastes[random].name + "-" + wastes[random].Hacim); // Eklenilen atık ve hacmi listboxa eklendi
                        tempValue = organicWasteBox.DolulukOrani / organicWasteBox.Kapasite; // Program bölmede hata verdiği için doluluk oranı burada hesaplanıyor
                        if (tempValue >= 0 && tempValue < 101)
                            progressBar_Organic.Value = (tempValue); // Progressbara doluluk değeri girildi
                        else
                            progressBar_Organic.Value = 100; // progressbar değeri 100 den büyükse 100'e eşitlendi
                    }

                    random = rastgele.Next(8);
                    pictureBox.Image = wastes[random].Image;
                }
            }
        }

        private void button_Paper_Click(object sender, EventArgs e) // Kağıt
        {
            if (counter > 0 && counter < 60)
            {
                if (wastes[random].id == 3 || wastes[random].id == 4)
                {
                    if (progressBarPaper.Value >= 0 && progressBarPaper.Value < 100)
                    {
                        paperBox.Ekle(wastes[random]);
                        listBoxPaper.Items.Add(wastes[random].name + "-" + wastes[random].Hacim);
                        tempValue = paperBox.DolulukOrani / paperBox.Kapasite;
                        if (tempValue >= 0 && tempValue < 101)
                            progressBarPaper.Value = (tempValue);
                        else
                            progressBarPaper.Value = 100;
                    }

                    random = rastgele.Next(8);
                    pictureBox.Image = wastes[random].Image;
                }
            }
        }

        private void button_Pipe_Click(object sender, EventArgs e) // Cam
        {
            if (counter > 0 && counter < 60)
            {
                if (wastes[random].id == 1 || wastes[random].id == 2)
                {
                    if (progressBar_Piper.Value >= 0 && progressBar_Piper.Value < 100)
                    {
                        glassBin.Ekle(wastes[random]);
                        listBoxPipe.Items.Add(wastes[random].name + "-" + wastes[random].Hacim);
                        tempValue = glassBin.DolulukOrani / glassBin.Kapasite;
                        if (tempValue >= 0 && tempValue < 101)
                            progressBar_Piper.Value = (tempValue);
                        else
                            progressBar_Piper.Value = 100;
                    }

                    random = rastgele.Next(8);
                    pictureBox.Image = wastes[random].Image;
                }
            }
        }

        private void button_Metal_Click(object sender, EventArgs e) // Metal
        {
            if (counter > 0 && counter < 60)
            {
                if (wastes[random].id == 7 || wastes[random].id == 8)
                {
                    if (progressBar_Metal.Value >= 0 && progressBar_Metal.Value < 100)
                    {
                        metalBox.Ekle(wastes[random]);
                        listBoxMetal.Items.Add(wastes[random].name + "-" + wastes[random].Hacim);
                        tempValue = metalBox.DolulukOrani / metalBox.Kapasite;
                        if (tempValue >= 0 && tempValue < 101)
                            progressBar_Metal.Value = (tempValue);
                        else
                            progressBar_Metal.Value = 100;
                    }

                    random = rastgele.Next(8);
                    pictureBox.Image = wastes[random].Image;
                }
            }
        }

        private void button_Empty_Organic_Click(object sender, EventArgs e) // Organik boşaltma
        {
            if (counter > 0 && counter < 60) // Sayac 0-60arasındaysa girer
            {
                if (progressBar_Organic.Value > 75) // Doluluk oranı %75 den büyükse girdi
                {
                    organicWasteBox.Bosalt(); // Hacimi ve doluluk oranını sıfırladı
                    listBoxOrganic.Items.Clear(); // Listboxı boşalttı
                    counter = counter + 3; // ^saniye daha ekledi
                    lblPoint.Text = point.ToString(); // Puan labele yazdırıldı
                    progressBar_Organic.Value = 0; // Progressbar sıfırlandı
                }
            }
           
        }

        private void button_Empty_Paper_Click(object sender, EventArgs e) // Kağıt Boşaltma
        {
            if (counter > 0 && counter < 60)
            {
                if (progressBarPaper.Value > 75)
                {
                    paperBox.Bosalt();
                    listBoxPaper.Items.Clear();
                    counter = counter + 3;
                    point += 1000;
                    lblPoint.Text = point.ToString();
                    progressBarPaper.Value = 0;
                }
            }
            
        }

        private void button_Empty_Pine_Click(object sender, EventArgs e) // Cam Boşaltma
        {
            if (counter > 0 && counter < 60)
            {
                if (progressBar_Piper.Value > 75)
                {
                    glassBin.Bosalt();
                    listBoxPipe.Items.Clear();
                    counter = counter + 3;
                    point += 600;
                    lblPoint.Text = point.ToString();
                    progressBar_Piper.Value = 0;
                }
            }
           
        }

        private void button_Empty_Metal_Click(object sender, EventArgs e) // Metal Boşaltma
        {
            if (counter > 0 && counter < 60)
            {
                if (progressBar_Metal.Value > 75)
                {
                    metalBox.Bosalt();
                    listBoxMetal.Items.Clear();
                    counter = counter + 3;
                    point += 800;
                    lblPoint.Text = point.ToString();
                    progressBar_Metal.Value = 0;
                }
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e) // Zamanlama
        {
            if(counter>0)
            {
                counter--; // Geri sayım
                lblTime.Text = counter.ToString();
            }
        }
    }
}
