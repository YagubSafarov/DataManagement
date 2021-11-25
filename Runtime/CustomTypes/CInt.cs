namespace DataManagement.Types
{

    public class CInt
    {
        private static char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static char _ = '-';

        private char[] m_buffer;

        private int m_value;
        private int m_index;
        private int m_length;


        /// <summary>
        ///  +
        /// </summary>


        public static int operator +(int a, CInt b)
        {
            return a + b.GetValue();
        }

        public static int operator +(CInt a, int b)
        {
            return a.GetValue() + b;
        }

        public static int operator +(CInt a, CInt b)
        {
            return a.GetValue() + b.GetValue();
        }

        /// <summary>
        ///  -
        /// </summary>

        public static int operator -(int a, CInt b)
        {
            return a - b.GetValue();
        }

        public static int operator -(CInt a, int b)
        {
            return a.GetValue() - b;
        }

        public static int operator -(CInt a, CInt b)
        {
            return a.GetValue() - b.GetValue();
        }

        /// <summary>
        /// *
        /// </summary>

        public static int operator *(int a, CInt b)
        {
            return a * b.GetValue();
        }

        public static int operator *(CInt a, int b)
        {
            return a.GetValue() * b;
        }

        public static int operator *(CInt a, CInt b)
        {
            return a.GetValue() * b.GetValue();
        }


        /// <summary>
        /// /
        /// </summary>

        public static int operator /(int a, CInt b)
        {
            return a / b.GetValue();
        }

        public static int operator /(CInt a, int b)
        {
            return a.GetValue() / b;
        }

        public static int operator /(CInt a, CInt b)
        {
            return a.GetValue() / b.GetValue();
        }

        /// <summary>
        /// 
        /// </summary>



        public CInt()
        {
            m_index = -1;
            m_length = -1;
        }

        public CInt(int value)
        {
            m_index = -1;
            m_length = -1;
            SetValue(value);
        }

        private int IntLength(int i)
        {
            bool isNeqative = i < 0;
            if (isNeqative)
                i = System.Math.Abs(i);
            if (i == 0)
                return 1;
            return (int)System.Math.Floor(System.Math.Log10(i)) + (isNeqative ? 2 : 1);
        }

        private int IntLength2(int i)
        {
            int num = (m_value);
            int length = 0;
            while (num > 0)
            {
                length++;
                num /= 10;
            }
            return length;
        }


        public int GetValue()
        {
            return m_value;
        }

        public void SetValue(int value)
        {
            m_value = value;
        }

        public void Add(int value)
        {
            m_value = m_value + value;
        }

        public char[] ToCharArray()
        {
            int length = IntLength2(m_value);

            if (m_buffer == null || m_buffer.Length != length)
            {
                m_buffer = new char[length];
            }

            int num = (m_value);

            int i = length - 1;

            while (num > 0)
            {
                m_buffer[i] = numbers[num % 10];
                num /= 10;
                i--;
            }

            bool isNeqative = m_value < 0;

            if (isNeqative)
            {
                m_buffer[i] = _;
                i--;
            }
            return m_buffer;
        }

        public override string ToString()
        {
            return new string(ToCharArray());
        }
    }
}
