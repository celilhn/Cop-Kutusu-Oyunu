
using G181210019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G181210019
{
    class AtikKutusu : IAtikKutusu
    {
        public int capacity, fullVolume, solidityRatio=0, dischargeScore;  // Değişkenler oluşturuldu
        public int Kapasite
        {
            get
            {
                return capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public int DoluHacim
        {
            get
            {
                return this.fullVolume;
            }
        }

        public int DolulukOrani
        {
            get
            {
                return this.solidityRatio;
            }
        }

        public int BosaltmaPuani
        {
            get
            {
                return this.dischargeScore;
            }
        }

        public bool Ekle(Atik atik) // Atık eklenecek 
        {
            this.fullVolume = atik.Hacim + this.fullVolume; // Kapasiteye ekleme yapar
            this.solidityRatio = 100 * this.fullVolume; // Yeni yüzdeyi hesaplar

            return true;
        }

        public bool Bosalt() // Atık boşaltıldı, değerler sıfırlandı
        {
            this.fullVolume = 0;
            this.solidityRatio = 0;
            return true;
        }

    }
}
