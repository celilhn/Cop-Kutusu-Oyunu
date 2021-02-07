
using G181210019;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G181210019
{
    class Atik : IAtik
    {
        public int size; // Değişkenler oluşturuldu
        public int id;
        public Image image;
        public string name;
        public string type;

        public int Hacim
        {
            get
            {
                return size;
            }
        }

        public Image Image
        {
            get
            {
                return this.image;
            }
        }
    }
}
