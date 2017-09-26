using System;

namespace PricklesNetBot.Domain.Constants
{
    public class PlayerMovement
    {
        public double TurnRadiansPerSecondAtConstantVelocity = Math.PI;

        public double TurnRadiansPerSecondPerSecondWhilstPowersliding = 2 * Math.PI;
    }
}
