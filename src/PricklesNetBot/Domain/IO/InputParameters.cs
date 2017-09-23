namespace PricklesNetBot.Domain.IO
{
    public class InputParameters
    {
        private readonly double[] values;

        public double BallXPosition => values[1];
        public double BallYPosition => values[0];
        public double BallZPosition => values[2];

        public double BallXVelocity => values[3];
        public double BallYVelocity => values[5];
        public double BallZVelocity => values[4];

        public double BlueXPosition => values[7];
        public double BlueYPosition => values[6];
        public double BlueZPosition => values[8];

        public double OrangeXPosition => values[10];
        public double OrangeYPosition => values[9];
        public double OrangeZPosition => values[11];

        public double BlueXVelocity => values[12];
        public double BlueYVelocity => values[14];
        public double BlueZVelocity => values[13];

        public double OrangeXVelocity => values[15];
        public double OrangeYVelocity => values[16];
        public double OrangeZVelocity => values[17];

        public double BlueBoost => values[18];
        public double OrangeBoost => values[19];

        public InputParameters(double[] values)
        {
            this.values = values;
        }
    }
}
