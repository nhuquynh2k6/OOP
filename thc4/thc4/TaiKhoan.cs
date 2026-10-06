using System;

namespace thc4
{
    class TaiKhoan
    {
        private long _mstk;
        private string _tctk;
        private double _st;

        // Constructor
        public TaiKhoan(long mstk, string tctk, double st)
        {
            _mstk = mstk;
            _tctk = tctk;
            ST = st; // use property for validation
        }

        // Property for So Tien (balance)
        public double ST
        {
            get { return _st; }
            set
            {
                if (value > 0)
                {
                    _st = value;
                }
                else
                {
                    Console.WriteLine("st phải > 0");
                }
            }
        }

        // ToString override
        public override string ToString()
        {
            return $"MSTK: {_mstk}, Chu TK: {_tctk}, So tien: {_st}";
        }
    }
}