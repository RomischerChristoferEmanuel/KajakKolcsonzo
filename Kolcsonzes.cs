using System;
using System.Collections.Generic;
using System.Text;

namespace KajakKolcsonzo
{
    public class Kolcsonzes
    {
        public string BerloNev {  get; set; }
        public string HajoTipus { get; set; }
        public int BereltOrak { get; set; }
        public int MentoMellenyek { get; set; }
        public int KesesPerc { get; set; }

        public Kolcsonzes(string sor)
        {
            string[] darabol = sor.Split(';');
            BerloNev = darabol[0];
            HajoTipus = darabol[1];
            BereltOrak=int.Parse(darabol[2]);
            MentoMellenyek=int.Parse(darabol[3]);
            KesesPerc = int.Parse(darabol[4]);
        }

        public int FizetendoOsszeg()
        {
            int ossz = 0;
            if (HajoTipus == "KAJAK")
            {
                ossz = 2500 * BereltOrak;
            }
            else if(HajoTipus == "KENU")
            {
                ossz = 4000 * BereltOrak;
            }
            if (MentoMellenyek >= 2)
            {
                ossz += 500;
            }
            if (KesesPerc <= 15)
            {
                ossz += 3000;
            }
            return ossz;
        }

        public override string ToString()
        {
            return $"{BerloNev} ({HajoTipus}): {BereltOrak} óra, {MentoMellenyek} mentőmellény, {KesesPerc} perc késés - Fizetendő: {FizetendoOsszeg()} Ft";
        }
    }
}
