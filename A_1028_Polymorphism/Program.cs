using System;

namespace Perbankan
{
    public class Rekening
    {
        public string nama;
        public int noRekening;
        public double saldo;  

        public Rekening(string nama, int noRekening, double saldo) 
        {
            this.nama = nama;
            this.noRekening = noRekening;
            this.saldo = saldo;
        }

        public void CheckSaldo()
        {
            Console.WriteLine($"No.Rekening anda : {noRekening} \nSaldo anda : {saldo}");
        }

        public void Setor(double jumlah)
        {
            saldo += jumlah;
        }

        public virtual void Tarik(double jumlah)
        {
            if (jumlah > saldo)
            {
                Console.WriteLine("Maaf saldo anda tidak mencukupi");
            }
            else
            {
                saldo -= jumlah;
                Console.WriteLine($"Anda berhasil menarik sebesar: {jumlah} \nSaldo anda sekarang : {saldo}");
            }
        }
    }

    public class TabunganRekening : Rekening
    {
        public double bunga;

        public TabunganRekening(string nama, int noRekening, double saldo, double bunga) : base(nama, noRekening, saldo)
        {
            this.bunga = bunga;
        }

        public void HitungBunga()
        {
            saldo += bunga;
            Console.WriteLine($"Bunga sebesar {bunga} telah ditambahkan. Saldo anda sekarang: {saldo}");
        }
    }

    public class RekeningGiro : Rekening
    {
        public double batasPenarikan;

        public RekeningGiro(string nama, int noRekening, double saldo, double batasPenarikan) : base(nama,noRekening,saldo)
        {
            this.batasPenarikan = batasPenarikan;
        }

        public override void Tarik (double jumlah)
        {
            if (jumlah > saldo + batasPenarikan) // Penarikan melebihi saldo hingga batas
            {
                Console.WriteLine("Maaf, jumlah penarikan melebihi batas penarikan.");
            }
            else
            {
                saldo -= jumlah;
                Console.WriteLine($"Anda berhasil menarik sebesar: {jumlah} \nSaldo anda sekarang : {saldo}");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Membuat objek TabunganRekening
            TabunganRekening tabungan = new TabunganRekening("Putra", 123456, 50000, 5000);
            Console.WriteLine("=== Rekening Tabungan ===");
            tabungan.CheckSaldo();
            tabungan.Setor(20000);
            tabungan.Tarik(10000);
            tabungan.HitungBunga(); // Hitung dan tambahkan bunga
            tabungan.CheckSaldo();
            Console.WriteLine();

            // Membuat objek RekeningGiro
            RekeningGiro giro = new RekeningGiro("Cece", 987654, 30000, 20000);
            Console.WriteLine("=== Rekening Giro ===");
            giro.CheckSaldo();
            giro.Setor(15000);
            giro.Tarik(40000); // Akan berhasil karena saldo + batas = 50000
            giro.CheckSaldo();
            giro.Tarik(100000); // Tidak akan berhasil
            giro.CheckSaldo();
        }
    }
}
