using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Odev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static decimal total = 0;

        // standartToplama fonksiyonu normal toplama işlemi yapar.
        // Burada baslangic ve bitis parametreleri daha sonradan thread'ler arasında iş bölümü yapmamız için gerekli
        static decimal standartToplama(ulong baslangic, ulong bitis)
        {
            decimal toplam = 0;
            for (ulong i = baslangic; i <= bitis; i++)
            {
                toplam += i;
            }
            //Console.WriteLine("Toplam = {0}", toplam);
            total += toplam;
            return toplam;
        }

        // gaussToplamı fonksiyonu toplama işlemini Gauss Yöntemi ile yapar.
        static decimal gaussToplamı(decimal n)
        {
            decimal gaussToplamı = (n * (n + 1)) / 2;
            Console.WriteLine("Gauss toplamı = {0}", gaussToplamı);
            return gaussToplamı;
        }

        // threadCozumu fonksiyonu toplama işlemini 1-32 arası threadlere paylaştırarak yapar.
        void threadCozumu(ulong threadSayisi)
        {
            for (ulong i = 1; i <= threadSayisi; i++)
            {
                Thread[] threadDizi = new Thread[i];

                ulong parca = (Convert.ToUInt64(Math.Pow(10, 10))) / i; // Thread başına düşen toplanacak sayı adedi
                ulong mod = ((Convert.ToUInt64(Math.Pow(10, 10))) % i); // Thread'lere iş bölümü yaptığımızda kalan toplanacak sayı adedi

                Stopwatch stopwatch = new Stopwatch(); // Kodun çalıştığı süreyi bulmak için
                stopwatch.Start();

                Console.WriteLine("{0} adet thread için hesaplama başladı...", i);

                for (ulong j = 0; j < i; j++)
                {
                    if (mod == 0) // 10^10 sayısı thread'lere tam bölünebiliyorsa
                    {
                        ulong baslangic = (parca * j) + 1;
                        ulong bitis = parca * (j + 1);
                        threadDizi[j] = new Thread(() => standartToplama(baslangic, bitis));
                        threadDizi[j].Start();
                    }
                    else if (mod != 0) // 10^10 sayısı thread'lere tam bölünemiyorsa
                    {
                        ulong baslangic = (parca * j) + 1;
                        ulong bitis = parca * (j + 1);

                        if (i == (j + 1)) // Son thread'de isek kalan sayıları toplaması için son thread'e ver
                        {
                            threadDizi[j] = new Thread(() => standartToplama(baslangic, bitis + mod)); 
                            threadDizi[j].Start();
                        }
                        else // Son thread'de değilsek normal devam et
                        {
                            threadDizi[j] = new Thread(() => standartToplama(baslangic, bitis));
                            threadDizi[j].Start();
                        }

                    }

                }

                for (int k = 0; k < threadDizi.Length; k++) //
                {
                    while (threadDizi[k].IsAlive == true) ;

                }

                Console.WriteLine("Toplam: " + total);
                total = 0;
                stopwatch.Stop();
                Console.WriteLine("Geçen süre: {0}", stopwatch.Elapsed.TotalMilliseconds);

                chartPerformans.Series["Series1"].Points.Add(); // Grafik için gerekli verileri otomatik çekeceğiz
                chartPerformans.Series["Series1"].Points[Convert.ToInt32(i - 1)].XValue = i; // x değeri
                double[] yDegerleri = new double[1];
                yDegerleri[0] = stopwatch.Elapsed.TotalMilliseconds;
                chartPerformans.Series["Series1"].Points[Convert.ToInt32(i - 1)].YValues = yDegerleri; // y değeri
                chartPerformans.Series["Series1"].Points[Convert.ToInt32(i - 1)].MarkerColor = Color.Red;
                chartPerformans.Series["Series1"].Points[Convert.ToInt32(i - 1)].MarkerBorderColor = Color.Red;
                chartPerformans.Series["Series1"].Points[Convert.ToInt32(i - 1)].MarkerSize = 5;
                chartPerformans.Series["Series1"].Points[Convert.ToInt32(i - 1)].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //standartToplama();
            //gaussToplamı(Convert.ToDecimal(Math.Pow(10, 10)));
            threadCozumu(32); // Hesapla butonuna tıklandığında grafik oluştur

        }

    }
}
