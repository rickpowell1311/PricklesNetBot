namespace PricklesNetBot.Domain.IO
{
    public class Accelerate
    {
        public int ForwardValue { get; }

        public int BackwardValue { get; }

        private Accelerate(int forwardValue, int backwardValue)
        {
            ForwardValue = forwardValue;
            BackwardValue = backwardValue;
        }

        public static Accelerate Forward
        {
            get
            {
                return new Accelerate(32767, 0);
            }
        }

        public static Accelerate Backward
        {
            get
            {
                return new Accelerate(0, 32767);
            }
        }

        public static Accelerate None
        {
            get
            {
                return new Accelerate(0, 0);
            }
        }
    }
}
