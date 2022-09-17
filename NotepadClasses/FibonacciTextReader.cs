using System.Text;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace NotepadClasses
{
    public class FibonacciTextReader : System.IO.TextReader
    {
        //Fields
        BigInteger x = 0;
        BigInteger y = 0;
        BigInteger sum = 0;
        int takeNumber = 0;
        int maxLines = 0;

        //Properties

        public BigInteger X { get { return x; } }
        public BigInteger Y { get { return y; } }
        public BigInteger Sum { get { return sum; } }
        public int TakeNumber { get; set; }

        public int MaxLines { get; set; }

        //Constructors

        public FibonacciTextReader(int n)
        {
            this.MaxLines = n;
        }

        public override string ReadLine()
        {
            if (MaxLines == 0) return null;
            string? text = null;

            BigInteger tmp = x;
            x = y;
            sum = tmp + y;
            y = sum;
            text = sum.ToString();            
            return text;
        }

        public override string ReadToEnd()
        {
            string? text = null;
            int count = 0;
            x = 0;
            y = 1;
            StringBuilder sb = new();
            sb.Append(count.ToString() + ": ");
            sb.AppendLine(x.ToString());
            count++;
            sb.Append(count.ToString() + ": ");
            sb.AppendLine(y.ToString());
            count++;
            MaxLines -= 2;

            while (MaxLines >= 0)
            {
                sb.Append(count.ToString() + ": ");

                sb.AppendLine(this.ReadLine());
                count++;
                MaxLines--;
            }
            string complete = sb.ToString();
            return complete;
        }
    }
}